using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Data.Entities
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
