﻿// <auto-generated />
using DatabaseLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseLayer.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20180906124730_databaseMigration")]
    partial class databaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.BloodGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Active");

                    b.Property<string>("BloodGroupName");

                    b.HasKey("Id");

                    b.ToTable("BloodGroups");
                });

            modelBuilder.Entity("Models.Registration", b =>
                {
                    b.Property<int>("Sno")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DOB");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Gender");

                    b.Property<int>("Id");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("UserId");

                    b.Property<string>("Username");

                    b.HasKey("Sno");

                    b.HasIndex("Id");

                    b.ToTable("UserRegistration");
                });

            modelBuilder.Entity("Models.Registration", b =>
                {
                    b.HasOne("Models.BloodGroup", "bloodGroup")
                        .WithMany("Users")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
