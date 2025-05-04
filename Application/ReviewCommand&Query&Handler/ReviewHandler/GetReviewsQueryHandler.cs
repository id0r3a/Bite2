using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
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
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, OperationResult<IEnumerable<ReviewDTO>>>
    {
        private readonly IGenericRepository<Review> _repository;
        private readonly IMapper _mapper;

        public GetReviewsQueryHandler(IGenericRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<ReviewDTO>>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
            return OperationResult<IEnumerable<ReviewDTO>>.Success(dtos);
        }
    }
}
