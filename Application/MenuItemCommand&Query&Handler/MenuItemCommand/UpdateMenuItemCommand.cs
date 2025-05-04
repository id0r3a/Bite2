using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;

namespace ApplicationLayer.MenuItemCommand_Query.MenuItemCommand
{
    public class UpdateMenuItemCommand : IRequest<OperationResult<MenuItemDTO>>
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        // (Frivillig) Konstruktor för enklare initiering
        public UpdateMenuItemCommand(int menuitemid, string name, decimal price)
        {
            MenuItemId = menuitemid;
            Name = name;
            Price = price;
        }

        // Tom konstruktor om den behövs för ex. model binding
        public UpdateMenuItemCommand() { }
    }
}
