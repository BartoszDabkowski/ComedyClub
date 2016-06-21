using System.Collections.Generic;
using System.Linq;
using ComedyClub.Core.Models;

namespace ComedyClub.Core.ViewModels
{
    public class ShowsViewModel
    {
        public IEnumerable<Show> UpcomingShows { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
    }
}