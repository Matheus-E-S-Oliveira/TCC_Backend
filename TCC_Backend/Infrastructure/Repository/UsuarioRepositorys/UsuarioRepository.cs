using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;
using TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario;
using TCC_Backend.Domain.Interfaces.IUsuarioRepositorys;
using TCC_Backend.Domain.Models.Usuarios;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Security.Cryptography.BCryptAlgorithms;
using TCC_Backend.Infrastructure.Security.Tokens.Access;
using TCC_Backend.Infrastructure.Validators.Usuario.Post;

namespace TCC_Backend.Infrastructure.Repository.UsuarioRepositorys
{
    public class UsuarioRepository(TccBackendContext context,
                                   JwtTokenGenerator jwtTokenGenerator,
                                   UsuarioValidator validations) : IUsuarioRepository
    {
        public async Task<TokenDto> RegisterUsuario(RegisterUsuarioRequest request)
        {
            var newUser = new Usuario(
                nome: request.Nome,
                userName: request.UserName,
                password: BCryptAlgorithm.HashPassword(request.Password),
                email: request.Email,
                cpf: request.Cpf,
                tituloEleitor: request.TituloEleitor,
                zonaEleitoral: request.ZonaEleitoral,
                secaoEleitoral: request.SecaoEleitoral,
                telefone: request.Telefone,
                type: "user");

            await context.AddAsync(newUser);

            var resutlt = await context.SaveChangesAsync();

            return new TokenDto
            {
                Sussecs = resutlt,
                AccessToken = jwtTokenGenerator.Generate(newUser)
            };
        }

        private async Task<bool> UserEmailExist(string email)
        {
            return await context.Usuarios.AnyAsync(x => email.ToLower().Equals(x.Email.ToLower()));
        }

        private async Task<bool> UserNameExists(string userName)
        {
            return await context.Usuarios.AnyAsync(x => userName.ToLower().Equals(x.UserName.ToLower()));
        }

        private async Task<bool> UserTituloEleitorExist(string titulo)
        {
            return await context.Usuarios.AnyAsync(x => titulo.Equals(x.TituloEleitor));
        }

        public async Task<bool> UserCpfExist(string cpf)
        {
            return await context.Usuarios.AnyAsync(x => cpf.Equals(x.Cpf));
        }

        private async Task<bool> UserZonaEleitoral(string zonaEleitoral)
        {
            return await context.SecaoEleitorais.AnyAsync(x => zonaEleitoral.Equals(x.ZonaEleitoral));
        }

        private async Task<bool> UserSecaoEleitoral(string secaoEleitoral, string zonaEleitoral)
        {
            return await context.SecaoEleitorais.AnyAsync(x => zonaEleitoral.Equals(x.ZonaEleitoral) && secaoEleitoral.Equals(x.Numero));
        }

        public async Task<List<string>> Validar(RegisterUsuarioRequest request)
        {
            var validate = validations.Validate(request);

            if (await UserZonaEleitoral(request.ZonaEleitoral) == false)
                validate.Errors.Add(new ValidationFailure("ZonaEleitoral", "A Zona Eleitoral informada não pertence a essa cidade."));

            if (await UserSecaoEleitoral(request.SecaoEleitoral, request.ZonaEleitoral) == false)
                validate.Errors.Add(new ValidationFailure("SecaoEleitoral", "Essa seção eleitoral não pertence à Zona Eleitoral desta cidade."));

            if (await UserTituloEleitorExist(request.TituloEleitor))
                validate.Errors.Add(new ValidationFailure("TituloEleitor", "O Título de Eleitor informado já está cadastrado. Por favor, verifique e tente novamente."));

            if (await UserCpfExist(request.Cpf))
                validate.Errors.Add(new ValidationFailure("Cpf", "O CPF informado já está cadastrado. Por favor, verifique e tente novamente."));

            if (await UserNameExists(request.UserName))
                validate.Errors.Add(new ValidationFailure("UserName", "O nome de usuário informado já existe. Por favor, escolha outro."));

            if (await UserEmailExist(request.Email))
                validate.Errors.Add(new ValidationFailure("Email", "O e-mail fornecido já está registrado. Por favor, insira um e-mail diferente."));

            return [.. validate.Errors.Select(x => x.ErrorMessage)];
        }
    }
}
