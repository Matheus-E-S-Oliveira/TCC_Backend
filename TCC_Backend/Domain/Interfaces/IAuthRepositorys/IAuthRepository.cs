using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm;

namespace TCC_Backend.Domain.Interfaces.IAuthRepositorys
{
    public interface IAuthRepository
    {
        Task<TokenDto> Login(PostAuthRequest request);

        Task<TokenDto> LoginAdm(PostAuthAdmRequest request);
    }
}
