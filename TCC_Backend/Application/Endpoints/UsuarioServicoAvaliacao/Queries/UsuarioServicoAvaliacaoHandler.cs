using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IUsuarioServicoAvaliacaoRepositorys;

namespace TCC_Backend.Application.Endpoints.UsuarioServicoAvaliacao.Queries
{
    public class UsuarioServicoAvaliacaoHandler(IUsuarioServicoAvaliacaoRepository usuarioServicoAvaliacaoRepositorys) : BaseApiController
    {
        public async Task<IActionResult> Handle(UsuarioServicoAvaliacaoRequest request)
        {
            var result = await usuarioServicoAvaliacaoRepositorys.ListUlitmaAvaliacaoUser(request.Id);

            return Success(result);
        }
    }
}
