
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

    }
}
