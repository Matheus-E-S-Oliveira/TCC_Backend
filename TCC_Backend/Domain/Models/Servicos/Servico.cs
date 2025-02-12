namespace TCC_Backend.Domain.Models.Servicos
{
    public class Servico : BaseEntity
    {
        public Servico(string nome, string titulo, int numeroDeAvalicoes)
        {
            Nome = nome;
            Titulo = titulo;
            NumeroDeAvalicoes = numeroDeAvalicoes;
        }

        public string Nome { get; private set; }

        public string Titulo { get; private set; }

        public int NumeroDeAvalicoes { get; private set; }
    }
}
