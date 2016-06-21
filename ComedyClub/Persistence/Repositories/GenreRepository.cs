using ComedyClub.Core.Models;
using ComedyClub.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ComedyClub.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}