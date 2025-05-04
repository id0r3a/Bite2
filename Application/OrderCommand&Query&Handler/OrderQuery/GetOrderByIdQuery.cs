using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderQuery
{
    public class GetOrderByIdQuery : IRequest<OperationResult<OrderDTO>>
    {
        public int Id { get; set; }
    }
}
