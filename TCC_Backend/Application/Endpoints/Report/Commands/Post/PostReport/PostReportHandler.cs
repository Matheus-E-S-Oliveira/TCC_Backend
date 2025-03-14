using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IReportRepositorys;

namespace TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport
{
    public class PostReportHandler(IReportRepository reportRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(PostReportRequest request)
        {
            var validate = reportRepository.Validar(request);
            if(validate.Result.Count > 0)
                return Error(validate.Result, StatusCodes.Status400BadRequest);

            var result = await reportRepository.SaveReport(request);

            if (result > 0)
                return OkResponse(["Relatório enviado com sucesso!"], StatusCodes.Status200OK);

            return Error(["Erro ao enviar relatório"], StatusCodes.Status400BadRequest);
        }
    }
}
