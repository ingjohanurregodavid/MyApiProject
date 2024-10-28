using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.API.Commands;
using MyApiProject.API.Data;
using MyApiProject.API.Handlers.CommandHandlers;
using MyApiProject.API.Models;
using MyApiProject.API.Queries;

namespace MyApiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var productId=await _mediator.Send(command);
            return Ok( new { Message = "Producto creado exitosamente", ID = productId });
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetProductsQuery();
            var products = await _mediator.Send(query); 
            return Ok(products);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { Message= "Producto actualizado exitosamente" });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);
            await _mediator.Send(command);
            return Ok("Producto eliminado exitosamente");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdProductQuery(id);
            var product = await _mediator.Send(query);
            return Ok(product);
        }

    }
}
