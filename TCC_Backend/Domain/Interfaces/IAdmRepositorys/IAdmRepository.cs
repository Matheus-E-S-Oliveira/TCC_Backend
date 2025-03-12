using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;

namespace TCC_Backend.Domain.Interfaces.IAdmRepositorys
{
    public interface IAdmRepository
    {
        Task<int> RegisterAdm(PostAdmRequest request);
    }
}
