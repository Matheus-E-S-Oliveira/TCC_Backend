using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm;

namespace TCC_Backend.Application.Endpoints.Auth
{
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAuthRequest request)
        {
            return await Post<PostAuthRequest, PostAuthHandler>(request);
        }

        [HttpPost("adm")]
        public async Task<IActionResult> PostAdm([FromBody] PostAuthAdmRequest request)
        {
            return await Post<PostAuthAdmRequest, PostAuthAdmHandler>(request);
        }
    }
}
