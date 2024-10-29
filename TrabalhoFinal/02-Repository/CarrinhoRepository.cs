using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidades;
using TrabalhoFinal._03_Entidades.DTO;

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

        // Adicionar novo carrinho
        public void Adicionar(Carrinho carrinho)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Carrinho>(carrinho);
        }

        // Remover carrinho por id
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Carrinho carrinho = BuscarPorId(id);
            connection.Delete<Carrinho>(carrinho);
        }

        // Editar carrinho existente
        public void Editar(Carrinho carrinho)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Carrinho>(carrinho);
        }

        // Listar todos os carrinhos
        public List<Carrinho> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Carrinho>().ToList();
        }

        // Listar carrinhos de um usuário específico
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

        // Buscar carrinho por id
        public Carrinho BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Carrinho>(id);
        }
    }
}













