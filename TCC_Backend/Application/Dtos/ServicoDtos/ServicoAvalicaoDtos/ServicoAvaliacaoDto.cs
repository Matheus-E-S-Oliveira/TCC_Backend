namespace TCC_Backend.Application.Dtos.ServicoDtos.ServicoAvalicaoDtos
{
    public class ServicoAvaliacaoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public int NumeroDeAvaliacoes { get; set; }
        public decimal? Media { get; set; }
    }
}
