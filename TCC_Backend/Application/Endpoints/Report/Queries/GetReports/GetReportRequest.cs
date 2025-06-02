using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Report.Queries.GetReports
{
    public class GetReportRequest
    {
        [FromQuery]
        public int PageNumber { get; set; } = 1;

        [FromQuery]
        public int PageSize { get; set; } = 10;
    }
}
