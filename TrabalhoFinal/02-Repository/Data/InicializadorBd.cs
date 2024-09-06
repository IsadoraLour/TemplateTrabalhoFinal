using Dapper;
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
        public static void Inicializar()
        {
            using var connection = new SQLiteConnection("Data Source=Rotina.db");
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

            connection.Execute(commandoSQL);
        }
    }
}
