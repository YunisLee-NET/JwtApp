using MediatR;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class ProductDeleteCommand:IRequest
    {
        public int Id { get; set; }

        public ProductDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
