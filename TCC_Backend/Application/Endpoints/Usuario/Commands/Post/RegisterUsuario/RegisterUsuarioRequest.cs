using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario
{
    public class RegisterUsuarioRequest
    {
        [FromBody]
        public string Nome { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string TituloEleitor { get; set; } = string.Empty;

        public string ZonaEleitoral { get; set; } = string.Empty;

        public string SecaoEleitoral { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;
    }
}
