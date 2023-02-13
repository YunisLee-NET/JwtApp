using AutoMapper;
using MediatR;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //var checkId = await _productRepo.GetByIdAsync(request.Id);

            var mappeddata = _mapper.Map<Product>(request);
            await _productRepo.UpdateAsync(mappeddata);


            return Unit.Value;
        }
    }
}
