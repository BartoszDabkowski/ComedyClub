using ComedyClub.Core.Models;
using System.Collections.Generic;

namespace ComedyClub.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotificationsFor(string userId);
    }
}