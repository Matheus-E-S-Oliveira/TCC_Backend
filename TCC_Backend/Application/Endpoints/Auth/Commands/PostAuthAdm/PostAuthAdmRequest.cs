namespace TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm
{
    public class PostAuthAdmRequest
    {
        public string UserIdentify { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
