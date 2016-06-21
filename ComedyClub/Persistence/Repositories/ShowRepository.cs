using ComedyClub.Core.Models;
using ComedyClub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ComedyClub.Persistence.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Show GetShowWithAttendees(int showId)
        {
            return _context.Shows
                .Include(s => Enumerable.Select<Attendance, ApplicationUser>(s.Attendances, a => a.Attendee))
                .SingleOrDefault(s => s.Id == showId);
        }

        public IEnumerable<Show> GetShowsUserAttending(string userId)
        {
            return _context.Attendances.Where(a => a.AttendeeId == userId)
                .Select(a => a.Show)
                .Include(c => c.Comedian)
                .Include(g => g.Genre)
                .ToList();
        }

        public IEnumerable<Show> GetUpcomingShowsByComedian(string userId)
        {
            return _context.Shows
                .Where(s =>
                    s.ComedianId == userId &&
                    s.DateTime > DateTime.Now &&
                    !s.IsCanceled)
                .Include(g => g.Genre)
                .ToList();
        }

        public Show GetShow(int id)
        {
            return _context.Shows
                .Include(s => s.Comedian)
                .Include(s => s.Genre)
                .SingleOrDefault(s => s.Id == id);
        }

        public void Add(Show show)
        {
            _context.Shows.Add(show);
        }

        public IEnumerable<Show> GetUpcomingShows(string searchTerm = null)
        {
            var upcomingGigs = _context.Shows
                .Include(g => g.Comedian)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

            if (!String.IsNullOrWhiteSpace(searchTerm))
            {
                upcomingGigs = upcomingGigs
                    .Where(g =>
                            g.Comedian.Name.Contains(searchTerm) ||
                            g.Genre.Name.Contains(searchTerm) ||
                            g.Venue.Contains(searchTerm));
            }

            return upcomingGigs.ToList();
        }
    }
}