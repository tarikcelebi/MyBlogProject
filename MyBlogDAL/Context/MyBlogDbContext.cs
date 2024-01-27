using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogDAL.Context
{
    public class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext dbContext;

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
