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
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BoilerPart>().HasData(
                new BoilerPart {
                    Id = 1,
                    Name = "Pumped Water Controller",
                    CategoryId = "PCB Assembly",
                    Price = 45.99M,
                    Overview = "Water pump controller for combination boiler",
                    NumberInStock = 0,
                    ImageUrl = "http://contoso.com/image1"
                },
                new BoilerPart {
                    Id = 2,
                    Name = "3.5 W/S Heater",
                    CategoryId = "Heat Exchanger",
                    Price = 125.5M,
                    Overview = "Small heat exchanger for domestic boiler",
                    NumberInStock = 5,
                    ImageUrl = "http://contoso.com/image2"
                },
                new BoilerPart {
                    Id = 3, 
                    Name = "Inlet Valve",
                    CategoryId = "Valve",
                    Price = 120.2M,
                    Overview = "Water inlet valve with one-way operation",
                    NumberInStock = 13,
                    ImageUrl = "http://contoso.com/image3"
                },
                new BoilerPart {
                    Id = 4,
                    Name = "Mid-position Valve",
                    CategoryId = "Valve",
                    Price = 180.9M,
                    Overview = "Bi-directional pressure release",
                    NumberInStock = 8,
                    ImageUrl = "http://contoso.com/image4"
                },
                new BoilerPart {
                    Id = 5,
                    Name = "5.0 W/S Heater",
                    CategoryId = "Heat Exchanger",
                    Price = 145.9M,
                    Overview = "Medium heat exchanger for canteen boiler",
                    NumberInStock = 1,
                    ImageUrl = "http://contoso.com/image5"
                },
                new BoilerPart {
                    Id = 6,
                    Name = "Fan Controller",
                    CategoryId = "PCB Assembly",
                    Price = 28.35M,
                    Overview = "Controller for air-con unit",
                    NumberInStock = 7,
                    ImageUrl = "http://contoso.com/image6"
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