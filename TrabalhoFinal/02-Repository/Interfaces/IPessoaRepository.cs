using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IPessoaRepository
    {
        List<Pessoa> Listar();
        Pessoa BuscarPorId(int id);
        void Remover(int id);
        void Editar(Pessoa p);
        void Adicionar(Pessoa pessoa);
    }
}
