using Microsoft.EntityFrameworkCore;

namespace GameStore.CleanArch.Backend.Infrastructure.Context.Mappings
{
    public interface IEntityMapping<T>
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
