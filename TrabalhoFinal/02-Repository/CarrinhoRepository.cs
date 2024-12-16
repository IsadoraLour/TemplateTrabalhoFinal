using Core._03_Entidades.DTO.Venda;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;

namespace TrabalhoFinal._02_Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly string ConnectionString;
        private readonly ProdutoRepository _repositoryProduto;
        private readonly UsuarioRepository _repositoryUsuario;

        public CarrinhoRepository(string connectionString)
        {
            ConnectionString = connectionString;
            _repositoryProduto = new ProdutoRepository(connectionString);
            _repositoryUsuario = new UsuarioRepository(connectionString);
        }

        public void Adicionar(Carrinho carrinho)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Carrinho>(carrinho);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Carrinho carrinho = BuscarPorId(id);
            connection.Delete<Carrinho>(carrinho);
        }

        public void Editar(Carrinho carrinho)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Carrinho>(carrinho);
        }

        public List<Carrinho> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Carrinho>().ToList();
        }

        public List<ReadVendaReciboDTO> ListarCarrinhoDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> list = connection.Query<Carrinho>($"SELECT * FROM Carrinhos WHERE UsuarioId = {usuarioId}").ToList();
            return TransformarListaCarrinhoEmCarrinhoDTO(list);
        }

        private List<ReadVendaReciboDTO> TransformarListaCarrinhoEmCarrinhoDTO(List<Carrinho> list)
        {
            throw new NotImplementedException();
        }

        public Carrinho BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Carrinho>(id);
        }
    }
}













