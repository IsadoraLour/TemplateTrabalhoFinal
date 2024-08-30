using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._01_Services
{
    public class AtividadeService
    {
        public AtividadeRepository repository { get; set; }
        public AtividadeService()
        {
            repository = new AtividadeRepository();
        }
        public void Adicionar(Atividade pessoa)
        {
            repository.Adicionar(pessoa);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Atividade> Listar()
        {
            return repository.Listar();
        }
        public void BuscarTimePorId(int id)
        {
            //return repository.BuscarPorId(id);
        }
        public void Editar(int id, Atividade editAtividade)
        {
            repository.Editar(id, editAtividade);
        }
    }
}
