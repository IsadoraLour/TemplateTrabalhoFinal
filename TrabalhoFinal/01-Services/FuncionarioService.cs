using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._01_Services
{
    public class FuncionarioService
    {

        public FuncionarioRepository repository { get; set; }

        public FuncionarioService(string _config)
        {
            repository = new FuncionarioRepository(_config);
        }

        public void Adicionar(Funcionario funcionario)
        {
            repository.Adicionar(funcionario);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Funcionario> Listar()
        {
            return repository.Listar();
        }

        public Funcionario BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }

        public void Editar(Funcionario funcionarioEditado)
        {
            repository.Editar (funcionarioEditado);
        }

        
    }
}
