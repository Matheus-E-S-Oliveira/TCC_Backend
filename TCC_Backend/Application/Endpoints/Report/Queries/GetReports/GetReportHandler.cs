using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Endpoints.Report.Queries.GetReports
{
    public class GetReportHandler(TccBackendContext context) : BaseApiController
    {
        public async Task<IActionResult> Handle(GetReportRequest request)
        {
            var totalItems = await context.Reports.CountAsync();

            var items = await context.Reports
                .AsNoTracking()
                .OrderByDescending(x => x.DataCriacao)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var result = new PaginatedResult<TCC_Backend.Domain.Models.Reports.Report>
            {
                Page = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalItems,
                Items = items
            };

            return Success(result);
        }
    }

    public class PaginatedResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; } = [];
    }

}
