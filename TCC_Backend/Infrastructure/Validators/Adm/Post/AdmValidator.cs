using FluentValidation;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;

namespace TCC_Backend.Infrastructure.Validators.Adm.Post
{
    public class AdmValidator : AbstractValidator<PostAdmRequest>
    {
        public AdmValidator()
        {
            RuleFor(request => request.UserName).NotEmpty().WithMessage("O nome de usuário é obrigatório.");
            When(request => string.IsNullOrEmpty(request.UserName) == false, () =>
            {
                RuleFor(request => request.UserName).MinimumLength(4).WithMessage("O nome de usuário deve ter no mínimo 4 caracteres.");
                When(request => request.UserName.Length >= 4, () =>
                {
                    RuleFor(request => request.UserName).MaximumLength(20).WithMessage("O nome de usuário deve ter no máximo 20 caracteres.");
                });
            });
            RuleFor(request => request.Email).NotEmpty().WithMessage("O email é obrigatório");
            When(request => string.IsNullOrEmpty(request.Email) == false, () =>
            {
                RuleFor(request => request.Email).MinimumLength(6).WithMessage("O email ter no mínimo 6 caracteres.");
                When(request => request.Email.Length >= 6, () =>
                {
                    RuleFor(request => request.Email).EmailAddress().WithMessage("O email deve ser valido");
                    RuleFor(request => request.Email).MaximumLength(50).WithMessage("O email deve ter no máximo 20 caracteres.");
                });

            });
            
            RuleFor(request => request.Password).NotEmpty().WithMessage("A Senha é obrigatória.");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password).MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres");
                When(request => request.Password.Length >= 8, () =>
                {
                    RuleFor(request => request.Password).MaximumLength(16).WithMessage("A senha deve ter no máximo 16 caracteres");
                });
            });
        }
    }

}
