﻿using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._01_Services;

public class PessoaService
{
    public PessoaRepository repository { get; set; }
    public PessoaService()
    {
        repository = new PessoaRepository();
    }
    public void Adicionar(Pessoa pessoa)
    {
        repository.Adicionar(pessoa);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Pessoa> Listar()
    {
        return repository.Listar();
    }
    public void BuscarTimePorId(int id)
    {
        //return repository.BuscarPorId(id);
    }
    public void Editar(int id, Pessoa editPessoa)
    {
        repository.Editar(id, editPessoa);
    }
}