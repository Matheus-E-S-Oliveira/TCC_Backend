using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario;

namespace TCC_Backend.Domain.Interfaces.IUsuarioRepositorys
{
    public interface IUsuarioRepository
    {
        Task<TokenDto> RegisterUsuario(RegisterUsuarioRequest request); 
    }
}
