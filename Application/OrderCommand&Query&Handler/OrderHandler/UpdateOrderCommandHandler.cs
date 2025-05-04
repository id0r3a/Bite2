using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.OrderCommand_Query_Handler.OrderCommand;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderHandler
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OperationResult>
    {
        private readonly IGenericRepository<Order> _repository;

        public UpdateOrderCommandHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);
            if (order == null)
            {
                return OperationResult.Failure("Order not found.");
            }

            order.Status = request.Status;
            await _repository.UpdateAsync(order);
            await _repository.SaveChangesAsync();

            return OperationResult.Success("Order updated successfully.");
        }
    }
}
