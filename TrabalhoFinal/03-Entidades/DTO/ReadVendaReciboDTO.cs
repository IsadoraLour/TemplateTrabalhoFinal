namespace TrabalhoFinal._03_Entidades.DTO
{
    public class ReadVendaReciboDTO
    {
        public Endereco Endereco { get; set; } // Supondo que Endereco seja uma classe representando o endereço
        public string NomeUsuario { get; set; }
        public string MetodoPagamento { get; set; }
        public List<Produto> Produtos { get; set; } // Supondo que Produto é uma classe representando os produtos no carrinho
        public decimal ValorFinal { get; set; }
        public object Senha { get; internal set; }
        public string Username { get; internal set; }

        public ReadVendaReciboDTO(Endereco endereco, string nomeUsuario, string metodoPagamento, List<Produto> produtos, decimal valorFinal)
        {
            Endereco = endereco;
            NomeUsuario = nomeUsuario;
            MetodoPagamento = metodoPagamento;
            Produtos = produtos;
            ValorFinal = valorFinal;
        }
    }
}
