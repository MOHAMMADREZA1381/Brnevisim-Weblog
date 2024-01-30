
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        public DbSet<User> Users { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
