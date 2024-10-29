using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._01_Services.Interfaces
{
    public interface IPessoasServices
    {
        void Editar(int id, Pessoa editPessoa);
        void Adicionar(Pessoa pessoa);
        List<Pessoa> Listar();
        void BuscarTimePorId(int id);
        void Remover(int id);

    }
}
