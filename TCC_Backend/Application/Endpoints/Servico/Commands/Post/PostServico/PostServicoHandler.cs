using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IPerguntasRepositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;

namespace TCC_Backend.Application.Endpoints.Servico.Commands.Post.PostServico
{
    public class PostServicoHandler(IServicoRepository servicoRepository, IPerguntasRepository perguntasRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(PostServicoRequest request)
        {
            var validate = await servicoRepository.Validar(request);
            if (validate.Count > 0)
                return Error(validate, StatusCodes.Status400BadRequest);

            var result = await servicoRepository.SaveServico(request);

            if (result is not null)
            {
                var perguntaResult = await perguntasRepository.SavePergunta(result.Value, request.Perguntas);

                if (perguntaResult > 0)
                {
                    return OkResponse(["Serviço salvo com sucesso!"], StatusCodes.Status200OK);
                }
                return Error(["Serviço salvo com sucesso, mas ocorreu um erro ao salvar as perguntas, tente novamnete mais tarde"], StatusCodes.Status200OK);
            }

            return Error(["Erro ao salvar o serviço"], StatusCodes.Status400BadRequest);
        }
    }
}
