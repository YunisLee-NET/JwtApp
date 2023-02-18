using AutoMapper;
using MediatR;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public UpdateCategoryHandler(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var mappedData = _mapper.Map<Category>(request);
            await _categoryRepo.UpdateAsync(mappedData);
            return Unit.Value;
        }
    }
}
