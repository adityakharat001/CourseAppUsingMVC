using HackathonWithMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonWithMVC.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> Context) : base(Context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasNoKey();
        }

        public DbSet<User> users { get; set; }
        public DbSet<UserInfo> userInfo { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Cart> carts { get; set; }
    }
}
