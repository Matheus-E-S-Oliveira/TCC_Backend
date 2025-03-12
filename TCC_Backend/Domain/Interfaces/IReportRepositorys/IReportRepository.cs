using TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport;

namespace TCC_Backend.Domain.Interfaces.IReportRepositorys
{
    public interface IReportRepository
    {
        Task<int> SaveReport(PostReportRequest request);
    }
}
