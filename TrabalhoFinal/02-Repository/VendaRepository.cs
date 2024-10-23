using Core._03_Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository
{
    public class VendaRepository
    {
        private readonly string ConnectionString;
        private readonly CarrinhoRepository _repositoryCarrinho;
        private readonly UsuarioRepository _repositoryUsuario;
       

        public VendaRepository(string connectionString)
        {
            ConnectionString = connectionString;
            _repositoryCarrinho = new CarrinhoRepository(connectionString);
            _repositoryUsuario = new UsuarioRepository(connectionString);
            
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
            connection.Update(venda);
        }

        public List<Venda> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Venda>().ToList();
        }

        public ReadVendaReciboDTO BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            var venda = connection.Get<Venda>(id);
            if (venda == null) return null;

            var vendaDTO = new ReadVendaReciboDTO
            {
                Endereco = _repositoryEndereco.BuscarPorId(venda.EnderecoId),
                NomeUsuario = _repositoryUsuario.BuscarPorId(venda.UsuarioId)?.Nome,
                MetodoPagamento = venda.MetodoPagamento,
                Produtos = _repositoryCarrinho.ListarCarrinhoDoUsuario(venda.UsuarioId),
                ValorFinal = venda.ValorFinal
            };

            return vendaDTO;
        }
    }
}
