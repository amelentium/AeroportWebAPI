﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillAppAdoDapperWebApi.DAL.Infrastructure;

namespace SkillAppAdoDapperWebApi.Infrastructure.Migrations
{
    [DbContext(typeof(AeroDbContext))]
    [Migration("20201119131002_unitial")]
    partial class unitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SkillManagement.DataAccess.Entities.SQLEntities.SQLAeroplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("Valocity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aeroplanes");
                });

            modelBuilder.Entity("SkillManagement.DataAccess.Entities.SQLEntities.SQLAeroport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aeroports");
                });

            modelBuilder.Entity("SkillManagement.DataAccess.Entities.SQLEntities.SQLFlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ArriveToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartFromId")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int?>("PlaneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArriveToId");

                    b.HasIndex("DepartFromId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("SkillManagement.DataAccess.Entities.SQLEntities.SQLPassenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatNum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("SkillManagement.DataAccess.Entities.SQLEntities.SQLFlight", b =>
                {
                    b.HasOne("SkillManagement.DataAccess.Entities.SQLEntities.SQLAeroport", "ArriveTo")
                        .WithMany()
                        .HasForeignKey("ArriveToId");

                    b.HasOne("SkillManagement.DataAccess.Entities.SQLEntities.SQLAeroport", "DepartFrom")
                        .WithMany()
                        .HasForeignKey("DepartFromId");

                    b.HasOne("SkillManagement.DataAccess.Entities.SQLEntities.SQLAeroplane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId");

                    b.Navigation("ArriveTo");

                    b.Navigation("DepartFrom");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("SkillManagement.DataAccess.Entities.SQLEntities.SQLPassenger", b =>
                {
                    b.HasOne("SkillManagement.DataAccess.Entities.SQLEntities.SQLFlight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.Navigation("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
