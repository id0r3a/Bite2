using ApplicationLayer.DTOs;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/reviews
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetReviewsQuery());
            return Ok(result);
        }

        // POST: api/reviews
        [HttpPost]
        [Authorize] // Lägg gärna till roll-baserad auth om du vill begränsa det
        public async Task<IActionResult> Create([FromBody] ReviewDTO reviewDto)
        {
            var command = new CreateReviewCommand(reviewDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/reviews/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] ReviewDTO reviewDto)
        {
            var command = new UpdateReviewCommand(id, reviewDto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE: api/reviews/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Exempel: endast Admin får ta bort
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteReviewCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
