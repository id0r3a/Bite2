using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.DTOs;
using ApplicationLayer.Interfaces;
using ApplicationLayer.OrderCommand_Query_Handler.OrderQuery;
using AutoMapper;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderHandler
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OperationResult<OrderDTO>>
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IGenericRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<OrderDTO>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);
            if (order == null)
            {
                return OperationResult<OrderDTO>.Failure("Order not found.");
            }

            var dto = _mapper.Map<OrderDTO>(order);
            return OperationResult<OrderDTO>.Success(dto);
        }
    }
}
