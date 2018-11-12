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
    public partial class donhang : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            hiendonhang();
        }
        private void hiendonhang()
        {
            con.Open();
            DataTable cart = Session["cart"] as DataTable;
            int tong=0;
            foreach (DataRow dr in cart.Rows)
            {
                tong = tong + Convert.ToInt32(dr["Thành tiền"].ToString());
                dr["Thành tiền"] = String.Format("{0:0,0}", dr["Thành tiền"]);
            }
            lbltong.Text = String.Format("{0:0,0}", tong);
            grvdonhang.DataSource = cart;
            grvdonhang.DataBind();
            con.Close();

        }

        protected void btnquaylai_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Giohang.aspx");
        }

        protected void btndathang_Click(object sender, EventArgs e)
        {
            //thêm vào đơn đặt hàng
            con.Open();
            SqlCommand cmd = new SqlCommand("themdonhang", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma",SqlDbType.Int).Direction=ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@ngaylap", DateTime.Now);
            cmd.Parameters.AddWithValue("@matk",Convert.ToInt32( Session["mataikhoan"].ToString()));
            cmd.Parameters.AddWithValue("@ten",txtten.Text);
            cmd.Parameters.AddWithValue("@sdt", txtsdt.Text);
            cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            int kq=(Convert.ToInt32(cmd.Parameters["@ma"].Value));
            //thêm vào đơn đặt,sản phẩm
            con.Open();
            DataTable cart = Session["cart"] as DataTable;
           
            foreach (DataRow dr in cart.Rows)
            {
                SqlCommand Cmd = new SqlCommand("themdonhang_sanpham", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@ma", kq);
                Cmd.Parameters.AddWithValue("@masp", Convert.ToInt32(dr["Mã sản phẩm"].ToString()));
                Cmd.Parameters.AddWithValue("@soluong", Convert.ToInt32(dr["Số lượng"].ToString()));
                Cmd.Parameters.AddWithValue("@dongia", Convert.ToDouble(dr["Đơn giá"].ToString()));
                Cmd.ExecuteNonQuery();
            }
            //SqlCommand Cmd = new SqlCommand("themdonhang_sanpham", con);
            //Cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ma", kq);
            //cmd.Parameters.AddWithValue("@masp", kq);
            //thêm vào đơn đặt,sản phẩm
            con.Close();
        }
    }
}