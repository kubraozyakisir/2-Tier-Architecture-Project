using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Entity;
using System.Data;
using System.Data.SqlClient;

namespace Store.Facade
{
    public class FProduct
    {

        public static bool ProductEkle(EProduct item)
        {

            SqlCommand productadded = new SqlCommand("ProductEkle", Tools.Baglanti);
            productadded.CommandType = CommandType.StoredProcedure;
            productadded.Parameters.AddWithValue("PName", item.PName);
            productadded.Parameters.AddWithValue("CategoryID", item.CategoryID);
            productadded.Parameters.AddWithValue("Brand", item.Brand);
            productadded.Parameters.AddWithValue("Model", item.Model);
            productadded.Parameters.AddWithValue("PDescription", item.PDescription);
            productadded.Parameters.AddWithValue("Price", item.Price);        
            productadded.Parameters.AddWithValue("Stock", item.Stock);
            return Tools.ExecuteNonQuery(productadded);

        }
        public static DataTable ProductSearch(EProduct item)
        {
            SqlCommand search = new SqlCommand("ProductSearch", Tools.Baglanti);
            search.CommandType = CommandType.StoredProcedure;
            search.Parameters.AddWithValue("PID", item.PID);
            SqlDataAdapter x = new SqlDataAdapter(search);
            DataTable dt = new DataTable();
            x.Fill(dt);
            return dt;
        }
        public static bool ProductDelete(EProduct item)
        {
            SqlCommand deleted = new SqlCommand("ProductDelete", Tools.Baglanti);
            deleted.CommandType = CommandType.StoredProcedure;
            deleted.Parameters.AddWithValue("PID", item.PID);
            return Tools.ExecuteNonQuery(deleted);
        }
        public static bool ProductUpdate(EProduct item)
        {
            SqlCommand updated = new SqlCommand("ProductUpdate", Tools.Baglanti);
            updated.CommandType = CommandType.StoredProcedure;
            updated.Parameters.AddWithValue("PID", item.PID);
            updated.Parameters.AddWithValue("PName", item.PName);
            updated.Parameters.AddWithValue("CategoryID", item.CategoryID);
            updated.Parameters.AddWithValue("Brand", item.Brand);
            updated.Parameters.AddWithValue("Model", item.Model);
            updated.Parameters.AddWithValue("PDescription", item.PDescription);
            updated.Parameters.AddWithValue("Price", item.Price);
            updated.Parameters.AddWithValue("Stock", item.Stock);
            return Tools.ExecuteNonQuery(updated);

        }
        public static DataTable ProductList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("ProductList", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }
    }
}
