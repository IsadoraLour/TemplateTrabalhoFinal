using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._02_Repository;

public class AtividadeRepository
{
    private const string ConnectionString = "Data Source=Rotina.db";
    public List<Atividade> Listar()
    {
        List<Atividade> lista = new List<Atividade>();
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string selectCommand = "SELECT Id, Nome, Prioridade FROM Atividades;";
            using (var command = new SQLiteCommand(selectCommand, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Atividade a = new Atividade();
                        a.Id = int.Parse(reader["Id"].ToString());
                        a.Nome = reader["Nome"].ToString();
                        a.Prioridade = Convert.ToInt32(reader["DataNascimento"].ToString());
                        lista.Add(a);
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
            string deleteCommand = "DELETE FROM Atividades WHERE Id = @Id";
            using (var command = new SQLiteCommand(deleteCommand, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
    public void Editar(int id, Atividade a)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string updateCommand = @"UPDATE Atividades
                                  SET Nome = @Nome, Prioridade = @Prioridade
                                  WHERE Id = @Id";
            using (var command = new SQLiteCommand(updateCommand, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nome", a.Nome);
                command.Parameters.AddWithValue("@Prioridade", a.Prioridade);
                command.ExecuteNonQuery();
            }
        }
    }
    public void Adicionar(Atividade atividade)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string comandInsert = @"INSERT INTO Atividades(Nome,Prioridade) 
                                    VALUES (@Nome,@Prioridade)";

            using (var command = new SQLiteCommand(comandInsert, connection))
            {
                command.Parameters.AddWithValue("@Nome", atividade.Nome);
                command.Parameters.AddWithValue("@Prioridade", atividade.Prioridade);
                command.ExecuteNonQuery();
            }
        }
    }
}
