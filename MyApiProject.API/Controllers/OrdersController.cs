using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.API.Commands;
using MyApiProject.API.Queries;

namespace MyApiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var Order = await _mediator.Send(command);
            return Ok(Order);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetOrdersQuery();
            var Orders = await _mediator.Send(query);
            return Ok(Orders);
        }
    }
}
