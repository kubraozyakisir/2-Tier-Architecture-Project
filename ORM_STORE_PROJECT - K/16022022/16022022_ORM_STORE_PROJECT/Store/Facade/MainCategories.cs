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
    public class MainCategories
    {
        public static bool MainCategoryDelete(MainCategory item)
        {

            SqlCommand delete = new SqlCommand("Main_category_delete", Tools.Baglanti);
            delete.CommandType = CommandType.StoredProcedure;
            delete.Parameters.AddWithValue("ParentID", item.ParentID);
            return Tools.ExecuteNonQuery(delete);
        }
        public static bool MainCategoryAdd(MainCategory item)
        { 
            //maincategoryden seçilen her biri için item bir nesnedir ve onunla çağrılır.
            SqlCommand mainadd = new SqlCommand("Main_category_add", Tools.Baglanti);
            mainadd.CommandType = CommandType.StoredProcedure;  
            mainadd.Parameters.AddWithValue("ParentName", item.ParentName);
            return Tools.ExecuteNonQuery(mainadd);
        }
        public static bool MainCategoryUpdate(MainCategory item)
        {
            SqlCommand mainupdate = new SqlCommand("Main_category_update", Tools.Baglanti);
            mainupdate.CommandType = CommandType.StoredProcedure;
            mainupdate.Parameters.AddWithValue("ParentID", item.ParentID);
            mainupdate.Parameters.AddWithValue("ParentName", item.ParentName);
         
            return Tools.ExecuteNonQuery(mainupdate);

        }
        public static DataTable MainCategoryList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Main_category_list", Tools.Baglanti);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable MainSearch(MainCategory item)
        {
            SqlCommand search = new SqlCommand("MainSearch", Tools.Baglanti);
            search.CommandType = CommandType.StoredProcedure;
            search.Parameters.AddWithValue("ParentID", item.ParentID);
            SqlDataAdapter x = new SqlDataAdapter(search);
            DataTable dt = new DataTable();
            x.Fill(dt);
            return dt;

        }
    }
}
