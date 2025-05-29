using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Adm.Commands.Post;

namespace TCC_Backend.Application.Endpoints.Adm
{
    public class AdmController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAdmRequest request)
        {
            return await Post<PostAdmRequest, PostAdmHandler>(request);
        }
    }
}
