using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQuery:IRequest<List<ProductListDto>>
    {
    }
}
