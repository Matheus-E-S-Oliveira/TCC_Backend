using FluentValidation;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm;

namespace TCC_Backend.Infrastructure.Validators.Auth.Post.LoginAdm
{
    public class LoginAdmValidator : AbstractValidator<PostAuthAdmRequest>
    {
        public LoginAdmValidator()
        {
            RuleFor(request => request.UserIdentify).NotEmpty().WithMessage("O e-mail ou nome de usuário é obrigatório.");
            When(request => string.IsNullOrEmpty(request.UserIdentify) == false, () =>
            {
                RuleFor(request => request.UserIdentify).MinimumLength(4).WithMessage("O e-mail ou nome de usuário deve ter no mínimo 4 caracteres.");
                When(request => request.UserIdentify.Length >= 4, () =>
                {
                    RuleFor(request => request.UserIdentify).MaximumLength(50).WithMessage("O e-mail ou nome de usuário deve ter no máximo 20 caracteres.");
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
