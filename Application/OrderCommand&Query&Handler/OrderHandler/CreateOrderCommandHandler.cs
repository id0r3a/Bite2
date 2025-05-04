using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.OrderCommand_Query_Handler.OrderCommand;
using AutoMapper;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderHandler
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OperationResult<OrderDTO>>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<MenuItem> _menuItemRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(
            IGenericRepository<Order> orderRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<MenuItem> menuItemRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OrderDTO>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Kontrollera att användaren finns
            var user = await _userRepository.Query().FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);
            if (user == null)
            {
                return OperationResult<OrderDTO>.Failure("Användaren hittades inte.");
            }

            // 2️⃣ Skapa Order + OrderItems
            var order = new Order
            {
                UserId = user.UserId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in request.Items)
            {
                var menuItem = await _menuItemRepository.GetByIdAsync(itemDto.MenuItemId);
                if (menuItem == null)
                {
                    return OperationResult<OrderDTO>.Failure($"Menyitem med ID {itemDto.MenuItemId} hittades inte.");
                }

                var orderItem = new OrderItem
                {
                    MenuItemId = menuItem.MenuItemId,
                    Quantity = itemDto.Quantity,
                    Price = menuItem.Price
                };

                order.OrderItems.Add(orderItem);
            }

            // 3️⃣ Räkna ut totalsumma
            order.TotalAmount = order.OrderItems.Sum(oi => oi.Price * oi.Quantity);

            // 4️⃣ Spara Order
            await _orderRepository.AddAsync(order);

            // 5️⃣ Mappa till DTO
            var orderDto = _mapper.Map<OrderDTO>(order);

            return OperationResult<OrderDTO>.Success(orderDto, "Order created successfully");
        }
    }
}
