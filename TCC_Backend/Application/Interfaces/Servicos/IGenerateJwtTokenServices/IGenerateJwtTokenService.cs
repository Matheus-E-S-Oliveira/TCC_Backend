namespace TCC_Backend.Application.Interfaces.Servicos.IGenerateJwtTokenServices
{
    public interface IGenerateJwtTokenService
    {
        string GenerateJwtToken(string username);
    }
}
