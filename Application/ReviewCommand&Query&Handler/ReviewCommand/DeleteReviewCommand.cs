using ApplicationLayer.DTOs.MediatR;
using MediatR;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand
{
    public class DeleteReviewCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }

        public DeleteReviewCommand(int id)
        {
            Id = id;
        }

        public DeleteReviewCommand() { }
    }
}
