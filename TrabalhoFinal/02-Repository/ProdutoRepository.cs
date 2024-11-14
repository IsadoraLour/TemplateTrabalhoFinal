using Core.Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidades;
using TrabalhoFinal._03_Entidades.DTO;

namespace TrabalhoFinal._02_Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string connectionString;

        public string ConnectionString { get; private set; }

        public ProdutoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Adicionar(Produto produto)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert(produto);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Produto produto = BuscarPorId(id);
            if (produto != null)
            {
                connection.Delete(produto);
            }
        }

        public void Editar(Produto produto)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Produto>(produto);
        }

        public List<Produto> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Produto>().ToList();
        }

        public Produto BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Produto>(id);
        }
    }
}
