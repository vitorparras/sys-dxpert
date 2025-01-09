using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<NotificationPreferences> NotificationPreferences { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<SystemMetrics> SystemMetrics { get; set; }
        public DbSet<UserMetrics> UserMetrics { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

        public SysDbContext(DbContextOptions<SysDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
