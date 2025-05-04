using ApplicationLayer.DTOs.MediatR;
using MediatR;

namespace ApplicationLayer.MenuItemCommand_Query.MenuItemCommand
{
    public class DeleteMenuItemCommand : IRequest<OperationResult>
    {
        public int Id { get; }

        // Constructor som tar emot id
        public DeleteMenuItemCommand(int id)
        {
            Id = id;
        }
    }
}
