using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Servico.Queries.GetServicoPorId
{
    public class GetServicoPorIdRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}
