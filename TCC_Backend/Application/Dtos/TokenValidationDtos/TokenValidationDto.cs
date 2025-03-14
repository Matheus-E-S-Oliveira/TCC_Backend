namespace TCC_Backend.Application.Dtos.TokenValidationDtos
{
    public class TokenValidationDto
    {
        public bool IsTokenValid { get; set; }

        public Guid Id { get; set; }

        public string Menssage { get; set; } = string.Empty;
    }
}
