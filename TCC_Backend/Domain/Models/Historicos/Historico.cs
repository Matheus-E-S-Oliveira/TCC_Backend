using TCC_Backend.Domain.Models.Servicos;

namespace TCC_Backend.Domain.Models.Historicos
{
    public class Historico : BaseEntity
    {
        public Historico()
        {
        }

        public Historico(Guid idServico,
                         decimal mediaCategoria1,
                         decimal mediaCategoria2,
                         decimal mediaCategoria3,
                         decimal mediaCategoria4,
                         decimal mediaCategoria5,
                         int numeroDeAvaliacoes,
                         DateTime? dataReferencia)
        {
            IdServico = idServico;
            MediaCategoria1 = mediaCategoria1;
            MediaCategoria2 = mediaCategoria2;
            MediaCategoria3 = mediaCategoria3;
            MediaCategoria4 = mediaCategoria4;
            MediaCategoria5 = mediaCategoria5;
            NumeroDeAvaliacoes = numeroDeAvaliacoes;
            DataReferencia = dataReferencia;
        }

        public Guid IdServico { get; private set; }

        public decimal MediaCategoria1{  get; private set; }

        public decimal MediaCategoria2 { get; private set; }

        public decimal MediaCategoria3 { get; private set; }

        public decimal MediaCategoria4 { get; private set; }
        
        public decimal MediaCategoria5 { get; private set; }

        public int NumeroDeAvaliacoes { get; private set; }

        public DateTime? DataReferencia { get; private set; }


        public virtual Servico? Servico { get; set; }

        public void Update(decimal mediaCategoria1,
                               decimal mediaCategoria2,
                               decimal mediaCategoria3,
                               decimal mediaCategoria4,
                               decimal mediaCategoria5,
                               int numeroDeAvaliacoes,
                               DateTime? dataReferencia)
        {
            MediaCategoria1 = mediaCategoria1;
            MediaCategoria2 = mediaCategoria2;
            MediaCategoria3 = mediaCategoria3;
            MediaCategoria4 = mediaCategoria4;
            MediaCategoria5 = mediaCategoria5;
            NumeroDeAvaliacoes = numeroDeAvaliacoes;
            DataReferencia = dataReferencia;
        }
    }
}
