using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._01_Services
{
    public class ProdutoService
    {
        public ProdutoRepository repository { get; set; }

        public ProdutoService(string _config)
        {
            repository = new ProdutoRepository(_config);
        }

        public void Adicionar(Produto produto)
        {
            repository.Adicionar(produto);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Produto> Listar()
        {
            return repository.Listar();
        }

        public Produto BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }

        public void Editar(Produto produtoEditado)
        {
            repository.Editar(produtoEditado);
        }
    }

}

