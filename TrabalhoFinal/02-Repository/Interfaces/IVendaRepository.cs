﻿namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IVendaRepository
    {
        void Adicionar(Venda venda);
        void Remover(int id);
        void Editar(Venda venda);
        List<Venda> Listar();
    }
}
