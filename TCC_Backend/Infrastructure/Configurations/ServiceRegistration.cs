using TCC_Backend.Application.Interfaces.IHistoricoService;
using TCC_Backend.Application.Interfaces.IServicoBackgroundServices;
using TCC_Backend.Application.Services.HistoricoServices;
using TCC_Backend.Application.Services.ServicoBackgroundServices;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.IHistorioRepositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Domain.UnitOfWorks;
using TCC_Backend.Infrastructure.Repository.AvaliacaoRepositorys;
using TCC_Backend.Infrastructure.Repository.HistoricoRepositorys;
using TCC_Backend.Infrastructure.Repository.ServicoRepositorys;
using TCC_Backend.Infrastructure.UnitOfWorks;

namespace TCC_Backend.Infrastructure.Configurations
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IHistoricoService, HistoricoService>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IServicoBackgroundService, ServicoBackgroundService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
