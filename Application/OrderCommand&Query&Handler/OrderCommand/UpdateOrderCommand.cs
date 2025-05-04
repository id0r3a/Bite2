using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.OrderCommand_Query_Handler.OrderCommand
{
    public class UpdateOrderCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
    }
}

