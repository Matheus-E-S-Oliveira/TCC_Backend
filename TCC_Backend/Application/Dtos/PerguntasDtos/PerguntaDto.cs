namespace TCC_Backend.Application.Dtos.PerguntasDtos
{
    public class PerguntaDto
    {
        public int Numero { get; set; }
        public string Question { get; set; } = string.Empty;
        public Guid? IdPergunta { get; set; }
    }
}