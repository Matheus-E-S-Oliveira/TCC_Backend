using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;
using TCC_Backend.Domain.Interfaces.IAdmRepositorys;
using TCC_Backend.Domain.Models.Adms;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Security.Cryptography.BCryptAlgorithms;
using TCC_Backend.Infrastructure.Security.Tokens.Access;

namespace TCC_Backend.Infrastructure.Repository.AdmRepositorys
{
    public class AdmRepository(TccBackendContext context) : IAdmRepository
    {
        public async Task<TokenDto> RegisterAdm(PostAdmRequest request)
        {
            var newAdm = new Adm(
                userName: request.UserName,
                password: BCryptAlgorithm.HashPassword(request.Password),
                email: request.Email,
                type: "adm");

            await context.AddAsync(newAdm);

            var resutlt = await context.SaveChangesAsync();

            return new TokenDto
            {
                Sussecs = resutlt,
                AccessToken = JwtTokenGenerator.GenerateTokenAdm(newAdm)
            };
        }
    }
}
