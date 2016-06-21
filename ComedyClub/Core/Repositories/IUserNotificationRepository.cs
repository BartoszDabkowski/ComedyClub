using ComedyClub.Core.Models;
using System.Collections.Generic;

namespace ComedyClub.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotificationsFor(string userId);
    }
}