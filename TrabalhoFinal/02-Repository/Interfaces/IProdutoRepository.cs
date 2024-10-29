using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades.DTO;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Produto BuscarPorId(int produtoId);
    }
}
