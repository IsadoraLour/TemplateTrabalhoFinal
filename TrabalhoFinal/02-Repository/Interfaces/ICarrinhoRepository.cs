using Core._03_Entidades.DTO.Venda;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface ICarrinhoRepository
    {
        void Adicionar(Carrinho carrinho);
        void Remover(int id);

        void Editar(Carrinho carrinho);
        List<Carrinho> Listar();
        Carrinho BuscarPorId(int id);
        List<ReadVendaReciboDTO> ListarCarrinhoDoUsuario(int usuarioId);
    }
}
