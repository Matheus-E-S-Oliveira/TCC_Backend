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
            ZonaEleitoral = string.Empty;
            SecaoEleitoral = string.Empty;
            Telefone = string.Empty;
            UserName = string.Empty;
            Type = string.Empty;
        }

        public Usuario(string nome,
                       string password,
                       string email,
                       string cpf,
                       string tituloEleitor,
                       string zonaEleitoral,
                       string secaoEleitoral,
                       string telefone,
                       string userName,
                       string type)
        {
            Nome = nome;
            Password = password;
            Email = email;
            Cpf = cpf;
            TituloEleitor = tituloEleitor;
            ZonaEleitoral = zonaEleitoral;
            SecaoEleitoral = secaoEleitoral;
            Telefone = telefone;
            UserName = userName;
            Type = type;
        }

        public string Nome { get; private set; }

        public string Password { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }

        public string Cpf { get; private set; }

        public string TituloEleitor { get; private set; }

        public string ZonaEleitoral { get; private set; }

        public string SecaoEleitoral { get; private set; }

        public string Telefone { get; private set; }

        public string Type { get; private set; }

        [JsonIgnore]
        public virtual ICollection<UsuarioServicoAvaliacao>? UsuarioServicoAvaliacoes { get; set; }
    }
}
