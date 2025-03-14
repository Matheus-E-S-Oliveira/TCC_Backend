using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.IUsuarioServicoAvaliacaoRepositorys;

namespace TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao
{
    public class PutAvaliacaoHandler(IAvaliacaoRepository avaliacaoRepository,
                                     IServicoRepository servicoRepository,
                                     IUsuarioServicoAvaliacaoRepository usuarioServicoAvaliacaoRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(Guid id, PutAvaliacaoRequest request)
        {
            var avaliacoes = await avaliacaoRepository.GetAvalicaoServicoById(id);

            if (avaliacoes.Count == 0) return Error(["Serviço não encontrado"], StatusCodes.Status404NotFound);
            if (request.Respostas == null) return Error(["Erro ao salvar a avaliação"], StatusCodes.Status400BadRequest);

            var validade = await avaliacaoRepository.CheckAuth(request.Token, id);
            
            if(validade.IsTokenValid)
                return Error([validade.Menssage], StatusCodes.Status400BadRequest);

            var result =  await avaliacaoRepository.UpdateAvalicaoService(avaliacoes, request.Respostas);

            if(result is string errorMenssage) 
                return Error([errorMenssage], StatusCodes.Status422UnprocessableEntity);

            if (result is int count && count > 0) {
                await servicoRepository.AtualizarNumeroAvaliacoes(id);
                await usuarioServicoAvaliacaoRepository.UpdateDataUltimaAvalicaoPorServico(validade.Id, id);
                return OkResponse(["Avaliação salva com sucesso!"], StatusCodes.Status200OK);
            }

            return HandleException();
        }
    }
}
