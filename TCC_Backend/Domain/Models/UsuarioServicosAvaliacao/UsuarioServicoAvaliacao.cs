namespace TCC_Backend.Domain.Models.UsuarioServicosAvaliacao
{
    public class UsuarioServicoAvaliacao : BaseEntity
    {
        public UsuarioServicoAvaliacao(Guid usuarioId, Guid servicoId, DateTime dataUltimaAvaliacao)
        {
            UsuarioId = usuarioId;
            ServicoId = servicoId;
            DataUltimaAvaliacao = dataUltimaAvaliacao;
        }

        public Guid UsuarioId { get; set; }
        
        public Guid ServicoId { get; set; }

        public DateTime DataUltimaAvaliacao { get; set; }
    }
}
