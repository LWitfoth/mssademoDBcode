using DemoDbLibrary;
using DemoDbModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MyDemoDbApplication
{
    public class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<MyDbContext> _optionsBuilder;

        private static void DoOne()
        {
            using (var db = new MyDbContext())
            {
                var person = db.People.FirstOrDefault(x => x.FirstName == "John"
                                                            && x.LastName == "Connor");
                if (person is null)
                {
                    Person p = new Person();
                    p.FirstName = "John";
                    p.LastName = "Connor";
                    db.Add(p);
                }
                else
                {
                    person.FirstName = "Sarah";
                }

                db.SaveChanges();
            }
        }
        private static void DoTwo()
        {
            using (var db = new MyDbContext())
            {
                //var skywalkers = db.People.Where(x => x.LastName.Contains("Skywalker"))
                //                                        .ToList();

                var skywalkers = db.People.Where(x => x.LastName.Contains("Skywalker"))
                                             .OrderBy(x => x.LastName)
                                             .ThenBy(x => x.FirstName)
                                             .ToList();



                //var orderedSkywalkers = skywalkers
                //                            .OrderBy(x => x.LastName)
                //                            .ThenBy(x => x.FirstName)
                //                            .ToList();

                foreach (var skywalker in skywalkers)
                {
                    Console.WriteLine($"Next Skywalker: {skywalker.FirstName} {skywalker.LastName}");
                }

                var coolSkywalkers = db.People.Where(x => x.LastName.Contains("Skywalker"))
                                             .OrderBy(x => x.LastName)
                                             .ThenBy(x => x.FirstName)
                                             .Select(x => new {
                                                 Id = x.Id,
                                                 Name = x.FirstName + ' ' + x.LastName
                                             });

                foreach (var sky in coolSkywalkers)
                {
                    Console.WriteLine($"Next Skywalker: {sky.Name} ");
                }

                //foreach (var skywalker in orderedSkywalkers)
                //{
                //    Console.WriteLine($"Next Skywalker: {skywalker.FirstName} {skywalker.LastName}");
                //}
            }
        }

        public static void Main(string[] args)
        {
            BuildOptions();
            Console.WriteLine("Hello World");

            DoAdo();
        }

        private static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionStringNameKey"));
            
        }


        private static void DoAdo()
        {
            //get connection string
            var cnstr = _configuration.GetConnectionString("ADOConnectionString");

            //get connection object
            var connection = new SqlConnection(cnstr);

            //open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var query = "SELECT [p].[Id], [p].[FirstName], [p].[LastName] " +
                                    "FROM[People] AS[p] " +
                                    "WHERE[p].[LastName] LIKE N'%Skywalker%' " +
                                    "ORDER BY[p].[LastName], [p].[FirstName]";

            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            command.CommandTimeout = 0;
            var reader = command.ExecuteReader();

            List<Person> people = new List<Person>();
            while (reader.Read())
            {
                var p = new Person();
                p.Id = Convert.ToInt32(reader[0].ToString());
                p.FirstName = reader[1].ToString();
                p.LastName = reader[2].ToString();
                people.Add(p);
            }

            reader.Close();
            foreach (var skywalker in people)
            {
                Console.WriteLine($"Next Skywalker: {skywalker.FirstName} {skywalker.LastName}");
            }

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);

            foreach (var table in ds.Tables)
            {
                //Console.WriteLine(((DataTable)table).TableName);
                foreach (var row in ((DataTable)table).Rows)
                {
                    //Console.WriteLine(((DataRow)row).ItemArray.Count());
                    foreach (var item in ((DataRow)row).ItemArray)
                    {
                        Console.WriteLine(item);
                    }
                }
            }


            //close it
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                //dispose it
                connection.Dispose();
            }

            


            
        }

    }
}
