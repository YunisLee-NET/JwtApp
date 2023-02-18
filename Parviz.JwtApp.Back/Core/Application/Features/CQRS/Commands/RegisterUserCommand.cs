using MediatR;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommand:IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
