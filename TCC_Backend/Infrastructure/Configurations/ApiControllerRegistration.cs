using TCC_Backend.Application.Endpoints.Adm.Commands.Post;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm;
using TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao;
using TCC_Backend.Application.Endpoints.Avalicacao.Queries.GetAvaliacaoPorServico;
using TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport;
using TCC_Backend.Application.Endpoints.Servico.Commands.Post.PostServico;
using TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicoPorId;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos;
using TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario;
using TCC_Backend.Application.Endpoints.UsuarioServicoAvaliacao.Queries;

namespace TCC_Backend.Infrastructure.Configurations
{
    public static class ApiControllerRegistration
    {
        public static void AddApiControllers(this IServiceCollection services)
        {
            services.AddScoped<PostAdmHandler>();
            services.AddScoped<GetAvaliacaoPorServicoHandler>();
            services.AddScoped<GetServicoPorIdHandler>();
            services.AddScoped<GetServicosHandler>();
            services.AddScoped<PutAvaliacaoHandler>();
            services.AddScoped<PostAuthHandler>();
            services.AddScoped<PostAuthAdmHandler>();
            services.AddScoped<PostServicoHandler>();
            services.AddScoped<PutServicoHandler>();
            services.AddScoped<PostReportHandler>();
            services.AddScoped<RegisterUsuarioHandler>();
            services.AddScoped<UsuarioServicoAvaliacaoHandler>();
        }
    }
}
