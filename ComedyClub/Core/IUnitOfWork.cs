using ComedyClub.Core.Repositories;

namespace ComedyClub.Core
{
    public interface IUnitOfWork
    {
        IShowRepository Shows { get; }
        IAttendanceRepository Attendances { get; }
        IGenreRepository Genres { get; }
        IFollowingRepository Followings { get; }
        IApplicationUserRepository Users { get; }
        INotificationRepository Notifications { get; }
        IUserNotificationRepository UserNotifications { get; }
        void Complete();
    }
}