using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;

namespace Parviz.JwtApp.Back.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alldata = await _mediator.Send(new GetAllProductsQuery());
            return Ok(alldata);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdData(int id)
        {
            var getIdData = await _mediator.Send(new GetProductByIdQuery(id));
            return getIdData == null ? Ok($"Id-si {id} olan data tapilmadi"): Ok(getIdData);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GetDelete(int id)
        {
            var deleteId = await _mediator.Send(new GetProductByIdQuery(id));

            if (deleteId != null)
            {
                var deletedata=await _mediator.Send(new ProductDeleteCommand(id));
                return Ok($"Id-si {id} olan melumat ugurla silindi");
            }
            else
            {
                return Ok($"Id-si {id} olan melumat tapilmadi");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var updateData= await _mediator.Send(command);
            return Ok(updateData);
        }
    }
}
