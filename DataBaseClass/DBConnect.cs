using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseClass
{
    internal class DBConnect
    {
        private static string host = ConfigurationManager.AppSettings["host"];
        private static string database = ConfigurationManager.AppSettings["database"];
        private static string username = ConfigurationManager.AppSettings["username"];
        private static string password = ConfigurationManager.AppSettings["password"];
        private static string charset = "utf8";
        private static MySqlConnection connection = null;
        private static string connectionString = null;
        private static DBConnect instance = null;
        private DBConnect()
        {
            connectionString = $"Server={host};Database={database};Uid={username};Pwd={password};Charset={charset}";
        }
        public static DBConnect GetInstance()
        {
            if(instance == null)
            {
                instance = new DBConnect();
            }
            return instance;
        }
        public MySqlConnection GetSqlConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection(connectionString);
            }
            try
            {
                connection.Open();
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return connection;
        }
    }
}
