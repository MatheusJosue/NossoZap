using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Reflection.Emit;

namespace Infrastructure.Data.Context
{
    public class MySQLContext : IdentityDbContext<User>
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Comment> Comment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
