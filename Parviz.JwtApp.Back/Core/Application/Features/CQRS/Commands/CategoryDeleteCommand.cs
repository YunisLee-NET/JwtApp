using MediatR;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands
{
    public class CategoryDeleteCommand:IRequest
    {
        public int Id { get; set; }

        public CategoryDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
