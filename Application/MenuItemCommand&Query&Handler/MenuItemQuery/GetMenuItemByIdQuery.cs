using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;

namespace ApplicationLayer.MenuItemCommand_Query_Handler.MenuItemQuery
{
    public class GetMenuItemByIdQuery : IRequest<OperationResult<MenuItemDTO>>
    {
        public int Id { get; set; }

        public GetMenuItemByIdQuery(int id)
        {
            Id = id;
        }

        public GetMenuItemByIdQuery() { }
    }
}
