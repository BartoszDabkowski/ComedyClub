using System.Collections.Generic;
using ComedyClub.Core.Models;

namespace ComedyClub.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}