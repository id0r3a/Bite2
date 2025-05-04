using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.MenuItemCommand_Query.MenuItemQuery
{
    public class GetMenuItemsQuery : IRequest<OperationResult<IEnumerable<MenuItemDTO>>>
    {
    }
}
