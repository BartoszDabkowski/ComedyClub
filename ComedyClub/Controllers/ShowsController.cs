using ComedyClub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using ComedyClub.Core;
using ComedyClub.Core.Models;
using ComedyClub.Core.ViewModels;

namespace ComedyClub.Controllers
{
    public class ShowsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShowsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var shows = _unitOfWork.Shows.GetUpcomingShowsByComedian(userId);

            return View(shows);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new ShowsViewModel()
            {
                UpcomingShows = _unitOfWork.Shows.GetShowsUserAttending(userId),
                IsAuthenticated = User.Identity.IsAuthenticated,
                Heading = "Shows I'm Attending",
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(userId).ToLookup(a => a.ShowId)
            };

            return View("Shows", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ShowFormViewModel
            {
                Genres = _unitOfWork.Genres.GetGenres(),
                Heading = "Add Show"
            };

            return View("ShowForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("ShowForm", viewModel);
            }
                
            var show = new Show
            {
                ComedianId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.GenreId,
                Venue = viewModel.Venue
            };

            _unitOfWork.Shows.Add(show);
            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Shows");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var show = _unitOfWork.Shows.GetShow(id);

            if (show == null)
                return HttpNotFound();

            if(show.ComedianId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new ShowFormViewModel
            {
                Id = show.Id,
                Genres = _unitOfWork.Genres.GetGenres(),
                Date = show.DateTime.ToString("d MMM yyyy"),
                Time = show.DateTime.ToString("HH:mm"),
                GenreId = show.GenreId,
                Venue = show.Venue,
                Heading = "Edit Show"
            };

            return View("ShowForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ShowFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenres();
                return View("ShowForm", viewModel);
            }
            
            var show = _unitOfWork.Shows.GetShowWithAttendees(viewModel.Id);

            if(show == null)
                return HttpNotFound();

            if (show.ComedianId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            show.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.GenreId);

            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Shows");
        }

        public ActionResult Details(int id)
        {
            var show = _unitOfWork.Shows.GetShow(id);

            if (show == null)
                return HttpNotFound();

            var viewModel = new ShowDetailsViewModel { Show = show };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending =
                    _unitOfWork.Attendances.GetAttendance(show.Id, userId) != null;

                viewModel.IsFollowing =
                    _unitOfWork.Followings.GetFollowing(userId, show.ComedianId) != null;
            }

            return View("Details", viewModel);
        }

        [HttpPost]
        public ActionResult Search(ShowsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }
    }
}