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
