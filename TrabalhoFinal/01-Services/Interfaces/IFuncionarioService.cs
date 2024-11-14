using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._01_Services.Interfaces
{
    public interface IFuncionarioService
    {
        void Adicionar(Funcionario funcionario);
        void Remover(int id);
        List<Funcionario> Listar();
        Funcionario BuscarPorId(int id);
        void Editar(Funcionario funcionarioEditado);

    }
}
