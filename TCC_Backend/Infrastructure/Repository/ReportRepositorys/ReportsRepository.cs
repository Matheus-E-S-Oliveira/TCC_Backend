using TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport;
using TCC_Backend.Domain.Interfaces.IReportRepositorys;
using TCC_Backend.Domain.Models.Reports;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.ReportRepositorys
{
    public class ReportsRepository(TccBackendContext context) : IReportRepository
    {
        public async Task<int> SaveReport(PostReportRequest request)
        {
            var newReport = new Report(
                reportType: request.ReportType,
                errorCategory: request.ErrorCategory,
                suggestionCategory: request.SuggestionCategory,
                description: request.Description,
                wantsContact: request.WantsContact,
                contactEmail: request.ContactEmail,
                rating: request.Rating
                );

            await context.AddAsync( newReport );

            return await context.SaveChangesAsync();
        }
    }
}
