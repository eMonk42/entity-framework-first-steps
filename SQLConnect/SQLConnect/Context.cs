using System;
using Microsoft.EntityFrameworkCore;

namespace SQLConnect
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions<Context> contextOptions): base(contextOptions)
        {

        }

        // to make phone numbers unique
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TelephoneNumber>().HasIndex(t => t.Number).IsUnique();
        }
    }
}
