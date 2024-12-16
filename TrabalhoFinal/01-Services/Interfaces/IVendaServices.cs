namespace TrabalhoFinal._01_Services.Interfaces
{
    public interface IVendaServices
    {
        void Adicionar(Venda venda);
        void Remover(int id);
        void Editar(Venda venda);
        List<Venda> Listar();
        Venda BuscarPorId(int id);
    }
}
