using Core._03_Entidades.DTO.Venda;

namespace TrabalhoFinal._01_Services.Interfaces
{
    public interface ICarrinhoServices 
    {
        void Adicionar(Carrinho carrinho);
        void Remover(int id);
        void Editar(Carrinho carrinho);
        List<Carrinho> Listar();
        Carrinho BuscarTimePorId(int id);
        List<ReadVendaReciboDTO> ListarCarrinhoDoUsuario(int v);
    }
}
