using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Interfaces.Endpoints.IPutHandler
{
    public interface IHandlerRequest<TRequest>
    {
        Task<IActionResult> Handle(Guid id, TRequest request);
    }
}
