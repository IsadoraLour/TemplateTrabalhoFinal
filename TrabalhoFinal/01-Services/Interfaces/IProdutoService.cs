using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades;

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
