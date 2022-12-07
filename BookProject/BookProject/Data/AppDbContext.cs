using BookProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
