using ApplicationLayer.DTOs.MediatR;
using MediatR;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderCommand
{
    public class DeleteOrderCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        // Tom constructor om du behöver det
        public DeleteOrderCommand() { }
    }
}
