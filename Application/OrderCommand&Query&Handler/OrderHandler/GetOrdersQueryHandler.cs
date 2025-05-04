using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
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

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderHandler
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, OperationResult<IEnumerable<OrderDTO>>>
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IGenericRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<OrderDTO>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return OperationResult<IEnumerable<OrderDTO>>.Success(dtos);
        }
    }
}
