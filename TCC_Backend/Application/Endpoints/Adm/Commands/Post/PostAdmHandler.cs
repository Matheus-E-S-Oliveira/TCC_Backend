using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IAdmRepositorys;

namespace TCC_Backend.Application.Endpoints.Adm.Commands.Post
{
    public class PostAdmHandler(IAdmRepository admRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(PostAdmRequest request)
        {
            var result = await admRepository.RegisterAdm(request);

            if (result > 0)
                return OkResponse("Adm salvo com sucesso!", StatusCodes.Status201Created);

            return Error("Erro ao registra o adm", StatusCodes.Status400BadRequest);
        }
    }
}
