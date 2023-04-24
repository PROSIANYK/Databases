using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace LR_3
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port =3306 ;
            string database = "mydb";
            string username ="monty" ;
            string password = "Julia040504";
            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
