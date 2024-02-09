using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Context
{
    public class MyBlogDbContext : IdentityDbContext<AppUser>
    {

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MyBlogDomain.Entities.Label> Labels { get; set; }

        internal static void AddBaseOptions(DbContextOptionsBuilder<MyBlogDbContext> dbContextOptionsBuilder, string connectionString)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                },
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd3262",
                    Name = "StandartUser",
                    NormalizedName = "StrandartUser".ToUpper()
                }
                );
            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    FirstName = "Tarık",
                    LastName = "Çelebi",
                    Email = "tarikcelebi97@gmail.com",
                    UserName = "Admin",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Qwe_123."),
                    SecurityStamp = string.Empty,
                    NormalizedEmail = "tarikcelebi97@gmail.com".ToUpper(),
                    NormalizedUserName = "Admin".ToUpper()
                }
                );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                }
                );
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
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
        //            Id= "a18be9c0-aa65-4af8-bd17-00bd9344e575",  
        //            FirstName="Tarık",
        //            LastName="Çelebi",
        //            Email="tarikcelebi97@gmail.com",
        //            UserName="Admin",
        //            EmailConfirmed = true,
        //            PasswordHash = hasher.HashPassword(null, "Qwe_123."),
        //            SecurityStamp = string.Empty
        //        }
        //        );
        //    modelBuilder.Entity<IdentityUserRole<string>>().HasData(
        //        new IdentityUserRole<string>
        //        {
        //            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
        //            UserId= "a18be9c0-aa65-4af8-bd17-00bd9344e575"
        //        }
        //        );
        //}

    }
}
