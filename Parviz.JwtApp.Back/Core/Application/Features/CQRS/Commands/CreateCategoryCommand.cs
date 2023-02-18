using MediatR;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommand:IRequest
    {
        public string? Definition { get; set; }
    }
}
