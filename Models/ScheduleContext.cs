using System; 
using Microsoft.EntityFrameworkCore; 

namespace FieldEngineerApi.Models 
{ 
    public class ScheduleContext : DbContext 
    { 
        public ScheduleContext(DbContextOptions<ScheduleContext> options) 
            : base(options) 
        { 

        } 

        public DbSet<Appointment> Appointments { get; set; } 
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<ScheduleEngineer> Engineers { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentStatus>().HasData(
                new AppointmentStatus {Id = 1, StatusName = "Unresolved"},
                new AppointmentStatus {Id = 2, StatusName = "Parts Ordered"},
                new AppointmentStatus {Id = 3, StatusName = "Fixed"}
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer {
                    Id = 1, 
                    Name = "Damayanti Basumatary",
                    Address = "4567 Main St Buffalo, NY 98052",
                    ContactNumber = "555-0199"
                },
                new Customer {
                    Id = 2,
                    Name = "Deepali Haloi",
                    Address = "4568 Main St Buffalo, NY 98052",
                    ContactNumber = "555-0200"
                },
                new Customer {
                    Id = 3,
                    Name = "Hua Long",
                    Address = "4569 Main St Buffalo, NY 98052",
                    ContactNumber = "555-0201"
                },
                new Customer {
                    Id = 4,
                    Name = "Volha Pashkevich",
                    Address = "4570 Main St Buffalo, NY 98052",
                    ContactNumber = "555-0202"
                },
                new Customer {
                    Id = 5,
                    Name = "Veselin Iliev",
                    Address = "4571 Main St Buffalo, NY 98053",
                    ContactNumber = "555-0203"
                },
                new Customer {
                    Id = 6,
                    Name = "Tsehayetu Abera",
                    Address = "4572 Main St Buffalo, NY 98054",
                    ContactNumber = "555-0204"
                }
            );

            modelBuilder.Entity<ScheduleEngineer>().HasData(
                new ScheduleEngineer {
                    Id = "ab9f4790-05f2-4cc3-9f01-8dfa7d848179",
                    Name = "Michelle Harris",
                    ContactNumber = "554-1000"
                },
                new ScheduleEngineer {
                    Id = "f97f7495-101d-45b3-ac62-45a15e4d56c5",
                    Name = "Sara Perez",
                    ContactNumber = "554-1001"
                },
                new ScheduleEngineer {
                    Id = "cd3ed834-49fe-42c0-9b57-6627fe13c8ba",
                    Name = "Quincy Watson",
                    ContactNumber = "554-1002"
                }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment {
                    Id = 1,
                    CustomerId = 1,
                    ProblemDetails = "Boiler wont start",
                    AppointmentStatusId = 3, 
                    EngineerId = "ab9f4790-05f2-4cc3-9f01-8dfa7d848179", 
                    StartDateTime = DateTime.Now.AddDays(-10),
                    Notes = "Installed a new diverter valve"
                },
                new Appointment {
                    Id = 2,
                    CustomerId = 2,
                    ProblemDetails = "Can't change temperature",
                    AppointmentStatusId = 2,
                    EngineerId = "f97f7495-101d-45b3-ac62-45a15e4d56c5",
                    StartDateTime = DateTime.Now.AddDays(-8),
                    Notes = "Needed a new heat exchanger"
                },
                new Appointment {
                    Id = 3,
                    CustomerId = 3,
                    ProblemDetails = "Radiators aren't working",
                    AppointmentStatusId = 2,
                    EngineerId = "f97f7495-101d-45b3-ac62-45a15e4d56c5",
                    StartDateTime = DateTime.Now.AddDays(-7),
                    Notes = "Bled radiators."
                },
                new Appointment {
                    Id = 4,
                    CustomerId = 1,
                    ProblemDetails = "Boiler wont start",
                    AppointmentStatusId = 3, 
                    EngineerId = "ab9f4790-05f2-4cc3-9f01-8dfa7d848179", 
                    StartDateTime = DateTime.Now.AddDays(-5),
                    Notes = "Installed a second new diverter valve"
                },
                new Appointment {
                    Id = 5,
                    CustomerId = 2,
                    ProblemDetails = "Water is not hot enough",
                    AppointmentStatusId = 1, 
                    EngineerId = "cd3ed834-49fe-42c0-9b57-6627fe13c8ba", 
                    StartDateTime = DateTime.Now.AddDays(10),
                    Notes = ""
                },
                new Appointment {
                    Id = 6,
                    CustomerId = 2,
                    ProblemDetails = "Furnace is making a strange noise",
                    AppointmentStatusId = 1, 
                    EngineerId = "cd3ed834-49fe-42c0-9b57-6627fe13c8ba", 
                    StartDateTime = DateTime.Now,
                    Notes = "It bangs when it ignites"
                },
                new Appointment {
                    Id = 7,
                    CustomerId = 6,
                    ProblemDetails = "Boiler needs its annual service",
                    AppointmentStatusId = 1, 
                    EngineerId = "f97f7495-101d-45b3-ac62-45a15e4d56c5", 
                    StartDateTime = DateTime.Now.AddDays(4),
                    Notes = "No particular problems"
                },
                new Appointment {
                    Id = 8,
                    CustomerId = 4,
                    ProblemDetails = "Control panel has been broken",
                    AppointmentStatusId = 1, 
                    EngineerId = "f97f7495-101d-45b3-ac62-45a15e4d56c5", 
                    StartDateTime = DateTime.Now.AddDays(5),
                    Notes = "Must be replaced"
                }
            );
        }
    } 
}