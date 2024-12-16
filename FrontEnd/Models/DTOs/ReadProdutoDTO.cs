namespace FrontEnd.Models.DTOs
{
    public class ReadProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public override string ToString()
        {
            return $"Produto: {Nome} - Descrição: {Descricao} - Preço: {Preco:C} - Estoque: {Estoque}";
        }
    }
}
