using System.Text.Json.Serialization;
using TCC_Backend.Domain.Models.Servicos;

namespace TCC_Backend.Domain.Models.Perguntas;

public class Pergunta : BaseEntity
{
    public Pergunta() => Question = string.Empty;

    public Pergunta(int numero, string question, Guid idServico)
    {
        Numero = numero;
        Question = question;
        IdServico = idServico;
    }

    public int Numero { get; private set; }

    public string Question { get; private set; }

    public Guid IdServico { get; private set; }

    [JsonIgnore]
    public virtual Servico? Servico { get; set; }

    public void Update(int numero, string question)
    {
        Numero = numero;
        Question = question;
    }
}