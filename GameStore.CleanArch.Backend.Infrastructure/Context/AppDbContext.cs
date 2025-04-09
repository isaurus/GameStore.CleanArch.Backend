using GameStore.CleanArch.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.CleanArch.Backend.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Id).ValueGeneratedOnAdd();

                entity.Property(g => g.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(g => g.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(g => g.Release)
                    .IsRequired();

                entity.Property(g => g.Price)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();
            });
        }
    }
}
