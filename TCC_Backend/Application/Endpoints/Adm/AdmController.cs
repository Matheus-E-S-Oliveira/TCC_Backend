using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Adm.Commands.Delete;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;
using TCC_Backend.Application.Endpoints.Adm.Queries;

namespace TCC_Backend.Application.Endpoints.Adm
{
    public class AdmController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAdmsRequest request)
        {
            return await Get<GetAdmsRequest, GetAdmsHandler>(request);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAdmRequest request)
        {
            return await Post<PostAdmRequest, PostAdmHandler>(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete<DeleteAdmRequest, DeleteAdmHandler>(id);
        }
    }
}
