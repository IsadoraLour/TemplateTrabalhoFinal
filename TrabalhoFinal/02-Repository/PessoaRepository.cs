using Dapper.Contrib.Extensions;
using System.Configuration;
using System.Data.SQLite;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._02_Repository;

public class PessoaRepository
{
    private readonly string ConnectionString;
    public PessoaRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }
    public List<Pessoa> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Pessoa>().ToList();
    }
    public Pessoa BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Pessoa>(id);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Pessoa p = BuscarPorId(id);
        connection.Delete<Pessoa>(p);
    }
    public void Editar(Pessoa p)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Pessoa>(p);
    }
    public void Adicionar(Pessoa pessoa)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Pessoa>(pessoa);
    }
}

