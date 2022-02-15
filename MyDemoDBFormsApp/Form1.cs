using DemoDbLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyDemoDBFormsApp
{
    public partial class Form1 : Form
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<MyDbContext> _optionsBuilder;

        public Form1()
        {
            InitializeComponent();
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
            //load categories
            using (var db = new MyDbContext(_optionsBuilder.Options))
            {
                var people = db.People.ToList();
            }
        }
    }
}