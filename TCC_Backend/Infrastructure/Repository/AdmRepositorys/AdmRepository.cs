using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.TokenValidationDtos;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;
using TCC_Backend.Domain.Interfaces.IAdmRepositorys;
using TCC_Backend.Domain.Models.Adms;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Security.Cryptography.BCryptAlgorithms;
using TCC_Backend.Infrastructure.Service.TokenServices;
using TCC_Backend.Infrastructure.Validators.Adm.Post;

namespace TCC_Backend.Infrastructure.Repository.AdmRepositorys
{
    public class AdmRepository(TccBackendContext context, AdmValidator validations) : IAdmRepository
    {
        public async Task<TokenValidationDto> CheckAuth(string token)
        {
            var type = TokenService.ObterDadosDoToken(token);

            if (string.IsNullOrWhiteSpace(type.Sub) || string.IsNullOrWhiteSpace(type.Type))
            {
                return new TokenValidationDto
                {
                    IsTokenValid = false,
                    Menssage = "Token inválido. Por favor, faça login novamente."
                };
            }

            if (!Guid.TryParse(type.Sub, out Guid subGuid))
            {
                return new TokenValidationDto
                {
                    IsTokenValid = false,
                    Menssage = "Token inválido. Dados corrompidos. Por favor, faça login novamente."
                };
            }

            if (type.Type != "master")
            {
                return new TokenValidationDto
                {
                    IsTokenValid = false,
                    Menssage = "Você não tem permissão para registrar um administrador."
                };
            }

            return new TokenValidationDto
            {
                IsTokenValid = await context.Adms.AnyAsync(x => x.Id == subGuid && x.Type == type.Type),
                Menssage = "Você não tem permissão para registrar um administrador."
            };
        }

        public async Task<int> RegisterAdm(PostAdmRequest request)
        {
            var newAdm = new Adm(
                userName: request.UserName,
                password: BCryptAlgorithm.HashPassword(request.Password),
                email: request.Email,
                type: "adm");

            await context.AddAsync(newAdm);

            return await context.SaveChangesAsync();
        }

        public async Task<bool> UserEmailExist(string email)
        {
            return await context.Adms.AnyAsync(x =>  email.ToLower().Equals(x.Email.ToLower()));
        }

        public async Task<bool> UserNameExists(string userName)
        {
            return await context.Adms.AnyAsync(x => userName.ToLower().Equals(x.UserName.ToLower()));
        }

        public async Task<List<string>> Validar(PostAdmRequest request)
        {
            var validate = validations.Validate(request);

            if (await UserNameExists(request.UserName))
                validate.Errors.Add(new ValidationFailure("UserName", "O nome de usuário informado já existe. Por favor, escolha outro."));

            if (await UserEmailExist(request.Email))
                validate.Errors.Add(new ValidationFailure("Email", "O e-mail fornecido já está registrado. Por favor, insira um e-mail diferente."));

            return [.. validate.Errors.Select(x => x.ErrorMessage)];
        }
    }
}
