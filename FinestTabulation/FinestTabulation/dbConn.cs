using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Sql;

namespace FinestTabulation
{
    class dbConn
    {
        SqlConnection conn;

        public SqlConnection getCon() {

            conn = new SqlConnection("Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=finestdb;Integrated Security=True");

            return conn;
        }

    }
}
