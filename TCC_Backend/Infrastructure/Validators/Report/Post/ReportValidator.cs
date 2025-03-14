using FluentValidation;
using TCC_Backend.Application.Endpoints.Report.Commands.Post.PostReport;

namespace TCC_Backend.Infrastructure.Validators.Report.Post
{
    public class ReportValidator : AbstractValidator<PostReportRequest>
    {
        public ReportValidator()
        {
            RuleFor(request => request.ReportType).NotEmpty().WithMessage("O tipo de relatório é obrigatório.");

            When(request => string.IsNullOrEmpty(request.ReportType) == false && request.ErrorCategory == "error", () =>
            {
                RuleFor(request => request.ErrorCategory).NotEmpty().WithMessage("A categoria de erro é obrigatória quando o tipo de relatório é 'Erro'.");
            });
            When(request => string.IsNullOrEmpty(request.ReportType) == false && request.SuggestionCategory == "suggestion", () =>
            {
                RuleFor(request => request.SuggestionCategory).NotEmpty().WithMessage("A categoria de sugestão é obrigatória quando o tipo de relatório é 'Sugestão'.");
            });

            RuleFor(request => request.Description).NotEmpty().WithMessage("A descrição é obrigatória.");
            When(request => string.IsNullOrEmpty(request.Description) == false, () =>
            {
                RuleFor(request => request.Description).MinimumLength(10).WithMessage("A descrição deve ter pelo menos 10 caracteres.");
                When(request => request.Description.Length >= 8, () =>
                {
                    RuleFor(request => request.Description).MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");
                });
            });

            When(request => request.WantsContact == true, () =>
            {
                RuleFor(request => request.ContactEmail).NotEmpty().WithMessage("O email é obrigatório");
                When(request => string.IsNullOrEmpty(request.ContactEmail) == false, () =>
                {
                    RuleFor(request => request.ContactEmail).MinimumLength(6).WithMessage("O email ter no mínimo 6 caracteres.");
                    When(request => request?.ContactEmail?.Length >= 6, () =>
                    {
                        RuleFor(request => request.ContactEmail).EmailAddress().WithMessage("O email deve ser valido");
                        RuleFor(request => request.ContactEmail).MaximumLength(50).WithMessage("O email deve ter no máximo 20 caracteres.");
                    });

                });
            });
        }
    }
}
