using MediatR;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CategoryDeleteHandler : IRequestHandler<CategoryDeleteCommand>
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoryDeleteHandler(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Unit> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var deletedCategory = await _categoryRepo.GetByIdAsync(request.Id);
            if (deletedCategory != null)
            {
                await _categoryRepo.RemoveAsync(deletedCategory);
            }
            return Unit.Value;
        }
    }
}
