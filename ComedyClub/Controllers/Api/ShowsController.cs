using ComedyClub.Core;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace ComedyClub.Controllers.Api
{
    [Authorize]
    public class ShowsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShowsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var show = _unitOfWork.Shows.GetShowWithAttendees(id);

            if(show == null || show.IsCanceled)
                return NotFound();

            if(show.ComedianId != userId)
                return Unauthorized();

            show.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
