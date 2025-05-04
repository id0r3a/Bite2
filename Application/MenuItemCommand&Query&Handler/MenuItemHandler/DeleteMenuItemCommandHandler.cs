using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.MenuItemCommand_Query.MenuItemCommand;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.MenuItemCommand_Query.MenuItemHandler
{
    public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand, OperationResult>
    {
        private readonly IGenericRepository<MenuItem> _repository;

        public DeleteMenuItemCommandHandler(IGenericRepository<MenuItem> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
        {
            var menuItem = await _repository.GetByIdAsync(request.Id);
            if (menuItem == null)
            {
                return OperationResult.Failure("Menu item not found.");
            }

            await _repository.DeleteAsync(menuItem);
            await _repository.SaveChangesAsync();

            return OperationResult.Success("Menu item deleted successfully.");
        }
    }
}
