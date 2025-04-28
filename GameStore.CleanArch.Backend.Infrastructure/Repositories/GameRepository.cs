using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Entities;
using GameStore.CleanArch.Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GameStore.CleanArch.Backend.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync() =>
            await _context.Games.ToListAsync();

        public async Task<Game?> GetByIdAsync(int id) =>
            await _context.Games.FindAsync(id);

        public async Task AddAsync(Game entity)    
        {
            await _context.Games.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Game entity)
        {
            _context.Set<Game>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreatedAt).IsModified = false;

            await _context.SaveChangesAsync();          
        }

        public async Task DeleteAsync(int id)       // CREAR CONDICIÓN IF PARA BORRAR REAL O NO (VIENE DE SERVICIO)
        {
            var game = await  GetByIdAsync(id);

            game.IsEnabled = false;
            game.DeletedTimeUtc = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetByTitleAsync(string title)
        {
            return await _context.Games
                .Where(g => g.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetByReleaseYearAsync(int year)
        {
            return await _context.Games
                .Where(g => g.Release.Year == year)
                .ToListAsync();
        }
    }

}
