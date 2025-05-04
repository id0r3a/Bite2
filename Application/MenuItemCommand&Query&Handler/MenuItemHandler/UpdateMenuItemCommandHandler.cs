using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.MenuItemCommand_Query.MenuItemCommand;
using AutoMapper;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.MenuItemCommand_Query.MenuItemHandler
{
    public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, OperationResult<MenuItemDTO>>
    {
        private readonly IGenericRepository<MenuItem> _repository;
        private readonly IMapper _mapper;

        public UpdateMenuItemCommandHandler(IGenericRepository<MenuItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<MenuItemDTO>> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
        {
            // Hämta menyobjektet från databasen
            var menuItem = await _repository.GetByIdAsync(request.MenuItemId);
            if (menuItem == null)
            {
                return OperationResult<MenuItemDTO>.Failure("Menu item not found.");
            }

            // Uppdatera fält
            menuItem.Name = request.Name;
            menuItem.Price = request.Price;

            // Spara ändringar
            await _repository.UpdateAsync(menuItem);
            await _repository.SaveChangesAsync();

            // Mappa till DTO
            var dto = _mapper.Map<MenuItemDTO>(menuItem);
            return OperationResult<MenuItemDTO>.Success(dto, "Menu item updated successfully.");
        }
    }
}
