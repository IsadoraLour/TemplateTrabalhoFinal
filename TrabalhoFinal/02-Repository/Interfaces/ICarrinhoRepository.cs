using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface ICarrinhoRepository
    {
        void Adicionar(Carrinho carrinho);
        void Remover(int id);

        void Editar(Carrinho carrinho);
        List<Carrinho> Listar();
        Carrinho BuscarPorId(int id);

    }
}
