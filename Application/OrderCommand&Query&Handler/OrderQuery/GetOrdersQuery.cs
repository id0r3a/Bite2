using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderQuery
{
    public class GetOrdersQuery : IRequest<OperationResult<IEnumerable<OrderDTO>>> { }
}
