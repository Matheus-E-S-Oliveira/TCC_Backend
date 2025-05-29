using FluentValidation;
using TCC_Backend.Infrastructure.Validators.Adm.Post;
using TCC_Backend.Infrastructure.Validators.Auth.Post.LoginAdm;
using TCC_Backend.Infrastructure.Validators.Auth.Post.LoginUsers;
using TCC_Backend.Infrastructure.Validators.Report.Post;
using TCC_Backend.Infrastructure.Validators.Servico.Post;
using TCC_Backend.Infrastructure.Validators.Servico.Put;
using TCC_Backend.Infrastructure.Validators.Usuario.Post;

namespace TCC_Backend.Infrastructure.Configurations
{
    public static class ValidatorRegistration
    {
        public static void AddValidators(this IServiceCollection services)
        {
            //services.AddFluentValidationAutoValidation();
            //services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<AdmValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginAdmValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginUserValidator>();
            services.AddValidatorsFromAssemblyContaining<ReportValidator>();
            services.AddValidatorsFromAssemblyContaining<UsuarioValidator>();
            services.AddValidatorsFromAssemblyContaining<ServicoValidator>();
            services.AddValidatorsFromAssemblyContaining<ServicoPutValidator>();
        }
    }
}
