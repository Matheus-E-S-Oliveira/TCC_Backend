using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport
{
    public class PostReportRequest
    {
        [FromBody]
        public string ReportType { get; set; } = string.Empty;

        public string? ErrorCategory { get; set; } = string.Empty;

        public string? SuggestionCategory { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool WantsContact { get; set; }

        public string? ContactEmail { get; set; } = string.Empty;

        public int Rating { get; set; }
    }
}
