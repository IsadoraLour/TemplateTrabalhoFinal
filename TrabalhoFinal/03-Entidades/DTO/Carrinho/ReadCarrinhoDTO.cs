﻿using TrabalhoFinal;

namespace Core._03_Entidades.DTO.Carrinhos
{
    public class ReadCarrinhoDTO
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
        public string ToStringProduto()
        {
            return $"Produto : {Produto.Nome} - Preço: {Produto.Preco}";
        }
    }
}
