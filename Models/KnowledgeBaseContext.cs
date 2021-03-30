using Microsoft.EntityFrameworkCore; 

namespace FieldEngineerApi.Models 
{ 
    public class KnowledgeBaseContext : DbContext 
    { 
        public KnowledgeBaseContext(DbContextOptions<KnowledgeBaseContext> options) 
            : base(options) 
        { 

        } 

        public DbSet<KnowledgeBaseBoilerPart> BoilerParts { get; set; } 
        public DbSet<KnowledgeBaseEngineer> Engineers { get; set; } 
        public DbSet<KnowledgeBaseTip> Tips { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeBaseEngineer>().HasData(
                new KnowledgeBaseEngineer {
                    Id = "ab9f4790-05f2-4cc3-9f01-8dfa7d848179",
                    Name = "Michelle Harris",
                    ContactNumber = "554-1000"
                },
                new KnowledgeBaseEngineer {
                    Id = "f97f7495-101d-45b3-ac62-45a15e4d56c5",
                    Name = "Sara Perez",
                    ContactNumber = "554-1001"
                },
                new KnowledgeBaseEngineer {
                    Id = "cd3ed834-49fe-42c0-9b57-6627fe13c8ba",
                    Name = "Quincy Watson",
                    ContactNumber = "554-1002"
                }
            );

            modelBuilder.Entity<KnowledgeBaseBoilerPart>().HasData(
                new KnowledgeBaseBoilerPart {
                    Id = 1,
                    Name = "Pumped Water Controller",
                    Overview = "Water pump controller for combination boiler"
                },
                new KnowledgeBaseBoilerPart {
                    Id = 2,
                    Name = "3.5 W/S Heater",
                    Overview = "Small heat exchanger for domestic boiler"
                },
                new BoilerPart {
                    Id = 3, 
                    Name = "Inlet Valve",
                    Overview = "Water inlet valve with one-way operation"
                },
                new BoilerPart {
                    Id = 4,
                    Name = "Mid-position Valve",
                    Overview = "Bi-directional pressure release"
                },
                new BoilerPart {
                    Id = 5,
                    Name = "5.0 W/S Heater",
                    Overview = "Medium heat exchanger for canteen boiler"
                },
                new BoilerPart {
                    Id = 6,
                    Name = "Fan Controller",
                    Overview = "Controller for air-con unit"
                }
            );

            modelBuilder.Entity<KnowledgeBaseTip>().HasData(
                new KnowledgeBaseTip {
                    Id = 1,
                    KnowledgeBaseBoilerPartId = 1,
                    KnowledgeBaseEngineerId = "cd3ed834-49fe-42c0-9b57-6627fe13c8ba",
                    Subject = "How to get water to the right temperature",
                    Body = "If water doesn't get hot when radiators are on, replace the diverter valve."
                },
                new KnowledgeBaseTip {
                    Id = 2,
                    KnowledgeBaseBoilerPartId = 1,
                    KnowledgeBaseEngineerId = "cd3ed834-49fe-42c0-9b57-6627fe13c8ba",
                    Subject = "Where to site this boiler",
                    Body = "When installing this unit, don't place it more that 5 feet higher than the fuel tank, without a fuel pump."
                },
                new KnowledgeBaseTip {
                    Id = 3,
                    KnowledgeBaseBoilerPartId = 3,
                    KnowledgeBaseEngineerId = "ab9f4790-05f2-4cc3-9f01-8dfa7d848179",
                    Subject = "How to get this nozzle to light the furnace correctly",
                    Body = "Sometimes the nozzle gets clogged with old oil or dirt. You can use a fine point to clear it, or replace."
                }
            );
        }
    } 
} 