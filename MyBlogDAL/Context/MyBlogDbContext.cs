using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogDomain.Entities;
using MyBlogDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Context
{
    public class MyBlogDbContext : IdentityDbContext
    {

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MyBlogDomain.Entities.Label> Labels { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }



        //protected override void OnConfiguring(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<IdentityRole>().HasData(
        //        new IdentityRole
        //        {
        //            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
        //            Name = "Admin",
        //            NormalizedName = "ADMIN".ToUpper()
        //        },
        //        new IdentityRole
        //        {
        //            Id = "2c5e174e-3b0e-446f-86af-483d56fd3262",
        //            Name = "StandartUser",
        //            NormalizedName = "StrandartUser".ToUpper()
        //        }
        //        );
        //    var hasher = new PasswordHasher<AppUser>();
        //    modelBuilder.Entity<AppUser>().HasData(
        //        new AppUser
        //        {
        //            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
        //            FirstName = "Tarık",
        //            LastName = "Çelebi",
        //            Email = "tarikcelebi97@gmail.com",
        //            UserName = "Admin",
        //            EmailConfirmed = true,
        //            PasswordHash = hasher.HashPassword(null, "Qwe_123."),
        //            SecurityStamp = string.Empty
        //        }
        //        );
        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        //        new IdentityUserRole<string>
        //        {
        //            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
        //            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
        //        }
        //        );
        //}

    }
}
