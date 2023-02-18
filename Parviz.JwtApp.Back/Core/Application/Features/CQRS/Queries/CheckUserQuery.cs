using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQuery:IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
