using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewQuery
{
    public class GetReviewByIdQuery : IRequest<OperationResult<ReviewDTO>>
    {
        public int Id { get; set; }
    }
}
