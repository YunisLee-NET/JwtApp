using MediatR;
using Parviz.JwtApp.Back.Core.Application.Enums;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Commands;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IRepository<AppUser> _appUserRepo;

        public RegisterUserHandler(IRepository<AppUser> appUserRepo)
        {
            _appUserRepo = appUserRepo;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _appUserRepo.CreateAsync(new AppUser()
            {
                Username = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member
            });
            return Unit.Value;
        }
    }
}
