using Microsoft.EntityFrameworkCore;
using PasswordHashing.Models;

namespace PasswordHashing.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
