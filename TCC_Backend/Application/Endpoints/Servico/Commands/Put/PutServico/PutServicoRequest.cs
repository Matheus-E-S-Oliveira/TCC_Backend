using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using TCC_Backend.Application.Dtos.PerguntasDtos;

namespace TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico
{
    public class PutServicoRequest
    {
        [FromBody]
        [JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("localizacao")]
        public string Localizacao { get; set; } = string.Empty;

        [JsonPropertyName("imagem")]
        public string Imagem { get; set; } = string.Empty;

        [JsonPropertyName("urlSite")]
        public string UrlSite { get; set; } = string.Empty;

        [JsonPropertyName("perguntas")]
        public List<PerguntaDto> Perguntas { get; set; } = [];
    }
}
