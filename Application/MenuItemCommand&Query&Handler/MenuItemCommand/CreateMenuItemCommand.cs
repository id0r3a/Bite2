using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.MenuItemCommand_Query.MenuItemCommand
{
    public class CreateMenuItemCommand : IRequest<OperationResult<MenuItemDTO>>
    {
        public MenuItemDTO MenuItemDto { get; set; }

        public CreateMenuItemCommand(MenuItemDTO dto)
        {
            MenuItemDto = dto;
        }
    }
}
