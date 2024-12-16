namespace TrabalhoFinal
{
    public class Carrinho
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal Total { get; set; }
    }
}
