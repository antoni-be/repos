using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    public class Saver
    {
        public void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection("Data Source=results.db;Version=3;"))
            {
                connection.Open();
                //usuwamy starą tabelę jeśli istnieje
                string dropTableQuery = "DROP TABLE IF EXISTS ShortestConnections;";
                using (var command = new SQLiteCommand(dropTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                //tworzymy nową tabelę z wynikami
                string createTableQuery =
                @"
                    CREATE TABLE ShortestConnections (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Start TEXT,
                        End TEXT,
                        Path TEXT,
                        Distance INTEGER
                    );
                ";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery() ;
                }
            }
        }
        public void SaveShortestRoute(string StartCity, string EndCity, string Path, int Distance)
        {
            using (var connection = new SQLiteConnection("Data Source=results.db;Version=3;"))
            {
                connection.Open();
                {
                    string insertQuery =
                    @"
                        INSERT INTO ShortestConnections (Start, End, Path, Distance)
                        VALUES (@Start, @End, @Path, @Distance);    
                    ";
                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Start", StartCity);
                        command.Parameters.AddWithValue("@End", EndCity);
                        command.Parameters.AddWithValue("@Path", Path);
                        command.Parameters.AddWithValue("@Distance", Distance);
                        command.ExecuteNonQuery();
                    }
                    
                }
            }
        }
    }

    
}
