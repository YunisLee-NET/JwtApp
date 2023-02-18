using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryByIdQuery:IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
