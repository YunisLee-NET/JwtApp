using MediatR;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class ProductDeleteHandler : IRequestHandler<ProductDeleteCommand>
    {
        private readonly IRepository<Product> _productRepo;

        public ProductDeleteHandler(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Unit> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var getid = await _productRepo.GetByIdAsync(request.Id);
            if (getid != null)
            {
                await _productRepo.RemoveAsync(getid);
            }
            return Unit.Value;
        }
    }
}
