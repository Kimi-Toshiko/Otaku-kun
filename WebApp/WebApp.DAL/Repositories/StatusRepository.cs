using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.DBO;

namespace WebApp.DAL.Repositories
{
    public class StatusRepository : BaseRepository, IRepository<Status>
    {
        public StatusRepository(AnimeDBContext context)
            : base(context)
        {
        }

        public async Task CreateAsync(Status entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var status = await _context.AnimeStatus.FindAsync(id);
            _context.AnimeStatus.Remove(status);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.AnimeStatus.Any(e => e.ID == id);
        }

        public async Task<List<Status>> GetAllAsync()
        {
            return await _context.AnimeStatus.ToListAsync();
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            return await _context.AnimeStatus
                .FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task UpdateAsync(Status entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
