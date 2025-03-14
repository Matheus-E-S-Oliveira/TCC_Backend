using FluentValidation;
using TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario;

namespace TCC_Backend.Infrastructure.Validators.Usuario.Post
{
    public class UsuarioValidator : AbstractValidator<RegisterUsuarioRequest>
    {
        public UsuarioValidator()
        {
            RuleFor(request => request.TituloEleitor).NotEmpty().WithMessage("O título de eleitor é obrigatório.");
            When(request => string.IsNullOrEmpty(request.TituloEleitor) == false, () =>
            {
                RuleFor(request => request.TituloEleitor).MinimumLength(12).WithMessage("O título de eleitor deve ter no mínimo 12 caracteres.");
                When(request => request.TituloEleitor.Length > 12 , () =>
                {
                    RuleFor(request => request.TituloEleitor).MaximumLength(12).WithMessage("O título de eleitor deve ter no máximo 12 caracteres.");
                });
            });
            RuleFor(request => request.ZonaEleitoral).NotEmpty().WithMessage("A zona eleitoral é obrigatória.");
            When(request => string.IsNullOrEmpty(request.ZonaEleitoral) == false, () =>
            {
                RuleFor(request => request.ZonaEleitoral).MinimumLength(3).WithMessage("A zona eleitoral deve ter no mínimo 3 caracteres.");
                When(request => request.ZonaEleitoral.Length > 3, () =>
                {
                    RuleFor(request => request.ZonaEleitoral).MaximumLength(3).WithMessage("A zona eleitoral deve ter no máximo 6 caracteres.");
                });
            });
            RuleFor(request => request.SecaoEleitoral).NotEmpty().WithMessage("A seção eleitoral é obrigatória.");
            When(request => string.IsNullOrEmpty(request.SecaoEleitoral) == false, () =>
            {
                RuleFor(request => request.SecaoEleitoral).MinimumLength(3).WithMessage("A seção eleitoral deve ter no mínimo 3 caracteres.");
                When(request => request.SecaoEleitoral.Length >= 3, () =>
                {
                    RuleFor(request => request.SecaoEleitoral).MaximumLength(6).WithMessage("A seção eleitoral deve ter no máximo 6 caracteres.");
                });
            });
            RuleFor(request => request.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
            When(request => string.IsNullOrEmpty(request.Nome) == false, () =>
            {
                RuleFor(request => request.Nome).MinimumLength(4).WithMessage("O nome deve ter no mínimo 4 caracteres.");
                When(request => request.Nome.Length >= 4, () =>
                {
                    RuleFor(request => request.Nome).Matches(@"^[A-Za-zÀ-ÿ\s]+$").WithMessage("O nome não pode conter números ou caracteres especiais.");
                    RuleFor(request => request.Nome).MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");
                });
            });
            RuleFor(request => request.Cpf).NotEmpty().WithMessage("O cpf é obrigatório.");
            When(request => string.IsNullOrEmpty(request.Cpf) == false, () =>
            {
                RuleFor(request => request.Cpf).MinimumLength(11).WithMessage("O cpf deve ter no mínimo 11 caracteres.");
                When(request => request.Cpf.Length > 11, () =>
                {
                    RuleFor(request => request.Cpf).MaximumLength(11).WithMessage("O cpf deve ter no máximo 11 caracteres.");
                });
            });
            RuleFor(request => request.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.");
            When(request => string.IsNullOrEmpty(request.Telefone) == false, () =>
            {
                RuleFor(request => request.Telefone).MinimumLength(11).WithMessage("O telefone deve ter no mínimo 11 caracteres.");
                When(request => request.Telefone.Length > 11, () =>
                {
                    RuleFor(request => request.Telefone).MaximumLength(11).WithMessage("O telefone deve ter no máximo 11 caracteres.");
                });
            });
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
