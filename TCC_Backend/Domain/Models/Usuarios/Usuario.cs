namespace TCC_Backend.Domain.Models.Usuarios
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email, string cpf, string tituloEleitor, string telefone)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            TituloEleitor = tituloEleitor;
            Telefone = telefone;
        }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Cpf { get; private set; }

        public string TituloEleitor { get; private set; }

        public string Telefone { get; private set; }
    }
}
