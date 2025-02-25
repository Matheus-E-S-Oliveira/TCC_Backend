using System.Text.Json.Serialization;
using TCC_Backend.Domain.Models.UsuarioServicosAvaliacao;

namespace TCC_Backend.Domain.Models.Usuarios
{
    public class Usuario : BaseEntity
    {
        public Usuario()
        {
            Nome = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Cpf = string.Empty;
            TituloEleitor = string.Empty;
            Telefone = string.Empty;
        }

        public Usuario(string nome, string password, string email, string cpf, string tituloEleitor, string telefone)
        {
            Nome = nome;
            Password = password;
            Email = email;
            Cpf = cpf;
            TituloEleitor = tituloEleitor;
            Telefone = telefone;
        }

        public string Nome { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }

        public string Cpf { get; private set; }

        public string TituloEleitor { get; private set; }

        public string Telefone { get; private set; }

        [JsonIgnore]
        public virtual ICollection<UsuarioServicoAvaliacao>? UsuarioServicoAvaliacoes { get; set; }
    }
}
