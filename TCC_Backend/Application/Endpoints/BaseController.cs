using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {

        [HttpGet]
        protected async Task<IActionResult> Get<TRequest, THandler>([FromQuery] TRequest? request)
        { 
            if (request == null)
                return BadRequest("Parâmetro de consulta inválido.");

            var _handler = HttpContext.RequestServices.GetService<THandler>();

            if (_handler == null)
                return BadRequest("Handler Inválido");

            var method = _handler.GetType().GetMethod("Handle");

            if (method == null)
                return BadRequest("Método não encontrado no handler.");

            if (method.Invoke(_handler, [request]) is Task<IActionResult> task)
            {
                var result = await task;
                return result;
            }
            else
            {
                return BadRequest("A invocação do método 'Handle' não retornou um Task<IActionResult>.");
            }

        }
        [HttpGet("{id}")]
        protected async Task<IActionResult> GetById<TRequest, THandler>(Guid id)
        {
            var _handler = HttpContext.RequestServices.GetService<THandler>();
            if (_handler == null)
                return BadRequest("Handler Inválido");

            var requestType = typeof(TRequest);
            var request = Activator.CreateInstance(requestType);

            if (request == null)
                return BadRequest("Não foi possível criar uma instância do request.");

            var idProperty = requestType.GetProperty("Id");
            if (idProperty == null)
                return BadRequest("Propriedade 'Id' não encontrada no request.");

            idProperty.SetValue(request, id);

            var method = _handler.GetType().GetMethod("Handle", [requestType]);
            if (method == null)
                return BadRequest("Método 'Handle' não encontrado no handler.");


            if (method.Invoke(_handler, [request]) is Task<IActionResult> task)
            {
                var result = await task;
                return result;
            }
            else
            {
                return BadRequest("A invocação do método 'Handle' não retornou um Task<IActionResult>.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post<TRequest, THandler>([FromBody] TRequest? request)
        {

            if (request == null)
                return BadRequest("Dados inválidos.");

            var _handler = HttpContext.RequestServices.GetService<THandler>();

            if (_handler == null)
                return BadRequest("Handler Inválido");

            var method = _handler.GetType().GetMethod("Handle");

            if (method == null)
                return BadRequest("Método não encontrado no handler.");

            return await (Task<IActionResult>)method.Invoke(_handler, [request])!;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put<TRequest, THandler>(Guid id, [FromBody] TRequest? request)
        {
            if (request == null)
                return BadRequest("Dados inválidos.");

            var _handler = HttpContext.RequestServices.GetService<THandler>();

            if (_handler == null)
                return BadRequest("Handler Inválido");

            var method = _handler.GetType().GetMethod("Handle");

            if (method == null)
                return BadRequest("Método não encontrado no handler.");

            return await (Task<IActionResult>)method.Invoke(_handler, [id, request])!;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete<TRequest, THandler>(Guid id)
        {
            var _handler = HttpContext.RequestServices.GetService<THandler>();

            if (_handler == null)
                return BadRequest("Handler Inválido");

            var method = _handler.GetType().GetMethod("Handle");

            if (method == null)
                return BadRequest("Método não encontrado no handler.");

            return await (Task<IActionResult>)method.Invoke(_handler, [id])!;
        }
    }
}
