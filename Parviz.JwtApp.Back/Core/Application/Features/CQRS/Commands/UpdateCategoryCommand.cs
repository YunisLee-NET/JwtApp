using MediatR;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
