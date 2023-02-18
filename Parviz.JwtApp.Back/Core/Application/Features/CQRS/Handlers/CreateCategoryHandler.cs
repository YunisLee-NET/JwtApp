using MediatR;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepo;

        public CreateCategoryHandler(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepo.CreateAsync(new Category
            {
                Definition = request.Definition
            });
            return Unit.Value;
        }
    }
}
