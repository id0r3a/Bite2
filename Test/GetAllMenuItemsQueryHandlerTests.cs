using NUnit.Framework;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationLayer.MenuItemCommand_Query_Handler.MenuItemHandler;
using ApplicationLayer.MenuItemCommand_Query.MenuItemHandler;
using InfrastructureLayer.Repositories;
using DomainLayer.Models;
using System.Collections.Generic;
using ApplicationLayer.Interfaces;
using ApplicationLayer.MenuItemCommand_Query.MenuItemQuery;
using AutoMapper;
using ApplicationLayer.DTOs;

namespace Test
{
    public class GetAllMenuItemsQueryHandlerTests
    {
        [Test]
        public async Task Handle_Should_Return_AllMenuItems()
        {
            // Arrange
            var mockRepo = new Mock<IGenericRepository<MenuItem>>();
            var menuItems = new List<MenuItem>
            {
                new MenuItem { MenuItemId = 1, Name = "Pizza", Price = 120 },
                new MenuItem { MenuItemId = 2, Name = "Burger", Price = 90 }
            };

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(menuItems);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<MenuItemDTO>>(It.IsAny<IEnumerable<MenuItem>>()))
                      .Returns(menuItems.Select(mi => new MenuItemDTO { MenuItemId = mi.MenuItemId, Name = mi.Name, Price = mi.Price }));

            var handler = new GetMenuItemsQueryHandler(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await handler.Handle(new GetMenuItemsQuery(), CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Count(), Is.EqualTo(2));
            Assert.That(result.Data, Has.Some.Matches<MenuItemDTO>(m => m.Name == "Pizza"));
        }

    }
}
