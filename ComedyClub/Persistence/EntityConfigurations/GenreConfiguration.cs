using ComedyClub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace ComedyClub.Persistence.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}