﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeopleWebApi.Db;

namespace PeopleWebApi.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    partial class PeopleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeopleWebApi.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0b246ac8-6d72-4389-9ebd-a85e63341d8d"),
                            Fullname = "Person-1-Fullname"
                        },
                        new
                        {
                            Id = new Guid("b8cc595b-b7b1-4626-ac89-589cca7a4b1b"),
                            Fullname = "Person-2-Fullname"
                        },
                        new
                        {
                            Id = new Guid("162c1866-4902-44ff-ae6f-253a6115aca8"),
                            Fullname = "Person-3-Fullname"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
