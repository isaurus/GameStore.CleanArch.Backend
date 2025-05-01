using GameStore.CleanArch.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GameStore.CleanArch.Backend.Infrastructure.Context.Mappings
{
    public class GameMapper : IEntityTypeConfiguration<Game>, IEntityMapping<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Conversor de DateOnly <-> DateTime
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d)
            );

            // Modificación de queries para borrado lógico
            builder.HasQueryFilter(a => a.IsEnabled);

            builder.ToTable("Game");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).ValueGeneratedOnAdd();

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(g => g.Release)
                .IsRequired()
                .HasConversion(dateOnlyConverter); // Conversor

            builder.Property(g => g.Price)
                .HasColumnType("decimal(5, 2)")
                .IsRequired();
        }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
