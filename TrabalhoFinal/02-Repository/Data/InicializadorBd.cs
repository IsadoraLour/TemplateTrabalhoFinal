using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._02_Repository.Data
{
    public static class InicializadorBd
    {
        private const string ConnectionString = "Data Source=Rotina.db";

        public static void Inicializar()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandoSQL = @"   
                 CREATE TABLE IF NOT EXISTS Pessoas(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 DataNascimento TEXT NOT NULL
                );";

                commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Atividades(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 Prioridade INTEGER NOT NULL
                );";
                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
