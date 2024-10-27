using AutoMapper;
using MockQueryable;
using Moq;
using Xunit;

using Modules.Events.Core.Models;
using Modules.Events.Core.Services;
using Modules.Events.Core.UnitTest.FakeData;
using Modules.Events.Data.Entities;
using Modules.Events.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;
using Ticketing.Shared.Infrastructure.Cache;

namespace Modules.Events.Core.UnitTest
{
    public class ActivityServiceTests
    {
        private readonly Mock<IRepository<Activity, EventsDBContext>> _repositoryMock;
        private readonly IQueryable<Activity> _activities;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ICacheService> _cacheMock;

        public ActivityServiceTests()
        {
            _activities = FakeActivities.CreateFakeActivities();
            _repositoryMock = new Mock<IRepository<Activity, EventsDBContext>>();
            _mapperMock = new Mock<IMapper>();
            _cacheMock = new Mock<ICacheService>();

            ConfigureMocks();
        }

        [Fact]
        public async Task GetActivities_Should_ReturnAllActivities()
        {
            // Arrange
            var sut = new ActivityService(_repositoryMock.Object, _mapperMock.Object, _cacheMock.Object);

            // Act
            var actualResult = await sut.GetActivitiesAsync();
            //TODO: ask about this test and _mapperMock.Setup. This is fragile.

            // Asser
            Assert.Equal(_activities.Count(), actualResult.Count());
        }

        [Fact]
        public async Task GetActivities_Should_ReturnActivitiesAsDto()
        {
            // Arrange
            var sut = new ActivityService(_repositoryMock.Object, _mapperMock.Object, _cacheMock.Object);

            // Act
            var actualResult = await sut.GetActivitiesAsync();
            //TODO: ask about this test. This is useless.

            // Asser
            Assert.IsAssignableFrom<IList<ViewActivityDto>>(actualResult);
        }

        [Theory]
        [InlineData("ff99afbd-c379-4ba0-910b-3c4849192a5f", "4b8a3fc3-e9dc-4e56-a1ba-4e5d092192a5")]
        [InlineData("ee970046-3124-4e9b-83c6-002b24d8eea4", "ca18cd32-7706-4b23-896c-ebfd5ca6ab80")]
        public async Task GetSeats_Should_ThrowException_WhenActivityIdDoesNotExist(string activityGuidId, string sectionGuidId)
        {
            // Arrange
            var activityId = new Guid(activityGuidId);
            var sectionId = new Guid(sectionGuidId);
            var sut = new ActivityService(_repositoryMock.Object, _mapperMock.Object, _cacheMock.Object);

            // Act - Asser
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => sut.GetSeatsAsync(activityId, sectionId));
        }

        [Theory]
        [InlineData("cc99afbd-c379-4ba0-910b-3c4849192a5c", "1fc2fc05-6fa0-4672-ab9f-cd0662282532")]
        public async Task GetSeats_Should_ReturnSeat(string activityGuidId, string sectionGuidId)
        {
            // Arrange
            var activityId = new Guid(activityGuidId);
            var sectionId = new Guid(sectionGuidId);
            var sut = new ActivityService(_repositoryMock.Object, _mapperMock.Object, _cacheMock.Object);

            var expectedResult = _activities.Where(activity => activity.Id == activityId)
                .SelectMany(activity => activity.ActivitySeats)
                .Where(activitySeat => activitySeat.Seat.Row.SectionId == sectionId);

            // Act
            var result = await sut.GetSeatsAsync(activityId, sectionId);

            // Asser
            //TODO: ask about this test and _repositoryMock.Setup. This is fragile.
            Assert.Equal(expectedResult.Count(), result.Count);
        }

        private void ConfigureMocks()
        {
            _repositoryMock.Setup(r => r.Query()).Returns(_activities.BuildMock());
            _repositoryMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(_activities.ToList());
            _repositoryMock.Setup(r => r.GetByIdAsync(It.Is<Guid>(i => i != Guid.Empty), default))
                .Returns((Guid id, CancellationToken token) => Task.FromResult(_activities.FirstOrDefault(a => a.Id == id)));

            _mapperMock.Setup(m => m.Map<IList<ViewActivityDto>>(It.IsAny<IList<Activity>>()))
                .Returns((IList<Activity> activities) => activities
                    .Select(a => new ViewActivityDto { Id = a.Id }).ToList());
        }
    }
}
