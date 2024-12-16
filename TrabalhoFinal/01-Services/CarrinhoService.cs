using Core._03_Entidades.DTO.Venda;
using TrabalhoFinal._01_Services.Interfaces;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal;

public class CarrinhoService : ICarrinhoServices
{
    public CarrinhoRepository repository { get; set; }

    public CarrinhoService(string _config)
    {
        repository = new CarrinhoRepository(_config);
    }

    public void Adicionar(Carrinho carrinho)
    {
        repository.Adicionar(carrinho);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Carrinho> Listar()
    {
        return repository.Listar();
    }

    public List<ReadVendaReciboDTO> ListarCarrinhoDoUsuario(int usuarioId)
    {
        return repository.ListarCarrinhoDoUsuario(usuarioId); 
    }

    public Carrinho BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }

    public void Editar(Carrinho editPessoa)
    {
        repository.Editar(editPessoa);
    }

    List<ReadVendaReciboDTO> ICarrinhoServices.ListarCarrinhoDoUsuario(int v)
    {
        throw new NotImplementedException();
    }
}
