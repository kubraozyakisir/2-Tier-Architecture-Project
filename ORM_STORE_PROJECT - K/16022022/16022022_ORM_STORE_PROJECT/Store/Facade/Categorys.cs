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
    public class Categorys
    {
        public static DataTable ToSearch(Category item)
        {

            SqlCommand search = new SqlCommand("CategorySearch", Tools.baglanti);
            search.CommandType = CommandType.StoredProcedure;
            search.Parameters.AddWithValue("CID", item.CID);
            SqlDataAdapter adapter = new SqlDataAdapter(search);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static bool CDelete(Category item)
        {

            SqlCommand delete = new SqlCommand("CategorySil", Tools.Baglanti);
            delete.CommandType = CommandType.StoredProcedure;
            delete.Parameters.AddWithValue("CID", item.CID);
            return Tools.ExecuteNonQuery(delete);
        }
        public static bool CAdd(Category item)
        {
            SqlCommand cadd = new SqlCommand("CategoryEkle", Tools.Baglanti);
            cadd.CommandType=CommandType.StoredProcedure;
            cadd.Parameters.AddWithValue("ParentID", item.ParentID);
            cadd.Parameters.AddWithValue("Name",item.Name);
            cadd.Parameters.AddWithValue("IsActive",item.IsActive);
            return Tools.ExecuteNonQuery(cadd);
        }
        public static bool CUpdate(Category item)   
        {
            SqlCommand cupdate = new SqlCommand("CategoryUpdate", Tools.Baglanti);
            cupdate.CommandType = CommandType.StoredProcedure;
            cupdate.Parameters.AddWithValue("CID",Convert.ToInt32(item.CID));    
            cupdate.Parameters.AddWithValue("ParentID",Convert.ToInt32(item.CID));    
            cupdate.Parameters.AddWithValue("Name", item.Name);
            cupdate.Parameters.AddWithValue("IsActive", Convert.ToBoolean(item.IsActive));
            return Tools.ExecuteNonQuery (cupdate);

        }
        public static DataTable CList()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("CategoryList", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
      


    }
}
