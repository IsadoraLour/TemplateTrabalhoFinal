using Core.Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository;

public class UsuarioRepository
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
        connection.Update(usuario);
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

    public Usuario BuscarPorUsername(string username)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.QuerySingleOrDefault<Usuario>(
            "SELECT * FROM Usuarios WHERE Username = @Username",
            new { Username = username });
    }
}
