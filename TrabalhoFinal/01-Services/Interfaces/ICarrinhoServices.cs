using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades.DTO;

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
