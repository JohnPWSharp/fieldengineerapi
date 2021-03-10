using System;
using Microsoft.EntityFrameworkCore;

namespace FieldEngineerApi.Models
{

    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {

        }

        public DbSet<BoilerPart> BoilerParts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Boiler"},
                new Category {Id = 2, Name = "Sprocket"},
                new Category {Id = 3, Name = "Flange"},
                new Category {Id = 4, Name = "Exchanger"}
            );

            modelBuilder.Entity<BoilerPart>().HasData(
                new BoilerPart {
                    Id = 1,
                    Name = "Caserta Stone Beige",
                    CategoryId = 3,
                    Price = 8.1M,
                    Overview = "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations.",
                    NumberInStock = 25
                },
                new BoilerPart {
                    Id = 2,
                    Name = "Caserta Sky Grey",
                    CategoryId = 2,
                    Price = 8.1M,
                    Overview = "Extreme Series 18 in. x 18 in. carpet tiles are a durable and beautiful carpet solution specially engineered for both indoor and outdoor residential installations.",
                    NumberInStock = 30
                },
                new BoilerPart {
                    Id = 3, 
                    Name = "Ageless Beauty Clay",
                    CategoryId = 1,
                    Price = 1.98M,
                    Overview = "Add some fashion to your floors with the Shaw Ageless Beauty Carpet collection.",
                    NumberInStock = 5
                },
                new BoilerPart {
                    Id = 4,
                    Name = "Lush II Tundra",
                    CategoryId = 4,
                    Price = 3.79M,
                    Overview = "Made with 100% premium nylon fiber, this textured carpet creates a warm, casual atmosphere that invites you to relax and thoroughly enjoy your home.",
                    NumberInStock = 12
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order {
                    Id = 1,
                    BoilerPartId = 1,
                    quantity = 30,
                    TotalPrice = 243.0M,
                    OrderedDateTime = DateTime.Now.AddDays(-5),
                    Delivered = false
                },
                new Order {
                    Id = 2,
                    BoilerPartId = 3,
                    quantity = 20,
                    TotalPrice = 39.6M,
                    OrderedDateTime = DateTime.Now.AddDays(-7),
                    Delivered = true,
                    DeliveredDateTime = DateTime.Now.AddDays(-4)
                }
            );
        }
    }

}