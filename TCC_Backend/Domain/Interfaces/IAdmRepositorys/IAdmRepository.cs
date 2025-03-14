using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Dtos.TokenValidationDtos;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;

namespace TCC_Backend.Domain.Interfaces.IAdmRepositorys
{
    public interface IAdmRepository
    {
        Task<int> RegisterAdm(PostAdmRequest request);

        Task<List<string>> Validar(PostAdmRequest request);

        Task<bool> UserEmailExist(string email);

        Task<bool> UserNameExists(string userName);

        Task<TokenValidationDto> CheckAuth(string token);

    }
}
