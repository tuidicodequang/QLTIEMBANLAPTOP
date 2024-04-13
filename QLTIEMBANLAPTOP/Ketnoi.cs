using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTIEMBANLAPTOP
{
   public class KetNoi
    {
        static string strcnn = "Data Source=.\\SQLEXPRESS;Initial Catalog= CUAHANGLAPTOP;Integrated Security=True";
        SqlConnection con = new SqlConnection(strcnn);
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }
    

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(strcnn);
        }

    }


}
