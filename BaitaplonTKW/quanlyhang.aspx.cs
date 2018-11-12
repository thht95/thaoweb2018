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
    public partial class quanlyloaihang : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            hiendanhsachhang();
            hienthiloaihang();
        }
        private void hiendanhsachhang()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from vhangloaihang", con);
            adapter.Fill(dt);
            grvhang.DataSource = dt;
            grvhang.DataBind();
            con.Close();

        }
        private void hienthiloaihang()
        {
            string sql1 = "select *from loaihang";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, con);
            adapter.Fill(dt);
            ddlloaihang.DataTextField = "tenloaihang";
            ddlloaihang.DataValueField = "maloaihang";
            ddlloaihang.DataSource = dt;
            ddlloaihang.DataBind();
            ddlloaihang.Items.Insert(0, new ListItem("Loại hàng"));
        }
        protected void grvhang_RowEditing(object sender, GridViewEditEventArgs e)
        {

            string ma = ((Label)grvhang.Rows[e.NewEditIndex].FindControl("lblmahang")).Text;
            con.Open();
            SqlCommand Cmd = new SqlCommand("hienhangbyma", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", ma);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            datareader.Read();
            lblmahang.Text = ma;
            txttenhang.Text = Convert.ToString(datareader["tenhang"]);
            ddlloaihang.Text = Convert.ToString(datareader["maloaihang"]); ;
            con.Close();
        }
    }
}