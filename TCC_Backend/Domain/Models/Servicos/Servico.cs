using System.Text.Json.Serialization;
using TCC_Backend.Domain.Models.Avaliacoes;
using TCC_Backend.Domain.Models.Historicos;
using TCC_Backend.Domain.Models.Perguntas;
using TCC_Backend.Domain.Models.UsuarioServicosAvaliacao;

namespace TCC_Backend.Domain.Models.Servicos
{
    public class Servico : BaseEntity
    {
        public Servico()
        {
            Nome = string.Empty;
            Titulo = string.Empty;
            Localizacao = string.Empty;
            Imagem = string.Empty;
            UrlSite = string.Empty;
        }

        public Servico(string nome, string titulo, int numeroDeAvalicoes, string localizacao, string imagem, string? site)
        {
            Nome = nome;
            Titulo = titulo;
            NumeroDeAvaliacoes = numeroDeAvalicoes;
            Localizacao = localizacao;
            Imagem = imagem;
            UrlSite = site;
        }

        public string Nome { get; private set; }

        public string Titulo { get; private set; }

        public string Localizacao { get; private set; }

        public string Imagem { get; private set; }

        public string? UrlSite { get; private set; }

        public int NumeroDeAvaliacoes { get; private set; }

        [JsonIgnore]
        public virtual ICollection<Pergunta>? Perguntas { get; set; }

        [JsonIgnore]
        public virtual ICollection<Avaliacao>? Avaliacoes { get; set; }

        [JsonIgnore]
        public virtual ICollection<Historico>? Historicos { get; set; }

        [JsonIgnore]
        public virtual ICollection<UsuarioServicoAvaliacao>? UsuarioServicoAvaliacoes { get; set; }


        public void Update(int numeroDeAvaliacoes)
        {
            NumeroDeAvaliacoes = numeroDeAvaliacoes;
        }
        public void Update(string nome, string titulo, string localizacao, string imagem, string? site)
        {
            Nome = nome;
            Titulo = titulo;
            Localizacao = localizacao;
            Imagem = imagem;
            UrlSite = site;
        }
    }
}
