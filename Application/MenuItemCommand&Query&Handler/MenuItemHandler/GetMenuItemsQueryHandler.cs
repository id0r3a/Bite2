using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.MenuItemCommand_Query.MenuItemQuery;
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
    public class GetMenuItemsQueryHandler(IGenericRepository<MenuItem> repository, IMapper mapper) : IRequestHandler<GetMenuItemsQuery, OperationResult<IEnumerable<MenuItemDTO>>>
    {
        public async Task<OperationResult<IEnumerable<MenuItemDTO>>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var menuItems = await repository.GetAllAsync();
            var dtos = mapper.Map<IEnumerable<MenuItemDTO>>(menuItems);
            return OperationResult<IEnumerable<MenuItemDTO>>.Success(dtos);
        }
    }
}
