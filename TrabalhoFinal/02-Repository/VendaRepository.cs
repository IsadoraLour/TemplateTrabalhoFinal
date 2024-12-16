using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;

namespace TrabalhoFinal._02_Repository
{
    public class VendaRepository : IVendaRepository 
    {
        private readonly string ConnectionString;
        private readonly CarrinhoRepository _repositoryCarrinho;
        private readonly UsuarioRepository _repositoryUsuario;
        private readonly FuncionarioRepository _repositoryFuncionario;


        public VendaRepository(string connectionString)
        {
            ConnectionString = connectionString;
            _repositoryCarrinho = new CarrinhoRepository(connectionString);
            _repositoryUsuario = new UsuarioRepository(connectionString);
            _repositoryFuncionario = new FuncionarioRepository(connectionString);


        }

        public void Adicionar(Venda venda)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert(venda);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            var venda = BuscarPorId(id);
            if (venda != null)
            {
                connection.Delete(venda);
            }
        }

        public void Editar(Venda venda)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Venda>(venda);
        }

        public List<Venda> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Venda>().ToList();
        }

        public Venda BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Venda venda = connection.Get<Venda>(id);
            return venda;
        }

        internal List<Venda> ListarVendasPorCliente(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
