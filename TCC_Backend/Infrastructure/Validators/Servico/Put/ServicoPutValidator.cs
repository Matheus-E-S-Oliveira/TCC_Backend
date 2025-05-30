using FluentValidation;
using TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico;

namespace TCC_Backend.Infrastructure.Validators.Servico.Put
{
    public class ServicoPutValidator : AbstractValidator<PutServicoRequest>
    {
        public ServicoPutValidator()
        {
            RuleFor(s => s.Nome)
                .NotEmpty().WithMessage("O nome do serviço avaliado é obrigatório.");

            When(request => string.IsNullOrEmpty(request.Nome) == false, () =>
            {
                RuleFor(s => s.Nome)
                .MaximumLength(100).WithMessage("O nome do serviço avaliado deve ter no máximo 100 caracteres.");
            });

            RuleFor(s => s.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.");

            When(request => string.IsNullOrEmpty(request.Titulo) == false, () =>
            {
                RuleFor(s => s.Titulo)
                .MaximumLength(100).MaximumLength(150).WithMessage("O título deve ter no máximo 150 caracteres.");
            });

            RuleFor(s => s.Localizacao)
                .NotEmpty().WithMessage("O link do Google Maps é obrigatório.");

            When(s => !string.IsNullOrWhiteSpace(s.Localizacao), () =>
            {
                RuleFor(s => s.Localizacao)
                    .Must(url =>
                    {
                        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)) return false;

                        var host = uri.Host.ToLower();
                        var path = uri.AbsolutePath.ToLower();

                         return host.Contains("google.") || host.Contains("goo.gl") || host.Contains("maps.app");
    
                    })
                    .WithMessage("A URL de localização deve ser um link válido do Google Maps.");
            });

            RuleFor(s => s.Imagem)
                .NotEmpty().WithMessage("A imagem representante do serviço é obrigatória.");

            When(s => !string.IsNullOrWhiteSpace(s.UrlSite), () =>
            {
                RuleFor(s => s.UrlSite)
                    .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                    .WithMessage("A URL fornecida é inválida.");
            });
        }
    }
}