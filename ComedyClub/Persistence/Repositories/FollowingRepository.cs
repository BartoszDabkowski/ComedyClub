using ComedyClub.Core.Models;
using ComedyClub.Core.Repositories;
using System.Linq;

namespace ComedyClub.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, string comedianId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FolloweeId == comedianId && f.FollowerId == userId);
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}