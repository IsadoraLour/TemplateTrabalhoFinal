using System.Data.SQLite;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._02_Repository;

public class PessoaRepository
{
    private const string ConnectionString = "Data Source=Rotina.db";
    public List<Pessoa> Listar()
    {
        List<Pessoa> lista = new List<Pessoa>();
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string selectCommand = "SELECT Id, Nome, DataNascimento FROM Pessoas;";
            using (var command = new SQLiteCommand(selectCommand, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pessoa p = new Pessoa();
                        p.Id = int.Parse(reader["Id"].ToString());
                        p.Nome = reader["Nome"].ToString();
                        p.DataNascimento = Convert.ToDateTime(reader["DataNascimento"].ToString());
                        lista.Add(p);
                    }
                }
            }
        }
        return lista;
    }
    public void Remover(int id)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string deleteCommand = "DELETE FROM Pessoas WHERE Id = @Id";
            using (var command = new SQLiteCommand(deleteCommand, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
    public void Editar(int id, Pessoa p)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string updateCommand = @"UPDATE Pessoas
                                  SET Nome = @Nome, DataNascimento = @DataNascimento
                                  WHERE Id = @Id";
            using (var command = new SQLiteCommand(updateCommand, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nome", p.Nome);
                command.Parameters.AddWithValue("@DataNascimento", p.DataNascimento);
                command.ExecuteNonQuery();
            }
        }
    }
    public void Adicionar(Pessoa pessoa)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string comandInsert = @"INSERT INTO Pessoas(Nome,DataNascimento) 
                                    VALUES (@Nome,@DataNascimento)";

            using (var command = new SQLiteCommand(comandInsert, connection))
            {
                command.Parameters.AddWithValue("@Nome", pessoa.Nome);
                command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
                command.ExecuteNonQuery();
            }
        }
    }
}

