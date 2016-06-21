using ComedyClub.Core.Models;
using System.Collections.Generic;

namespace ComedyClub.Core.Repositories
{
    public interface IShowRepository
    {
        Show GetShowWithAttendees(int showId);
        IEnumerable<Show> GetShowsUserAttending(string userId);
        IEnumerable<Show> GetUpcomingShowsByComedian(string userId);
        IEnumerable<Show> GetUpcomingShows(string searchTerm = null);
        Show GetShow(int id);
        void Add(Show show);
    }
}