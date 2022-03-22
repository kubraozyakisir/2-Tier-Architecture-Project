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
    public class OrderDetails
    {
        public static bool OrderDAdd(Order_detail item)
        {
            SqlCommand added = new SqlCommand("OrderDetailAdd", Tools.Baglanti);
            added.CommandType = CommandType.StoredProcedure;
            added.Parameters.AddWithValue("ProductID", item.ProductID);
            added.Parameters.AddWithValue("ProductPrice", item.ProductPrice);
            added.Parameters.AddWithValue("Number", item.Number);
            added.Parameters.AddWithValue("UserID", item.UserID);
            return Tools.ExecuteNonQuery(added);

        }
        public static bool Calculate(Order_detail item)
        {
            SqlCommand calc = new SqlCommand("Calculate", Tools.Baglanti);
            calc.CommandType = CommandType.StoredProcedure;
            calc.Parameters.AddWithValue("ProductPrice", item.ProductPrice);
            calc.Parameters.AddWithValue("Number", item.Number);
 
            return Tools.ExecuteNonQuery(calc);

        }
        public static DataTable OrderList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("OrderDetailList", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
         
        public static DataTable OrderDetaySearch(Order_detail item)
        {
            SqlCommand x = new SqlCommand("OrderDetaySearch", Tools.Baglanti);
            x.CommandType = CommandType.StoredProcedure;
            x.Parameters.AddWithValue("OrderDetayID", item.OrderDetayID);
            SqlDataAdapter d = new SqlDataAdapter(x);
            DataTable dt = new DataTable();
            d.Fill(dt);
            return dt;
        }
        public static bool OrderDetailsUp(Order_detail item)
        {
            SqlCommand updated = new SqlCommand("UsersUpdate", Tools.Baglanti);
            updated.CommandType = CommandType.StoredProcedure;
            updated.Parameters.AddWithValue("OrderDetayID", item.OrderDetayID);
            updated.Parameters.AddWithValue("ProductID", item.ProductID);
            updated.Parameters.AddWithValue("ProductPrice", item.ProductPrice);
            updated.Parameters.AddWithValue("Number", item.Number);
            updated.Parameters.AddWithValue("UserID", item.UserID);
            return Tools.ExecuteNonQuery(updated);
        }

    }
}
