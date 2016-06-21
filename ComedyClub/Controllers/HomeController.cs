using ComedyClub.Core.ViewModels;
using ComedyClub.Persistence;
using ComedyClub.Persistence.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ComedyClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AttendanceRepository _attendanceRepository;

        public HomeController()
        {
            _context = new ApplicationDbContext();
            _attendanceRepository = new AttendanceRepository(_context);
        }

        public ActionResult Index(string query = null)
        {
            var upcomingShows = _context.Shows
                .Include(s => s.Comedian)
                .Include(s => s.Genre)
                .Where(s => s.DateTime > DateTime.Now && !s.IsCanceled);

            if (!String.IsNullOrWhiteSpace(query))
            {
                upcomingShows = upcomingShows
                    .Where(s =>
                        s.Comedian.Name.Contains(query) ||
                        s.Genre.Name.Contains(query) ||
                        s.Venue.Contains(query));
            }

            var userId = User.Identity.GetUserId();
            var attendances = _attendanceRepository.GetFutureAttendances(userId).ToLookup(a => a.ShowId);

            var viewModel = new ShowsViewModel
            {
                UpcomingShows = upcomingShows,
                IsAuthenticated = User.Identity.IsAuthenticated,
                Heading = "Upcoming Shows",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Shows", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}