using AutoMapper;
using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public GetAllCategoryHandler(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = await _categoryRepo.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(data);
        }
    }
}
