using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;

namespace TrabalhoFinal._02_Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {


        public string ConnectionString { get; }

        public FuncionarioRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Adicionar(Funcionario funcionario)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert(funcionario);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Funcionario funcionario = BuscarPorId(id);
            if (funcionario != null)
            {
                connection.Delete(funcionario);
            }
        }

        public void Editar(Funcionario funcionario)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Funcionario>(funcionario);
        }

        public List<Funcionario> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Funcionario>().ToList();
        }

        public Funcionario BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Funcionario>(id);
        }
    }
}
