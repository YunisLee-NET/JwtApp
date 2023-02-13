using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetProductByIdQuery:IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
