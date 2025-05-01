using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Entities;
using GameStore.CleanArch.Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GameStore.CleanArch.Backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await GetByIdAsync(id);

            game.IsEnabled = false;
            game.DeletedTimeUtc = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users.FindAsync(id);

        public async Task UpdateAsync(int id, User entity)
        {
            _context.Set<User>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedAt).IsModified = false;

            await _context.SaveChangesAsync();
        }
    }
}
