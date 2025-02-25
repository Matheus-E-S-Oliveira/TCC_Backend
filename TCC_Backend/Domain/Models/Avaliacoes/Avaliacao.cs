using System.Text.Json.Serialization;
using TCC_Backend.Domain.Enums;
using TCC_Backend.Domain.Models.Servicos;

namespace TCC_Backend.Domain.Models.Avaliacoes
{
    public class Avaliacao : BaseEntity
    {
        public Avaliacao()
        {
        }

        public Avaliacao(Guid idServico, CategoriaAvaliacao categoria, decimal nota, DateTime dataAvalicao)
        {
            IdServico = idServico;
            Categoria = categoria;
            Nota = nota;
            DataAvalicao = dataAvalicao;
        }

        public Guid IdServico { get; private set; }

        public CategoriaAvaliacao Categoria {  get; private set; }

        public decimal Nota { get; private set; }

        public DateTime DataAvalicao { get; private set; }

        [JsonIgnore]
        public virtual Servico? Servico { get; set; }


        public void Update(decimal nota, DateTime dataAvalicao)
        {
            Nota = nota;
            DataAvalicao = dataAvalicao;
        }

    }
}
