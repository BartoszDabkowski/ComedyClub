using ComedyClub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace ComedyClub.Persistence.EntityConfigurations
{
    public class FollowingConfiguration : EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {
            HasKey(f => new { f.FollowerId, f.FolloweeId });
        }
    }
}