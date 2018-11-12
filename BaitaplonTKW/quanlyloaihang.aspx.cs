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
    public partial class quanlyhang : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            hiendanhsachloaihang();
            
        }
        //hiện lên grvS
        private void hiendanhsachloaihang()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from loaihang", con);
            adapter.Fill(dt);
            grvloaihang.DataSource = dt;
            grvloaihang.DataBind();
            con.Close();

        }
        //sự kiện rowediting(khi ấn chọn)
        protected void grvloaihang_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string ma = ((Label)grvloaihang.Rows[e.NewEditIndex].FindControl("lblmaloaihang")).Text;
            con.Open();
            SqlCommand Cmd = new SqlCommand("hienloaihangbyma", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", ma);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            datareader.Read();
            lblmaloaihang.Text = ma;
            txttenloaihang.Text = Convert.ToString(datareader["tenloaihang"]);
            con.Close();
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("themloaihang", con);
            cmd.CommandType = CommandType.StoredProcedure;
             // cmd.Parameters.AddWithValue("@ma", lblmaloaihang.Text);
            cmd.Parameters.AddWithValue("@ten", txttenloaihang.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmaloaihang.Text = "";
            txttenloaihang.Text="";
           hiendanhsachloaihang();
            lblmess.Text = "Loại hàng đã được thêm";
        }

        protected void btncapnhap_Click(object sender, EventArgs e)
        {
             con.Open();
            SqlCommand cmd = new SqlCommand("capnhaploaihang", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ten", txttenloaihang.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmaloaihang.Text = "";
            txttenloaihang.Text="";
           hiendanhsachloaihang();
            lblmess.Text = "Loại hàng đã được cập nhập";
        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            //chưa viết proc 
            /*
            con.Open();
            SqlCommand cmd = new SqlCommand("xoaloaihang", con);
            cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@ma", lblmaloaihang.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmaloaihang.Text = "";
            txttenloaihang.Text="";
           hiendanhsachloaihang();
            lblmess.Text = "Loại hàng đã được cập nhập";*/
        }
    }
}