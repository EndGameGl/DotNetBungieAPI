using System;
using System.Data.SQLite;

namespace NetBungieAPI.Pipes
{
    internal class SQLiteDataPipe : IDisposable
    {
        private SQLiteConnection _connection;

        public SQLiteDataReader GetReader(string command)
        {
            var commandObj = new SQLiteCommand() { Connection = _connection, CommandText = command };
            return commandObj.ExecuteReader();
        }
        public static SQLiteDataPipe CreatePipe(string dbPath)
        {
            SQLiteDataPipe pipe = new SQLiteDataPipe() 
            { 
                _connection = new SQLiteConnection($"Data Source={dbPath}; Version=3;")
            };
            pipe._connection.Open();

            return pipe;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
