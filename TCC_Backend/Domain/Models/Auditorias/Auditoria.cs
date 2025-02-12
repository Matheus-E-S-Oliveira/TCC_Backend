namespace TCC_Backend.Domain.Models.Auditorias
{
    public class Auditoria : BaseEntity
    {
        public string Entidade { get; set; } = null!; // Nome da tabela
     
        public string ChavePrimaria { get; set; } = null!; // ID do registro alterado
        
        public string Acao { get; set; } = null!; // INSERT, UPDATE ou DELETE
        
        public string? Propriedade { get; set; } // Nome da propriedade alterada
        
        public string? ValorAntigo { get; set; } // Valor antes da alteração
        
        public string? ValorNovo { get; set; } // Valor depois da alteração
        
        public string Usuario { get; set; } = null!; // Quem fez a alteração
    
    }
}
