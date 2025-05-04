using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.DTOs;
using ApplicationLayer.Interfaces;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewQuery;
using AutoMapper;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewHandler
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, OperationResult<ReviewDTO>>
    {
        private readonly IGenericRepository<Review> _repository;
        private readonly IMapper _mapper;

        public GetReviewByIdQueryHandler(IGenericRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<ReviewDTO>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetByIdAsync(request.Id);
            if (review == null)
            {
                return OperationResult<ReviewDTO>.Failure("Review not found.");
            }

            var dto = _mapper.Map<ReviewDTO>(review);
            return OperationResult<ReviewDTO>.Success(dto);
        }
    }
}
