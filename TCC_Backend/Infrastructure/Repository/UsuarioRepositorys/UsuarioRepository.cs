using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario;
using TCC_Backend.Domain.Interfaces.IUsuarioRepositorys;
using TCC_Backend.Domain.Models.Usuarios;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Security.Cryptography.BCryptAlgorithms;
using TCC_Backend.Infrastructure.Security.Tokens.Access;

namespace TCC_Backend.Infrastructure.Repository.UsuarioRepositorys
{
    public class UsuarioRepository(TccBackendContext context, JwtTokenGenerator jwtTokenGenerator) : IUsuarioRepository
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
                AccessToken = await jwtTokenGenerator.Generate(newUser)
            };
        }
    }
}
