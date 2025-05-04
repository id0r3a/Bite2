using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewHandler
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, OperationResult>
    {
        private readonly IGenericRepository<Review> _repository;

        public DeleteReviewCommandHandler(IGenericRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetByIdAsync(request.Id);
            if (review == null)
            {
                return OperationResult.Failure("Review not found.");
            }

            await _repository.DeleteAsync(review);
            await _repository.SaveChangesAsync();

            return OperationResult.Success("Review deleted successfully.");
        }
    }
}
