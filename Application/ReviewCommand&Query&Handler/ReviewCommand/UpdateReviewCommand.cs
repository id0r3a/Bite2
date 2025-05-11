using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand
{
    public class UpdateReviewCommand : IRequest<OperationResult>
    {
        public int ReviewId { get; set; }
        public ReviewDTO ReviewDto { get; set; }

        public UpdateReviewCommand(int reviewId, ReviewDTO reviewDto)
        {
            ReviewId = reviewId;
            ReviewDto = reviewDto;
        }

        //Glöm inte parameterlös konstruktor om du använder model binding
        public UpdateReviewCommand() { }
    }

}
