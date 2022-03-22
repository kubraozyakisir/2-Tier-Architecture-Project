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
    public class UAdress
    {

        public static bool UAdd(UserAdres item)
        {
            SqlCommand added = new SqlCommand("UserAdressAdd", Tools.Baglanti);
            added.CommandType = CommandType.StoredProcedure;
            added.Parameters.AddWithValue("UserID", item.UserID);
            added.Parameters.AddWithValue("Title", item.Title);
            added.Parameters.AddWithValue("City", item.City);
            added.Parameters.AddWithValue("Adress", item.Adress);

            return Tools.ExecuteNonQuery(added);

        }
        public static bool UUpdate(UserAdres item)
        {
            SqlCommand updated = new SqlCommand("UserAddressUpdate", Tools.Baglanti);
            updated.CommandType = CommandType.StoredProcedure;
            updated.Parameters.AddWithValue("UID", item.UID);
            updated.Parameters.AddWithValue("UserID", item.UserID);
            updated.Parameters.AddWithValue("Title", item.Title);
            updated.Parameters.AddWithValue("City", item.City);
            updated.Parameters.AddWithValue("Adress", item.Adress);

            return Tools.ExecuteNonQuery(updated);
        }
        public static bool UDelete(UserAdres item)
        {
            SqlCommand deleted = new SqlCommand("UserAdressDelete", Tools.Baglanti);
            deleted.CommandType = CommandType.StoredProcedure;
            deleted.Parameters.AddWithValue("UID", item.UID);
            return Tools.ExecuteNonQuery(deleted);
        }
        public static DataTable UList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("UserAdressList", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }
        public static DataTable USearch(UserAdres item)
        {
            SqlCommand search = new SqlCommand("UserAdresSearch", Tools.Baglanti);
            search.CommandType = CommandType.StoredProcedure;
            search.Parameters.AddWithValue("UID", item.UID);
            SqlDataAdapter x = new SqlDataAdapter(search);
            DataTable dt = new DataTable();
            x.Fill(dt);
            return dt;
        }
    }
}
