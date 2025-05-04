using ApplicationLayer.Interfaces;
using ApplicationLayer.MenuItemCommand_Query.MenuItemCommand;
using ApplicationLayer.MenuItemCommand_Query.MenuItemHandler;
using DomainLayer.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Tests.MenuItemHandlers
{
    public class CreateMenuItemCommandHandlerTests
    {
        [Test]
        public async Task Handle_Should_Create_MenuItem()
        {
            // Arrange
            var mockRepo = new Mock<IGenericRepository<MenuItem>>();
            var handler = new CreateMenuItemCommandHandler(mockRepo.Object);
            var command = new CreateMenuItemCommand { Name = "Pizza", Price = 120.0M };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.AddAsync(It.Is<MenuItem>(m =>
                m.Name == "Pizza" && m.Price == 120.0M)), Times.Once);
        }
    }
}
