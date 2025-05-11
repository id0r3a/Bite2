using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Seed
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "Alice", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin12345"), Role = "Admin" },
                new User { UserId = 2, Username = "Bob", PasswordHash = BCrypt.Net.BCrypt.HashPassword("hashedpassword2"), Role = "User" }
            );

            //Restaurants
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "Pizza Palace" }
            );

            // MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, Name = "Margherita Pizza", Price = 99.99m},
                new MenuItem { MenuItemId = 2, Name = "Pepperoni Pizza", Price = 109.99m }
            );

            //Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserId = 2, OrderDate = DateTime.UtcNow, TotalAmount = 209.98m, Status = "Completed" }
            );

            //OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, Quantity = 1, Price = 99.99m },
                new OrderItem { OrderItemId = 2, OrderId = 1, MenuItemId = 2, Quantity = 1, Price = 109.99m }
            );

            //Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, UserId = 2, RestaurantId = 1, Rating = 5, Comment = "Amazing pizza!", ReviewDate = DateTime.UtcNow }
            );
        }
    }
}
