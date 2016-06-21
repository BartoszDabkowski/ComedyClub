using ComedyClub.Core.Models;
using System.Data.Entity;

namespace ComedyClub.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Show> Shows { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<Following> Followings { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<UserNotification> UserNotifications { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
    }
}