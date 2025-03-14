using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm;
using TCC_Backend.Domain.Interfaces.IAuthRepositorys;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Security.Cryptography.BCryptAlgorithms;
using TCC_Backend.Infrastructure.Security.Tokens.Access;
using TCC_Backend.Infrastructure.Validators.Auth.Post.LoginAdm;
using TCC_Backend.Infrastructure.Validators.Auth.Post.LoginUsers;

namespace TCC_Backend.Infrastructure.Repository.AuthRepositorys
{
    public class AuthRepository(TccBackendContext context,
                                JwtTokenGenerator jwtTokenGenerator,
                                LoginAdmValidator validations,
                                LoginUserValidator rules) : IAuthRepository
    {
        public async Task<TokenDto> Login(PostAuthRequest request)
        {
            var userExist = await context.Usuarios
                .FirstOrDefaultAsync(user => (request.UserIdentify.ToLower().Equals(user.Email.ToLower())) 
                || (request.UserIdentify.ToLower().Equals(user.UserName.ToLower())));

            if (userExist == null)
            {
                return new TokenDto
                {
                    Sussecs = 0,
                    AccessToken = ""
                };
            }

            var senhaCorreta = BCryptAlgorithm.Verify(request.Password, userExist);

            if(senhaCorreta == false)
            {
                return new TokenDto
                {
                    Sussecs = 0,
                    AccessToken = ""
                };
            }

            return new TokenDto
            {
                Sussecs = 1,
                AccessToken = await jwtTokenGenerator.Generate(userExist)
            };
        }

        public async Task<TokenDto> LoginAdm(PostAuthAdmRequest request)
        {
            var userExist = await context.Adms
                .FirstOrDefaultAsync(user => (request.UserIdentify.ToLower().Equals(user.Email.ToLower()))
                || (request.UserIdentify.ToLower().Equals(user.UserName.ToLower())));

            if (userExist == null)
            {
                return new TokenDto
                {
                    Sussecs = 0,
                    AccessToken = ""
                };
            }

            var senhaCorreta = BCryptAlgorithm.Verify(request.Password, userExist);

            if (senhaCorreta == false)
            {
                return new TokenDto
                {
                    Sussecs = 0,
                    AccessToken = ""
                };
            }

            return new TokenDto
            {
                Sussecs = 1,
                AccessToken = JwtTokenGenerator.GenerateTokenAdm(userExist)
            };
        }

        public Task<List<string>> Validar(PostAuthAdmRequest request)
        {
           var validate = validations.Validate(request);

            return Task.FromResult(validate.Errors.Select(erro => erro.ErrorMessage).ToList());
        }

        public Task<List<string>> Validar(PostAuthRequest request)
        {
            var validate = rules.Validate(request);

            return Task.FromResult(validate.Errors.Select(erro => erro.ErrorMessage).ToList());
        }
    }
}
