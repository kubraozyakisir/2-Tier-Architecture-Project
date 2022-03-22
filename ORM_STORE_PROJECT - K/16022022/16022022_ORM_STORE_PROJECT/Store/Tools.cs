using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Store
{
    public class Tools
    {
        public static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["ORM_STORE"].ConnectionString);

        public static SqlConnection Baglanti
        {
            get { return baglanti; }
            set { baglanti = value; }
        }


        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                return komut.ExecuteNonQuery() > 0;
            }
            catch
            {
                return false;

            }
            finally
            {
                if (komut.Connection.State != ConnectionState.Closed)
                    komut.Connection.Close();
            }

        }
    }
}

