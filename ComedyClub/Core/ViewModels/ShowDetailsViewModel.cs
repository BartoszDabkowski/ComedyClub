using ComedyClub.Core.Models;

namespace ComedyClub.Core.ViewModels
{
    public class ShowDetailsViewModel
    {
        public Show Show { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}