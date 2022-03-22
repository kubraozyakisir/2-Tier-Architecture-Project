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
    public class Users
    {
        public static bool UserAdd(User item)
        {
            SqlCommand added = new SqlCommand("UserAdd", Tools.Baglanti);
            added.CommandType = CommandType.StoredProcedure;
            added.Parameters.AddWithValue("Name",item.Name);
            added.Parameters.AddWithValue("LastName",item.LastName);
            added.Parameters.AddWithValue("EMail",item.EMail);
            added.Parameters.AddWithValue("Telephone",item.Telephone);
            added.Parameters.AddWithValue("TC",item.TC);
            return Tools.ExecuteNonQuery(added);

        }
        public static bool UserDelete(User item)
        {
            SqlCommand deleted = new SqlCommand("UserDelete", Tools.Baglanti);
            deleted.CommandType=CommandType.StoredProcedure;
            deleted.Parameters.AddWithValue("ID",item.ID);
            return Tools.ExecuteNonQuery(deleted);

        }
        public static DataTable UserList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("UserList",Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();  
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable UserSearch(User item)
        {
            SqlCommand x = new SqlCommand("UserSearch", Tools.Baglanti);
            x.CommandType = CommandType.StoredProcedure;
            x.Parameters.AddWithValue("ID", item.ID);
            SqlDataAdapter d = new SqlDataAdapter(x);
            DataTable dt = new DataTable();   
            d.Fill(dt);
            return dt;
        }
        public static bool UserUpdate(User item)
        {
            SqlCommand updated = new SqlCommand("UsersUpdate", Tools.Baglanti);
            updated.CommandType=CommandType.StoredProcedure;
            updated.Parameters.AddWithValue("ID", item.ID);
            updated.Parameters.AddWithValue("Name", item.Name);
            updated.Parameters.AddWithValue("LastName", item.LastName);
            updated.Parameters.AddWithValue("EMail", item.EMail);
            updated.Parameters.AddWithValue("Telephone", item.Telephone);
            updated.Parameters.AddWithValue("TC", item.TC);
            return Tools.ExecuteNonQuery(updated);
        }
    }
}
