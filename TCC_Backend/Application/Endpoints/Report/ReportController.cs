using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport;
using TCC_Backend.Application.Endpoints.Servico.Commands.Post.PostServico;

namespace TCC_Backend.Application.Endpoints.Report
{
    public class ReportController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostReportRequest request)
        {
            return await Post<PostReportRequest, PostReportHandler>(request);
        }
    }
}
