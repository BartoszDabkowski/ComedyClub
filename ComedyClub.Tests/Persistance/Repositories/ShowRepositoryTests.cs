using ComedyClub.Core.Models;
using ComedyClub.Persistence;
using ComedyClub.Persistence.Repositories;
using ComedyClub.Tests.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;

namespace ComedyClub.Tests.Persistance.Repositories
{
    [TestClass]
    class ShowRepositoryTests
    {
        private ShowRepository _repository;
        private Mock<DbSet<Show>> _mockShows;

        [TestInitialize]
        public void ShowInitialize()
        {
            
            _mockShows = new Mock<DbSet<Show>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Shows).Returns(_mockShows.Object);

            //_repository = new ShowRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetUpcomingShowsByComedian_ShowIsInThePast_ShouldNotBeReturned()
        {
            var show = new Show() { DateTime = DateTime.Now.AddDays(-1) };

            _mockShows.SetSource(new[] { show });

            var shows = _repository.GetUpcomingShowsByComedian("1");

            shows.Should().BeEmpty();
        }
    }
}
