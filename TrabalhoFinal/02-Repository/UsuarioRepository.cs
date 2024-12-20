﻿using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;

namespace TrabalhoFinal._02_Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string ConnectionString;

    public UsuarioRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public void Adicionar(Usuario usuario)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert(usuario);
    }

    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Usuario usuario = BuscarPorId(id);
        if (usuario != null)
        {
            connection.Delete(usuario);
        }
    }

    public void Editar(Usuario usuario)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Usuario>(usuario);
    }

    public List<Usuario> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Usuario>().ToList();
    }

    public Usuario BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Usuario>(id);
    }
}

 
