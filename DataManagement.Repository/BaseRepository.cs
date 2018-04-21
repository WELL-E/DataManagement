using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataManagement.Repository
{
    public class BaseRepository : IDisposable
    {
        protected IDbConnection Conn;

        public BaseRepository()
        {
            var strConn = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "yh123456",
                Database = "DataManagement",
                SslMode = MySqlSslMode.None
            };
            Conn = new MySqlConnection(strConn.ToString());
        }
        public void Dispose()
        {
            Conn.Close();
        }
    }
}
