using AutoMapper;
using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryListDto>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var dataId= await _categoryRepo.GetByIdAsync(request.Id);
            return _mapper.Map<CategoryListDto>(dataId);
        }
    }
}
