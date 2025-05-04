using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewQuery
{
    public class GetReviewsQuery : IRequest<OperationResult<IEnumerable<ReviewDTO>>>
    {
    }
}
