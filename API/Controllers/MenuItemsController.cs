using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.MenuItemCommand_Query.MenuItemCommand;
using ApplicationLayer.MenuItemCommand_Query.MenuItemQuery;
using ApplicationLayer.MenuItemCommand_Query_Handler.MenuItemQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetMenuItemsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/MenuItems/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetMenuItemByIdQuery(id));
            return Ok(result);
        }

        // POST: api/MenuItems
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateMenuItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/MenuItems/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMenuItemCommand command)
        {
            if (id != command.MenuItemId)
                return BadRequest("The provided ID does not match the command ID.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE: api/MenuItems/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteMenuItemCommand(id));
            return Ok(result);
        }
    }
}
