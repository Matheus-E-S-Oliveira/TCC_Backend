using TCC_Backend.Domain.Models.Servicos;
using TCC_Backend.Domain.Models.Usuarios;

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

        public Guid UsuarioId { get; private set; }
        
        public Guid ServicoId { get; private set; }

        public DateTime DataUltimaAvaliacao { get; private set; }

        
        public virtual Usuario? Usuario { get; set; }

        public virtual Servico? Servico { get; set; }
    }
}
