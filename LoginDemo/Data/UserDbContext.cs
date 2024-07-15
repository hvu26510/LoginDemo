using Microsoft.EntityFrameworkCore;
using LoginDemo.Models;

namespace LoginDemo.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
    }
}
