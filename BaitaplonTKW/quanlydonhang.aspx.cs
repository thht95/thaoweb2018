using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaitaplonTKW
{
    public partial class quanlydonhang : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            hiendanhdonhang();
        }
        private void hiendanhdonhang()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("hiendonhang", con);
            adapter.Fill(dt);
            grvdonhang.DataSource = dt;
            grvdonhang.DataBind();
            con.Close();

        }
        protected void grvdonhang_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string ma = ((Label)grvdonhang.Rows[e.NewEditIndex].FindControl("lblma")).Text;
            con.Open();
            SqlCommand Cmd = new SqlCommand("donhang_byma", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", ma);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            datareader.Read();
            lblma.Text = ma;
            rbl_trangthai.Text = datareader["tinhtrang"].ToString();
            con.Close();

        }

        protected void btngui_Click(object sender, EventArgs e)
        {
            con.Open();
            int ma = Convert.ToInt32(lblma.Text);
            SqlCommand Cmd = new SqlCommand("capnhapdonhang", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", ma);
            Cmd.Parameters.AddWithValue("@tinhtrang", rbl_trangthai.Text);
            Cmd.ExecuteNonQuery();
            con.Close();
            lblma.Text = "";
            rbl_trangthai.Text = "";
        }
    }
}