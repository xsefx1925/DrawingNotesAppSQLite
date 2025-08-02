using System.Data.SQLite;
using System.IO;

public class DatabaseManager
{
    private const string DbFileName = "drawingnotes.db";

    public static void InitializeDatabase()
    {
        if (!File.Exists(DbFileName))
        {
            SQLiteConnection.CreateFile(DbFileName);
            using (var connection = new SQLiteConnection($"Data Source={DbFileName}"))
            {
                connection.Open();
                string sql = @"
                    CREATE TABLE Drawings (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        DrawingName TEXT NOT NULL UNIQUE
                    );

                    CREATE TABLE NotesAndFiles (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Note TEXT,
                        FilePath TEXT,
                        DrawingId INTEGER,
                        FOREIGN KEY (DrawingId) REFERENCES Drawings(Id)
                    );
                ";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}