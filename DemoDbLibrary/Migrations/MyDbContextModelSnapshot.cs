﻿// <auto-generated />
using DemoDbLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoDbLibrary.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoDbModels.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ben",
                            LastName = "Kenobi"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Luke",
                            LastName = "Skywalker"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Anakin",
                            LastName = "Skywalker"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Han",
                            LastName = "Solo"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Chewbacca",
                            LastName = ""
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Yoda",
                            LastName = ""
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Leia",
                            LastName = "Organa Skywalker-Solo"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Rei",
                            LastName = "WhoKnows"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "Boba",
                            LastName = "Fett"
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Jabba",
                            LastName = "TheHut"
                        },
                        new
                        {
                            Id = 11,
                            FirstName = "Sheev",
                            LastName = "Palpatine"
                        },
                        new
                        {
                            Id = 12,
                            FirstName = "Padme",
                            LastName = "Amidalla"
                        });
                });

            modelBuilder.Entity("DemoDbModels.Starship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Starships");
                });
#pragma warning restore 612, 618
        }
    }
}
