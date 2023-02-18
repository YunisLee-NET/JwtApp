using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;

namespace Parviz.JwtApp.Back.Controllers
{
    [Authorize(Roles ="Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("Bele bir melumat tapilmadi");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok("Yeni kateqoriya ugurla elave edildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var delete = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (delete != null)
            {
                var data = await _mediator.Send(new CategoryDeleteCommand(id));
                return Ok("Kateqoriya ugurla silindi");
            }
            else
            {
                return Ok("Bele bir kateqoriya tapilmadi");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var update = await _mediator.Send(command);
            return Ok(update);
        }
    }
}
