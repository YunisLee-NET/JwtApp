using AutoMapper;
using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductListDto>
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var defaultdata = await _productRepo.GetByIdAsync(request.Id);
            return _mapper.Map<ProductListDto>(defaultdata);
        }
    }
}
