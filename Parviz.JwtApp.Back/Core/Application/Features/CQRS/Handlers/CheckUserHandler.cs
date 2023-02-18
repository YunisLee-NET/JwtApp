using MediatR;
using Parviz.JwtApp.Back.Core.Application.Dtos;
using Parviz.JwtApp.Back.Core.Application.Features.CQRS.Queries;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Domain;

namespace Parviz.JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserHandler : IRequestHandler<CheckUserQuery, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _appUserRepo;
        private readonly IRepository<AppRole> _appRoleRepo;

        public CheckUserHandler(IRepository<AppUser> appUserRepo, IRepository<AppRole> appRoleRepo)
        {
            _appUserRepo = appUserRepo;
            _appRoleRepo = appRoleRepo;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();

            var user = await _appUserRepo.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Username = user.Username;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await _appRoleRepo.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
