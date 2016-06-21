using ComedyClub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace ComedyClub.Persistence.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Show);
        }
    }
}