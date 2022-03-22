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
    public class Orders
    {
        public static bool OrderAdd(Order item)
        {
            SqlCommand orderadded = new SqlCommand("OrderAdd", Tools.Baglanti);
            orderadded.CommandType=CommandType.StoredProcedure;
            orderadded.Parameters.AddWithValue("UserID", item.UserID);
            orderadded.Parameters.AddWithValue("UserAddress", item.UserAddress);
            orderadded.Parameters.AddWithValue("CreateDate", item.CreateDate);
            orderadded.Parameters.AddWithValue("TotalPrice", item.TotalPrice);
            orderadded.Parameters.AddWithValue("Order_detay_id", item.Order_detay_id);
            return Tools.ExecuteNonQuery(orderadded);

        }
        public static bool OrderDelete(Order item)
        {
            SqlCommand orderdeleted = new SqlCommand("OrderDelete", Tools.Baglanti);
            orderdeleted.CommandType = CommandType.StoredProcedure;
            orderdeleted.Parameters.AddWithValue("OrderDetayID", item.Order_detay_id);
            return Tools.ExecuteNonQuery(orderdeleted);
        }
        public static DataTable OrderList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("OrderList", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable OrderSearch(Order item)
        {
            SqlCommand search = new SqlCommand("OrderSearch", Tools.Baglanti);
            search.CommandType = CommandType.StoredProcedure;
            search.Parameters.AddWithValue("OID", item.OID);
            SqlDataAdapter x = new SqlDataAdapter(search);
            DataTable dt = new DataTable();
            x.Fill(dt);
            return dt;
        }
        public static bool OrderUpdate(Order item)
        {
            SqlCommand orderupdated = new SqlCommand("OrderUpdate", Tools.Baglanti);
            orderupdated.CommandType=CommandType.StoredProcedure;
            orderupdated.Parameters.AddWithValue("OID", item.OID);
            orderupdated.Parameters.AddWithValue("UserID", item.UserID);
            orderupdated.Parameters.AddWithValue("UserAddress", item.UserAddress);
            orderupdated.Parameters.AddWithValue("CreateDate", item.CreateDate);
            orderupdated.Parameters.AddWithValue("TotalPrice", item.TotalPrice);
            orderupdated.Parameters.AddWithValue("Order_detay_id", item.Order_detay_id);
            return Tools.ExecuteNonQuery(orderupdated); 
        }
    }
}
