using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IPerguntasRepositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;

namespace TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico
{
    public class PutServicoHandler(IServicoRepository servicoRepository, IPerguntasRepository perguntasRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(Guid id, PutServicoRequest request)
        {
            var validate = await servicoRepository.Validar(request);
            if (validate.Count > 0)
                return Error(validate, StatusCodes.Status400BadRequest);

            var result = await servicoRepository.UpdateServico(id, request);

            if (result > 0)
            {
                var perguntaResult = await perguntasRepository.UpdatePergunta(id, request.Perguntas);

                if (perguntaResult > 0)
                {
                    return OkResponse(["Serviço atualizado com sucesso!"], StatusCodes.Status200OK);
                }

                return Error(
                    ["Serviço atualizado com sucesso, mas ocorreu um erro ao atualizar as perguntas. Tente novamente mais tarde."],
                    StatusCodes.Status200OK
                );
            }

            return Error(["Erro ao atualizar o serviço."], StatusCodes.Status400BadRequest);
        }
    }
}