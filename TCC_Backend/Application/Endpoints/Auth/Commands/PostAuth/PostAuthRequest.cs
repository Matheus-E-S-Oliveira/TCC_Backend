namespace TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth
{
    public class PostAuthRequest
    {
        public string UserIdentify { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
