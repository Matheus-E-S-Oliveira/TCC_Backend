using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicoPorId;
using TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao;
using TCC_Backend.Application.Endpoints.Avalicacao.Queries.GetAvaliacaoPorServico;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth;

namespace TCC_Backend.Infrastructure.Configurations
{
    public static class ApiControllerRegistration
    {
        public static void AddApiControllers(this IServiceCollection services)
        {
            services.AddScoped<GetAvaliacaoPorServicoHandler>();
            services.AddScoped<GetServicoPorIdHandler>();
            services.AddScoped<GetServicosHandler>();
            services.AddScoped<PutAvaliacaoHandler>();
            services.AddScoped<PostAuthHandler>();
        }
    }
}
