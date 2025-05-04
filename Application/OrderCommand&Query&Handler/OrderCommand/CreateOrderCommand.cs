using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System.Collections.Generic;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderCommand
{
    public class CreateOrderCommand : IRequest<OperationResult<OrderDTO>>
    {
        public string Username { get; set; } = null!;
        public List<OrderItemCreateDTO> Items { get; set; } = new();

        public CreateOrderCommand(OrderCreateDTO dto)
        {
            Username = dto.Username;
            Items = dto.Items;
        }
    }
}
