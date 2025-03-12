using System.Text.Json.Serialization;
using TCC_Backend.Domain.Models.Servicos;
using TCC_Backend.Domain.Models.Usuarios;

namespace TCC_Backend.Domain.Models.UsuarioServicosAvaliacao
{
    public class UsuarioServicoAvaliacao : BaseEntity
    {
        public UsuarioServicoAvaliacao()
        {
        }

        public UsuarioServicoAvaliacao(Guid usuarioId, Guid servicoId, DateTime dataUltimaAvaliacao)
        {
            UsuarioId = usuarioId;
            ServicoId = servicoId;
            DataUltimaAvaliacao = dataUltimaAvaliacao;
        }

        public Guid UsuarioId { get; private set; }
        
        public Guid ServicoId { get; private set; }

        public DateTime DataUltimaAvaliacao { get; private set; }

        [JsonIgnore]
        public virtual Usuario? Usuario { get; set; }

        [JsonIgnore]
        public virtual Servico? Servico { get; set; }

        public void Update(DateTime dataUltimaAvaliacao)
        {
            DataUltimaAvaliacao = dataUltimaAvaliacao;
        }
    }
}
