using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodEating
{
     class Db
    {
        SqlConnection connection = new SqlConnection("Server =REVISION-PC\\SQLEXPRESS; Database=GoodEatingBase;Trusted_Connection=True;");
        public void openConnection() {
            if (connection.State == System.Data.ConnectionState.Closed) 
                connection.Open();
        }
        public void closedConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
