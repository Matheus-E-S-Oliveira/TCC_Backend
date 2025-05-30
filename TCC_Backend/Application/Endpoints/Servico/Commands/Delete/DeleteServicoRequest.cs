using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Servico.Commands.Delete
{
    public class DeleteServicoRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}
