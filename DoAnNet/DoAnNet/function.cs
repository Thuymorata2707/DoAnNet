using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace DoAnNet
{
    internal class function

    {
        protected SqlConnection getConnection()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=pharmacy;Integrated Security=True";
            //return con;
            SqlConnection con = new SqlConnection(@"Data Source=THUYTEO\SQLEXPRESS;Initial Catalog=pharmacyy;Integrated Security=True");
            return con;

        }
        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable LayDuLieu(string query)
        {
            SqlConnection con = new SqlConnection(@"Data Source=THUYTEO\SQLEXPRESS;Initial Catalog=pharmacyy;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
    
    public void setData(String query, String msg)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
