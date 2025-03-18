using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.UsuarioServicoAvaliacao.Queries
{
    public class UsuarioServicoAvaliacaoRequest
    {
        [FromRoute]
        public Guid Id { get; set; } 
    }
}
