using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidades.DTO;

namespace TrabalhoFinal._02_Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private string connectionString;

        public ProdutoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Produto BuscarPorId(int produtoId)
        {
            throw new NotImplementedException();
        }
    }
}
