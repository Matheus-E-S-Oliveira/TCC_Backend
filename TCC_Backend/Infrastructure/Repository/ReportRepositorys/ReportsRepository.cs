using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth;
using TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport;
using TCC_Backend.Domain.Interfaces.IReportRepositorys;
using TCC_Backend.Domain.Models.Reports;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Validators.Report.Post;

namespace TCC_Backend.Infrastructure.Repository.ReportRepositorys
{
    public class ReportsRepository(TccBackendContext context, ReportValidator validations) : IReportRepository
    {
        public async Task<int> SaveReport(PostReportRequest request)
        {
            var newReport = new Report(
                reportType: request.ReportType,
                errorCategory: request.ErrorCategory ?? string.Empty,
                suggestionCategory: request.SuggestionCategory ?? string.Empty,
                description: request.Description,
                wantsContact: request.WantsContact,
                contactEmail: request.ContactEmail,
                rating: request.Rating
                );

            await context.AddAsync( newReport );

            return await context.SaveChangesAsync();
        }
        public Task<List<string>> Validar(PostReportRequest request)
        {
            var validate = validations.Validate(request);

            return Task.FromResult(validate.Errors.Select(erro => erro.ErrorMessage).ToList());
        }
    }
}
