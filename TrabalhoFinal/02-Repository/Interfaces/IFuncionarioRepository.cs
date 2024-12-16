

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        void Adicionar(Funcionario funcionario);
        void Remover(int id);
        void Editar(Funcionario funcionario);
        List<Funcionario> Listar();
        Funcionario BuscarPorId(int id);
    }
}
