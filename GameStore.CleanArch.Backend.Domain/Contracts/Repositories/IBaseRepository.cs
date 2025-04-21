using GameStore.CleanArch.Backend.Domain.Models;

namespace GameStore.CleanArch.Backend.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<OkResponseModel> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
