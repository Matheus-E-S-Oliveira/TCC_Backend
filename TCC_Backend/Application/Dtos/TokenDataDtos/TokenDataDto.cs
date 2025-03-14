namespace TCC_Backend.Application.Dtos.TokenDataDtos
{
    public class TokenDataDto
    {
        public TokenDataDto()
        {
        }

        public TokenDataDto(string sub, string type)
        {
            Sub = sub;
            Type = type;
        }

        public string? Sub { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
    }
}
