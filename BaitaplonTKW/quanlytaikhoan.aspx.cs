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
    public partial class quanlytaikhoan : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            hiendanhtaikhoan();
        }
        private void hiendanhtaikhoan()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("hiennguoidung", con);
            adapter.Fill(dt);
            grvtaikhoan.DataSource = dt;
            grvtaikhoan.DataBind();
            con.Close();

        }

        protected void grvtaikhoan_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string mataikhoan = ((Label)grvtaikhoan.Rows[e.NewEditIndex].FindControl("lblma")).Text;
            con.Open();
            SqlCommand Cmd = new SqlCommand("nguoidung_byma", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", mataikhoan);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            datareader.Read();
            lblma.Text = mataikhoan;
            txtten.Text = datareader["tentaikhoan"].ToString();
            txtpass.Text = datareader["pass"].ToString();
            txtemail.Text = datareader["email"].ToString();
            rbl_gioitinh.Text = datareader["gioitinh"].ToString();
            rbl_quyen.Text = datareader["maquyen"].ToString();
            con.Close();
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("themtk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ten", txtten.Text);
            cmd.Parameters.AddWithValue("@email",txtemail.Text);
            cmd.Parameters.AddWithValue("@pass", txtpass.Text);
            cmd.Parameters.AddWithValue("@maquyen",Convert.ToInt32(rbl_quyen.Text));
            cmd.Parameters.AddWithValue("@gt",rbl_gioitinh.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblma.Text = null;
            txtten.Text = null;
            txtpass.Text = null;
            txtemail.Text = null;
            rbl_gioitinh.Text = null;
            rbl_quyen.Text = null;
            hiendanhtaikhoan();
        }

        protected void btncapnhap_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("capnhaptk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ma", lblma);
            cmd.Parameters.AddWithValue("@ten", txtten.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@pass", txtpass.Text);
            cmd.Parameters.AddWithValue("@maquyen", Convert.ToInt32(rbl_quyen.Text));
            cmd.Parameters.AddWithValue("@gt", rbl_gioitinh.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblma.Text = null;
            txtten.Text = null;
            txtpass.Text = null;
            txtemail.Text = null;
            rbl_gioitinh.Text = null;
            rbl_quyen.Text = null;
            hiendanhtaikhoan();
        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("xoatk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ma", lblma);
            cmd.ExecuteNonQuery();
            con.Close();
            lblma.Text = null;
            txtten.Text = null;
            txtpass.Text = null;
            txtemail.Text = null;
            rbl_gioitinh.Text = null;
            rbl_quyen.Text = null;
            hiendanhtaikhoan();
        }
    }
}