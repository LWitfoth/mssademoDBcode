using DemoDbLibrary;
using DemoDbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace MyDemoDBFormsApp
{
    public partial class Form1 : Form
    {
        private static IConfigurationRoot _configuration;
        public static DbContextOptionsBuilder<MyDbContext> _optionsBuilder;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// still need to add Event on Main Form to trigger refresh to work
        /// </summary>
        public void Refresh()
        {
            //load categories
            using (var db = new MyDbContext(_optionsBuilder.Options))
            {
                var people = db.People.ToList();
                dgPeople.DataSource = people;
            }
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionStringNameKey"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuildOptions();
            Refresh();
           
        }

        private void btnAddPerson_click(object sender, EventArgs e)
        {
            var addForm = new AddUpdateForm();
            addForm.ShowDialog();
        }

        private void btnUpdatePerson_Click(object sender, EventArgs e)
        {
            if (dgPeople.SelectedRows.Count > 0)
            {
                var personData = dgPeople.SelectedRows[0].Cells;
                var person = new Person();

                person.Id = (int)personData[0].Value;
                person.FirstName = (string)personData[1].Value;
                person.LastName = (string)personData[2].Value;

                var addForm = new AddUpdateForm(person);
                addForm.ShowDialog();

            }
        }
    }
}