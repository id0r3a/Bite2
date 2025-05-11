using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewHandler;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class CreateReviewCommandHandlerTest
    {
        private Mock<IGenericRepository<Review>> _reviewRepositoryMock = null!;
        private Mock<IGenericRepository<User>> _userRepositoryMock = null!;
        private Mock<IGenericRepository<Restaurant>> _restaurantRepositoryMock = null!;
        private CreateReviewCommandHandler _handler = null!;

        [SetUp]
        public void Setup()
        {
            // Mocka repositories
            _reviewRepositoryMock = new Mock<IGenericRepository<Review>>();
            _userRepositoryMock = new Mock<IGenericRepository<User>>();
            _restaurantRepositoryMock = new Mock<IGenericRepository<Restaurant>>();

            // Initiera handler med mocks
            _handler = new CreateReviewCommandHandler(
                _reviewRepositoryMock.Object,
                _userRepositoryMock.Object,
                _restaurantRepositoryMock.Object
            );
        }

        [Test]
        public async Task Handle_ShouldReturnSuccess_WhenValidReviewIsProvided()
        {
            // Arrange: skapa ett ReviewDTO
            var dto = new ReviewDTO
            {
                Rating = 5,
                Comment = "Väldigt god mat!",
                RestaurantName = "Pizza House"
            };

            // Skapa en användare och restaurang för att simulera att de finns i databasen
            var fakeUser = new User { UserId = 1, Username = "testuser" };
            var fakeRestaurant = new Restaurant { RestaurantId = 1, Name = "Pizza House" };

            // Mocka sökningar i repository
            _userRepositoryMock.Setup(r => r.Query().FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeUser);

            _restaurantRepositoryMock.Setup(r => r.Query().FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Restaurant, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeRestaurant);

            // Mocka AddAsync och SaveChangesAsync
            _reviewRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Review>())).Returns(Task.CompletedTask);
            _reviewRepositoryMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var command = new CreateReviewCommand(dto);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Message, Is.EqualTo("Review created successfully."));
        }
    }
}
