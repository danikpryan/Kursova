using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain.Entities;

namespace Wall.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "0dc0d084-58a1-4749-81da-537c7832d080",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "84ef18a5-4c20-4306-a26f-1e9c112233c8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "tbol240@gmail.com",
                NormalizedEmail = "TBOL240@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "0dc0d084-58a1-4749-81da-537c7832d080",
                UserId = "84ef18a5-4c20-4306-a26f-1e9c112233c8",
            });

            builder.Entity<Category>().HasData(new Category
            {
                id = 1,
                categoryName = "Футболки",
            });

            builder.Entity<Category>().HasData(new Category
            {
                id = 2,
                categoryName = "Кофти",
            });

            builder.Entity<Category>().HasData(new Category
            {
                id = 3,
                categoryName = "Куртки",
            });
        }
    }
}
