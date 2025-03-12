using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Adm.Commands.Post
{
    public class PostAdmRequest
    {
        [FromBody]
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}
