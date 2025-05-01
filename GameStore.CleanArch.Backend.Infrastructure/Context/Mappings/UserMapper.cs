using GameStore.CleanArch.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.CleanArch.Backend.Infrastructure.Context.Mappings
{
    public class UserMapper : IEntityTypeConfiguration<User>, IEntityMapping<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            throw new NotImplementedException();
        }

        public void Configure(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
