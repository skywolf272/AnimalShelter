using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DogShelter.Models;
using Microsoft.AspNetCore.Identity;

namespace DogShelter.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder) //Создание админа при создании БД
        {
            base.OnModelCreating(builder);
            string AdminID = Guid.NewGuid().ToString();
            string AdminRoleID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = AdminRoleID,
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            var Hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = AdminID, 
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "admin")
            }); ;

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = AdminID,
                RoleId = AdminRoleID
            });
        }

        public DbSet<News> News { get; set; }
        public DbSet<Dog> DogPosts { get; set; }
        public DbSet<AppointmentToShelter> Appointments { get; set; }
    }
}
