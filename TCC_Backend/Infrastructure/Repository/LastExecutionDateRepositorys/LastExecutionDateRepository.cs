using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Interfaces.ILastExecutionDateRepositorys;
using TCC_Backend.Domain.Models.LastExecutions;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.LastExecutionDateRepositorys
{
    public class LastExecutionDateRepository(TccBackendContext context) : ILastExecutionDateRepository
    {
        public async Task<DateTime?> GetLastExecutionDateAsync()
        {
            return await context.LastExecutions
                .Select(date => date.LastExecutionDate)
                .FirstOrDefaultAsync();
        }

        public async Task SaveExecutionDateAsync(DateTime date)
        {
            var lastExecution = await context.LastExecutions.FirstOrDefaultAsync();

            if (lastExecution == null) 
            {
                var newExecution = new LastExecution (date);
                context.LastExecutions.Add(newExecution);
            }
            else
            { 
                lastExecution.Update(lastExecutionDate: date);
            }

            await context.SaveChangesAsync();
        }
    }
}
