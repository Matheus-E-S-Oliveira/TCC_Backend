using System.Text.Json.Serialization;
using TCC_Backend.Domain.Models.Avaliacoes;
using TCC_Backend.Domain.Models.Historicos;
using TCC_Backend.Domain.Models.UsuarioServicosAvaliacao;

namespace TCC_Backend.Domain.Models.Servicos
{
    public class Servico : BaseEntity
    {
        public Servico()
        {
            Nome = string.Empty;
            Titulo = string.Empty;
        }

        public Servico(string nome, string titulo, int numeroDeAvalicoes)
        {
            Nome = nome;
            Titulo = titulo;
            NumeroDeAvalicoes = numeroDeAvalicoes;
        }

        public string Nome { get; private set; }

        public string Titulo { get; private set; }

        public int NumeroDeAvalicoes { get; private set; }

        [JsonIgnore]
        public virtual ICollection<Avaliacao>? Avaliacoes { get; set; }

        [JsonIgnore]
        public virtual ICollection<Historico>? Historicos { get; set; }

        [JsonIgnore]
        public virtual ICollection<UsuarioServicoAvaliacao>? UsuarioServicoAvaliacoes { get; set; }


        public void Update(int numeroDeAvaliacoes)
        {
            NumeroDeAvalicoes = numeroDeAvaliacoes;
        }
    }
}
