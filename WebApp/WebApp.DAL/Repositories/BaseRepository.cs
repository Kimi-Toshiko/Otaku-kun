using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.DAL.Repositories
{
    public class BaseRepository
    {
        protected readonly AnimeDBContext _context;

        protected BaseRepository(AnimeDBContext context)
        {
            _context = context;
        }
    }
}
