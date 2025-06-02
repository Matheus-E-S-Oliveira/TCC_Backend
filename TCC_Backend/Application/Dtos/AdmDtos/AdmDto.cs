namespace TCC_Backend.Application.Dtos.AdmDtos
{
    public class AdmDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
