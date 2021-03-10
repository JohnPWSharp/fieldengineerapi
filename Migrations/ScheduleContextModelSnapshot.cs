﻿// <auto-generated />
using System;
using FieldEngineerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FieldEngineerApi.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    partial class ScheduleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FieldEngineerApi.Models.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AppointmentStatusId")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<long>("EngineerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentStatusId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EngineerId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AppointmentStatusId = 3L,
                            CustomerId = 1L,
                            EngineerId = 1L,
                            Notes = "Installed a new diverter valva",
                            ProblemDetails = "Boiler wont start",
                            StartDateTime = new DateTime(2021, 2, 28, 17, 29, 21, 576, DateTimeKind.Local).AddTicks(7101)
                        },
                        new
                        {
                            Id = 2L,
                            AppointmentStatusId = 2L,
                            CustomerId = 2L,
                            EngineerId = 2L,
                            Notes = "Needed a new heat exchanger",
                            ProblemDetails = "Can't change temperature",
                            StartDateTime = new DateTime(2021, 3, 2, 17, 29, 21, 579, DateTimeKind.Local).AddTicks(2438)
                        },
                        new
                        {
                            Id = 3L,
                            AppointmentStatusId = 2L,
                            CustomerId = 3L,
                            EngineerId = 2L,
                            Notes = "Bled radiators.",
                            ProblemDetails = "Radiators aren't working",
                            StartDateTime = new DateTime(2021, 3, 3, 17, 29, 21, 579, DateTimeKind.Local).AddTicks(2465)
                        });
                });

            modelBuilder.Entity("FieldEngineerApi.Models.AppointmentStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppointmentStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            StatusName = "Unresolved"
                        },
                        new
                        {
                            Id = 2L,
                            StatusName = "Parts Ordered"
                        },
                        new
                        {
                            Id = 3L,
                            StatusName = "Fixed"
                        });
                });

            modelBuilder.Entity("FieldEngineerApi.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "4567 Main St Buffalo, NY 98052",
                            ContactNumber = "555-0199",
                            Name = "Damayanti Basumatary"
                        },
                        new
                        {
                            Id = 2L,
                            Address = "4568 Main St Buffalo, NY 98052",
                            ContactNumber = "555-0200",
                            Name = "Deepali Haloi"
                        },
                        new
                        {
                            Id = 3L,
                            Address = "4569 Main St Buffalo, NY 98052",
                            ContactNumber = "555-0201",
                            Name = "Hua Long"
                        },
                        new
                        {
                            Id = 4L,
                            Address = "4570 Main St Buffalo, NY 98052",
                            ContactNumber = "555-0202",
                            Name = "Volha Pashkevich"
                        },
                        new
                        {
                            Id = 5L,
                            Address = "4571 Main St Buffalo, NY 98053",
                            ContactNumber = "555-0203",
                            Name = "Veselin Iliev"
                        },
                        new
                        {
                            Id = 6L,
                            Address = "4571 Main St Buffalo, NY 98054",
                            ContactNumber = "555-0204",
                            Name = "Tsehayetu Abera"
                        });
                });

            modelBuilder.Entity("FieldEngineerApi.Models.ScheduleEngineer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Engineers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ContactNumber = "554-1000",
                            Name = "Sara Perez"
                        },
                        new
                        {
                            Id = 2L,
                            ContactNumber = "554-1001",
                            Name = "Michelle Harris"
                        },
                        new
                        {
                            Id = 3L,
                            ContactNumber = "554-1002",
                            Name = "Quincy Watson"
                        });
                });

            modelBuilder.Entity("FieldEngineerApi.Models.Appointment", b =>
                {
                    b.HasOne("FieldEngineerApi.Models.AppointmentStatus", "AppointmentStatus")
                        .WithMany("Appointments")
                        .HasForeignKey("AppointmentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FieldEngineerApi.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FieldEngineerApi.Models.ScheduleEngineer", "Engineer")
                        .WithMany("Appointments")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentStatus");

                    b.Navigation("Customer");

                    b.Navigation("Engineer");
                });

            modelBuilder.Entity("FieldEngineerApi.Models.AppointmentStatus", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("FieldEngineerApi.Models.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("FieldEngineerApi.Models.ScheduleEngineer", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
