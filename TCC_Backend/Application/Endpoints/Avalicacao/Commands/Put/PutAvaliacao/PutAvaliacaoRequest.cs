﻿using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao
{
    public class PutAvaliacaoRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

        [FromBody]

        public string Token { get; set; } = string.Empty;

        public Dictionary<int, int>? Respostas { get; set; }

    }
}
