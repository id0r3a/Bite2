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
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, OperationResult<MenuItemDTO>>
    {
        private readonly IGenericRepository<MenuItem> _menuItemRepository;
        private readonly IMapper _mapper;

        public CreateMenuItemCommandHandler(
            IGenericRepository<MenuItem> menuItemRepository,
            IMapper mapper)
        {
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<MenuItemDTO>> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            // Mappa DTO -> Entity
            var menuItem = _mapper.Map<MenuItem>(request.MenuItemDto);

            // Lägg till
            await _menuItemRepository.AddAsync(menuItem);
            await _menuItemRepository.SaveChangesAsync();

            // Mappa tillbaka till DTO
            var result = _mapper.Map<MenuItemDTO>(menuItem);

            return OperationResult<MenuItemDTO>.Success(result, "Menu item skapades!");
        }
    }
}
