using System.Reflection;
using GameStore.CleanArch.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            // Conversor genérico para DateTime y DateTime? UTC (con Kind=Utc)
            var dateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v
            );

            // Aplicar conversores automáticamente a todas las propiedades DateTime y DateTime? en todas las entidades
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.ClrType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                            .Property(property.Name)
                            .HasConversion(dateTimeConverter);
                    }
                }
            }

            // Conversor de DateOnly <-> DateTime
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d)
            );

            // Modificación de queries para borrado lógico
            modelBuilder.Entity<Game>()
                .HasQueryFilter(a => a.IsEnabled);

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
                    .IsRequired()
                    .HasConversion(dateOnlyConverter); // Conversor

                entity.Property(g => g.Price)
                    .HasColumnType("decimal(5, 2)")
                    .IsRequired();
            });
        }
    }
}
