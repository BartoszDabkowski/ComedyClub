using ComedyClub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace ComedyClub.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new { a.ShowId, a.AttendeeId });
        }
    }
}