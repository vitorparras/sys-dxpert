using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<NotificationPreferences> NotificationPreferences { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<SystemMetrics> SystemMetrics { get; set; }
        public DbSet<UserMetrics> UserMetrics { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

        public SysDbContext(DbContextOptions<SysDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<RefreshToken>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
        }
    }
}
