namespace TCC_Backend.Domain.Models.SecaoEleitorais
{
    public class SecaoEleitoral : BaseEntity
    {
        public SecaoEleitoral()
        {
        }

        public SecaoEleitoral(string numero,
                              string localVotacao,
                              string endereco,
                              string zonaEleitoral,
                              string cidade)
        {
            Numero = numero;
            LocalVotacao = localVotacao;
            Endereco = endereco;
            ZonaEleitoral = zonaEleitoral;
            Cidade = cidade;
        }

        public string Numero { get; private set; } = string.Empty;
        public string LocalVotacao { get; private set; } = string.Empty;
        public string Endereco { get; private set; } = string.Empty;
        public string ZonaEleitoral { get; private set; } = string.Empty;   
        public string Cidade { get; private set; } = string.Empty;
    }
}
