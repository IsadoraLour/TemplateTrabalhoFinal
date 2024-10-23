using Core._03_Entidades;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class VendaService
{
    public VendaRepository repository { get; set; }

    public VendaService(string _config)
    {
        repository = new VendaRepository(_config);
    }

    public void Adicionar(Venda venda)
    {
        repository.Adicionar(venda);    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Venda> Listar()
    {
        return repository.Listar();
    }

    public ReadVendaReciboDTO BuscarVendaPorId(int id)
    {
        return repository.BuscarPorId(id);
    }

    public void Editar(Venda vendaEditada)
    {
        repository.Editar(vendaEditada);
    }

    public List<Venda> ListarVendasPorCliente(int clienteId)
    {
        return repository.ListarVendasPorCliente(clienteId);
    }

    public decimal CalcularTotalVenda(int vendaId)
    {
        var venda = repository.BuscarPorId(vendaId);
        return venda.Itens.Sum(item => item.Preco * item.Quantidade);
    }
}
