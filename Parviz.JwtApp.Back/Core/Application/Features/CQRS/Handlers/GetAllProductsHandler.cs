using AutoMapper;
using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var defaultdata = await _productRepo.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(defaultdata);
        }
    }
}
