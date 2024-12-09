﻿using Core._03_Entidades;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades.DTO;

namespace TrabalhoFinal._02_Repository.Interfaces
{
    public interface IVendaRepository
    {
        void Adicionar(Venda venda);
        void Remover(int id);
        void Editar(Venda venda);
        List<Venda> Listar();
    }
}
