using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Parviz.JwtApp.Back.Infrastucture.Tools;
using System.IdentityModel.Tokens.Jwt;

namespace Parviz.JwtApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return Ok($"{command.Username} adli istifadeci ugurla qeydiyyatdan kecdi");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQuery request)
        {
            var dto=await _mediator.Send(request);
            if (dto.IsExist)
            {
                
                return Created("token: ", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Istifadeci adi ve ya shifr yalnisdir");
            }
        }
    }
}
