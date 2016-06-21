using AutoMapper;
using ComedyClub.Core;
using ComedyClub.Core.Dtos;
using ComedyClub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebGrease.Css.Extensions;

namespace ComedyClub.Controllers.Api
{
    //[Authorize]
    public class NotificationsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewEnumerable()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notifications.GetNewNotificationsFor(userId);

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notification = _unitOfWork.UserNotifications.GetUserNotificationsFor(userId);

            notification.ForEach(n => n.Read());

            _unitOfWork.Complete();

            return Ok();

        }

    }
}
