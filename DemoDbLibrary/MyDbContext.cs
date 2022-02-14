using DemoDbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoDbLibrary
{
    public class MyDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public DbSet<Person> People { get; set; }
        public DbSet<Starship> Starships { get; set; }

        public MyDbContext() : base()
        {
            //intentionally empty
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
            //intentionally empty
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("ConnectionStringNameKey");
                optionsBuilder.UseSqlServer(cnstr);
            }

        }

        //use this for all of your FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(x =>
            {
                x.HasData(new Person() { Id = 1, FirstName = "Ben", LastName = "Kenobi" },
                            new Person() { Id = 2, FirstName = "Luke", LastName = "Skywalker" },
                            new Person() { Id = 3, FirstName = "Anakin", LastName = "Skywalker" },
                            new Person() { Id = 4, FirstName = "Han", LastName = "Solo" },
                            new Person() { Id = 5, FirstName = "Chewbacca", LastName = "" },
                            new Person() { Id = 6, FirstName = "Yoda", LastName = "" },
                            new Person() { Id = 7, FirstName = "Leia", LastName = "Organa Skywalker-Solo" },
                            new Person() { Id = 8, FirstName = "Rei", LastName = "WhoKnows" },
                            new Person() { Id = 9, FirstName = "Boba", LastName = "Fett" },
                            new Person() { Id = 10, FirstName = "Jabba", LastName = "TheHut" },
                            new Person() { Id = 11, FirstName = "Sheev", LastName = "Palpatine" },
                            new Person() { Id = 12, FirstName = "Padme", LastName = "Amidalla" }
                );
            });
        }
    }
}