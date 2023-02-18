using AutoMapper;
using Parviz.JwtApp.Back.Core.Application.Dtos;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Mappings
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
            this.CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        }
    }
}
