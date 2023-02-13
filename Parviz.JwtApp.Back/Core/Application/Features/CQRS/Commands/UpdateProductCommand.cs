using MediatR;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class UpdateProductCommand:IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
