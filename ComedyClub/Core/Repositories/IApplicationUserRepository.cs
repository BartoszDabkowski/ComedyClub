using ComedyClub.Core.Models;
using System.Collections.Generic;

namespace ComedyClub.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetArtistsFollowedBy(string userId);
    }
}