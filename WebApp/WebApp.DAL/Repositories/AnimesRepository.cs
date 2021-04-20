using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.DBO;

namespace WebApp.DAL.Repositories
{
    public class AnimesRepository : BaseRepository, IRepository<Anime>
    {
        public AnimesRepository(AnimeDBContext context)
            : base(context)
        {
        }

        public async Task CreateAsync(Anime entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Anime.Any(a => a.ID == id);
        }

        public async Task<List<Anime>> GetAllAsync()
        {
            return await _context.Anime.Include(a => a.Status).ToListAsync();
        }

        public async Task<Anime> GetByIdAsync(int id)
        {
            return await _context.Anime
               .Include(a => a.Status)
               .FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task UpdateAsync(Anime entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
