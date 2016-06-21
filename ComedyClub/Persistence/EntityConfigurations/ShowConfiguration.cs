using ComedyClub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace ComedyClub.Persistence.EntityConfigurations
{
    public class ShowConfiguration : EntityTypeConfiguration<Show>
    {
        public ShowConfiguration()
        {
            Property(s => s.ComedianId)
            .IsRequired();

            Property(s => s.GenreId)
                .IsRequired();

            Property(s => s.Venue)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(s => s.Attendances)
                .WithRequired(a => a.Show)
                .WillCascadeOnDelete(false);
        }
    }
}