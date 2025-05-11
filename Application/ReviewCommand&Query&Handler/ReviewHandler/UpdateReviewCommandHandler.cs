using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand;
using DomainLayer.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewHandler
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, OperationResult>
    {
        private readonly IGenericRepository<Review> _repository;

        public UpdateReviewCommandHandler(IGenericRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            // Hämta review från databasen baserat på ID
            var review = await _repository.GetByIdAsync(request.ReviewDto.ReviewId);
            if (review == null)
            {
                return OperationResult.Failure("Review not found.");
            }

            // Uppdatera fälten
            review.Rating = request.ReviewDto.Rating;
            review.Comment = request.ReviewDto.Comment;

            // Uppdatera i databasen
            await _repository.UpdateAsync(review);
            await _repository.SaveChangesAsync();

            return OperationResult.Success("Review updated successfully.");
        }
    }
}
