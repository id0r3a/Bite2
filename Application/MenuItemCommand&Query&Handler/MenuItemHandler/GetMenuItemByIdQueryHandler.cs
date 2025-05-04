using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.DTOs;
using ApplicationLayer.Interfaces;
using ApplicationLayer.MenuItemCommand_Query_Handler.MenuItemQuery;
using AutoMapper;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.MenuItemCommand_Query_Handler.MenuItemHandler
{
    public class GetMenuItemByIdQueryHandler : IRequestHandler<GetMenuItemByIdQuery, OperationResult<MenuItemDTO>>
    {
        private readonly IGenericRepository<MenuItem> _repository;
        private readonly IMapper _mapper;

        public GetMenuItemByIdQueryHandler(IGenericRepository<MenuItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<MenuItemDTO>> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            var menuItem = await _repository.GetByIdAsync(request.Id);
            if (menuItem == null)
            {
                return OperationResult<MenuItemDTO>.Failure("Menu item not found.");
            }

            var dto = _mapper.Map<MenuItemDTO>(menuItem);
            return OperationResult<MenuItemDTO>.Success(dto, "Menu item retrieved successfully.");
        }
    }
}
