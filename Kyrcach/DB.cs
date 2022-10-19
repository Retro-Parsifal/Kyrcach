using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrcach
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306;username=root;password=;database=cellular");//подключение к БД

        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)//открытие связи
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)//закрытие связи
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
