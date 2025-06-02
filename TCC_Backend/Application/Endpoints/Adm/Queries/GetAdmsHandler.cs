using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.AdmDtos;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Endpoints.Adm.Queries
{
    public class GetAdmsHandler(TccBackendContext context) : BaseApiController
    {
        public async Task<IActionResult> Handle(GetAdmsRequest request)
        {
            var result = await context.Adms
                .Select(a => new AdmDto
                {
                    Id = a.Id,
                    UserName = a.UserName,
                    Email = a.Email
                })
                .ToListAsync();

            return Success(result);
        }
    }
}
