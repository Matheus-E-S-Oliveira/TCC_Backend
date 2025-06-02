using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport;
using TCC_Backend.Application.Endpoints.Report.Queries.GetReports;

namespace TCC_Backend.Application.Endpoints.Report
{
    public class ReportController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetReportRequest request)
        {
            return await Get<GetReportRequest, GetReportHandler>(request);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostReportRequest request)
        {
            return await Post<PostReportRequest, PostReportHandler>(request);
        }
    }
}
