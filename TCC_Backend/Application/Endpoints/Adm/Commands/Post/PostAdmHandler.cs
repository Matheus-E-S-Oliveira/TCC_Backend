using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IAdmRepositorys;

namespace TCC_Backend.Application.Endpoints.Adm.Commands.Post
{
    public class PostAdmHandler(IAdmRepository admRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(PostAdmRequest request)
        {
            var token = await admRepository.CheckAuth(request.Token);
            if (!token.IsTokenValid)
                return Error([token.Menssage], StatusCodes.Status401Unauthorized);

            var validate = await admRepository.Validar(request);

            if (validate.Count > 0)
                return Error(validate, StatusCodes.Status400BadRequest);

            var result = await admRepository.RegisterAdm(request);

            if (result > 0)
                return OkResponse(["Adm salvo com sucesso!"], StatusCodes.Status201Created);

            return Error(["Erro ao registra o adm"], StatusCodes.Status400BadRequest);
        }
    }
}
