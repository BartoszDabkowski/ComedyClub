using ComedyClub.Controllers.Api;
using ComedyClub.Core;
using ComedyClub.Core.Models;
using ComedyClub.Core.Repositories;
using ComedyClub.Tests.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace ComedyClub.Tests.Controllers.Api
{
    [TestClass]
    public class ShowsControllerTests
    {
        private ShowsController _controller;
        private Mock<IShowRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IShowRepository>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.SetupGet(u => u.Shows).Returns(_mockRepository.Object);

            _controller = new ShowsController(mockUnitOfWork.Object);
            _userId = "1";
            _controller.MockCurrentUser(_userId, "user1@domain.com");
        }

        [TestMethod]
        public void Cancel_NoShowWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_ShowIsCanceled_ShouldReturnNotFound()
        {
            var show = new Show();
            show.Cancel();

            _mockRepository.Setup(r => r.GetShowWithAttendees(1)).Returns(show);

            var result = _controller.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_UserCancelingAnotherUserShow_ShouldReturnUnauthorized()
        {
            var show = new Show() { ComedianId = _userId + "-" };

            _mockRepository.Setup(r => r.GetShowWithAttendees(1)).Returns(show);

            var result = _controller.Cancel(1);

            result.Should().BeOfType<UnauthorizedResult>();
        }

        [TestMethod]
        public void Cancel_ValidRequest_ShouldReturnOk()
        {
            var show = new Show() { ComedianId = _userId };

            _mockRepository.Setup(r => r.GetShowWithAttendees(1)).Returns(show);

            var result = _controller.Cancel(1);

            result.Should().BeOfType<OkResult>();
        }
    }
}
