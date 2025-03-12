using TCC_Backend.Application.Interfaces.Servicos.IGenerateJwtTokenServices;
using TCC_Backend.Application.Interfaces.Servicos.IHistoricoServices;
using TCC_Backend.Application.Interfaces.Servicos.IServicoBackgroundServices;
using TCC_Backend.Application.Services.GenerateJwtTokenServices;
using TCC_Backend.Application.Services.HistoricoServices;
using TCC_Backend.Application.Services.ServicoBackgroundServices;
using TCC_Backend.Domain.Interfaces.IAdmRepositorys;
using TCC_Backend.Domain.Interfaces.IAuthRepositorys;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.IHistorioRepositorys;
using TCC_Backend.Domain.Interfaces.ILastExecutionDateRepositorys;
using TCC_Backend.Domain.Interfaces.IReportRepositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Domain.Interfaces.IUsuarioRepositorys;
using TCC_Backend.Domain.Interfaces.IUsuarioServicoAvaliacaoRepositorys;
using TCC_Backend.Domain.UnitOfWorks;
using TCC_Backend.Infrastructure.Interfaces.IUltimaAvalicaoPorServicos;
using TCC_Backend.Infrastructure.Repository.AdmRepositorys;
using TCC_Backend.Infrastructure.Repository.AuthRepositorys;
using TCC_Backend.Infrastructure.Repository.AvaliacaoRepositorys;
using TCC_Backend.Infrastructure.Repository.HistoricoRepositorys;
using TCC_Backend.Infrastructure.Repository.LastExecutionDateRepositorys;
using TCC_Backend.Infrastructure.Repository.ReportRepositorys;
using TCC_Backend.Infrastructure.Repository.ServicoRepositorys;
using TCC_Backend.Infrastructure.Repository.UsuarioRepositorys;
using TCC_Backend.Infrastructure.Repository.UsuarioServicoAvaliacaoRepositorys;
using TCC_Backend.Infrastructure.Security.Tokens.Access;
using TCC_Backend.Infrastructure.Service.AtualizacaoHistoricoBackgroundServices;
using TCC_Backend.Infrastructure.Service.UltimaAvalicaoPorServicos;
using TCC_Backend.Infrastructure.UnitOfWorks;

namespace TCC_Backend.Infrastructure.Configurations
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAdmRepository, AdmRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<AtualizacaoHistoricoBackgroundService>();
            services.AddScoped<IGenerateJwtTokenService, GenerateJwtTokenService>();
            services.AddScoped<IHistoricoRepository, HistoricoRepository>();
            services.AddScoped<IHistoricoService, HistoricoService>();
            services.AddScoped<ILastExecutionDateRepository, LastExecutionDateRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IServicoBackgroundService, ServicoBackgroundService>();
            services.AddScoped<IServicoRepositoryDependency, ServicoRepositoryDependency>();
            services.AddScoped<IReportRepository, ReportsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioServicoAvaliacaoRepository, UsuarioServicoAvaliacaoRepository>();
            services.AddScoped<IUltimaAvalicaoPorServico, UltimaAvalicaoPorServico>();
            services.AddScoped<JwtTokenGenerator>();
        }
    }
}
