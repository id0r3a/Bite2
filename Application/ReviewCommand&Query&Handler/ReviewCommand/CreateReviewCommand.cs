using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand
{
    public class CreateReviewCommand : IRequest<OperationResult<ReviewDTO>>
    {
        public ReviewDTO ReviewDto { get; set; }

        public CreateReviewCommand(ReviewDTO dto)
        {
            ReviewDto = dto;
        }
    }
}
