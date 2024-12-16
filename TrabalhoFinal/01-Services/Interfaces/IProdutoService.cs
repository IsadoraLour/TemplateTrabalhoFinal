
namespace TrabalhoFinal._01_Services.Interfaces
{
    public interface IProdutoService
    {
        void Adicionar(Produto produto);
        void Remover(int id);
        List<Produto> Listar();
        Produto BuscarPorId(int id);
       void Editar(Produto produtoEditado);

    }
}
