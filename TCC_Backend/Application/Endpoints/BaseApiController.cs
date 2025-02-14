using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints
{
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Success(object data)
        {
            return Ok(new { success = true, data });
        }

        protected IActionResult Error(string message)
        {
            return BadRequest(new { success = false, message });
        }

        // Método para tratar exceções
        protected IActionResult HandleException(Exception ex)
        {
            return StatusCode(500, new { success = false, message = "Ocorreu um erro no servidor" });
        }

        protected IActionResult HandleResponse<T>(T data, string? errorMessage = null)
        {
            if (data != null)
                return Ok(data);

            if (!string.IsNullOrEmpty(errorMessage))
                return BadRequest(errorMessage);

            return NotFound();
        }

        protected async Task<IActionResult> GetByIdAsync<T>(Func<Task<T>> serviceMethod)
        {
            var result = await serviceMethod();
            return HandleResponse(result, "Não encontrado.");
        }

        // Método genérico POST
        protected async Task<IActionResult> CreateAsync<TRequest, TEntity>(
            TRequest request,
            Func<TRequest, Task<TEntity>> serviceMethod)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");

            var result = await serviceMethod(request);
            return HandleResponse(result);
        }

        // Método genérico PUT
        protected async Task<IActionResult> UpdateAsync<TRequest, TEntity>(
            Guid id,
            TRequest request,
            Func<Guid, TRequest, Task<TEntity>> serviceMethod)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");

            var result = await serviceMethod(id, request);
            return HandleResponse(result, "Erro ao atualizar.");
        }

        // Método genérico DELETE
        protected async Task<IActionResult> DeleteAsync(
            Guid id,
            Func<Guid, Task<bool>> serviceMethod)
        {
            var result = await serviceMethod(id);
            return result ? Ok("Removido com sucesso.") : NotFound();
        }
    }
}
