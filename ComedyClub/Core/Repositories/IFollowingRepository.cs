using ComedyClub.Core.Models;

namespace ComedyClub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string comedianId);
        void Add(Following following);
        void Remove(Following following);
    }
}