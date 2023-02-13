using MediatR;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateProductCommand:IRequest
    {
        public string? Name { get; set; }
        public string? Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
