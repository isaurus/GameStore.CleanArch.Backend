using GameStore.CleanArch.Backend.Domain.Contracts.Repositories;
using GameStore.CleanArch.Backend.Domain.Entities;
using GameStore.CleanArch.Backend.Domain.Models;
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

        public async Task<OkResponseModel> AddAsync(Game entity)
        {
            await _context.Games.AddAsync(entity);
            var test = await _context.SaveChangesAsync();

            return new OkResponseModel
            {
                Id = test,
                Message = "Juego creado con éxito."
            };
        }

        public async Task UpdateAsync(Game entity)
        {
            _context.Games.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Game entity)
        {
            _context.Games.Remove(entity);
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
