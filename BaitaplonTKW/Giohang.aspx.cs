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
    public partial class Giohang : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            hiengiohang();
        }
        private void hiengiohang()
        {

            con.Open();
            DataTable cart = Session["cart"] as DataTable;
            grvgiohang.DataSource = cart;
            grvgiohang.DataBind();
            con.Close();

        }

        protected void grvgiohang_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ma = ((Label)grvgiohang.Rows[e.RowIndex].FindControl("lblma")).Text;
            //duyệt qua giỏ hàng
            DataTable cart = Session["cart"] as DataTable;
            foreach(DataRow dr in cart.Rows)
            {
                if (dr["Mã sản phẩm"].ToString() == ma)
                  {
                     dr.Delete();
                       break;
                  }
            }

            Session["cart"] = cart;
            //hiển thị thông tin với gỏ hàng mới
            grvgiohang.DataSource = cart;
            grvgiohang.DataBind();
        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            Session["cart"] = null;
            DataTable cart = Session["cart"] as DataTable;
            grvgiohang.DataSource = cart;
            grvgiohang.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Giỏ hàng đã được xóa')", true);
        }

        protected void btnmuatiep_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Trangchu.aspx");
        }

        protected void btndathang_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/donhang.aspx");
        }

        protected void grvgiohang_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string ma = ((Label)grvgiohang.Rows[e.NewEditIndex].FindControl("lblma")).Text;
            DataTable cart = Session["cart"] as DataTable;
            foreach (DataRow dr in cart.Rows)
            {
                if (dr["Mã sản phẩm"].ToString() == ma)
                {
                    txtsoluong.Text = dr["Số lượng"].ToString();
                    lblten.Text = dr["Tên sản phẩm"].ToString();
                }
            }
            con.Close();
        }

        protected void btncapnhap_Click(object sender, EventArgs e)
        {
            string ten = lblten.Text;
            DataTable cart = Session["cart"] as DataTable;
            foreach (DataRow dr in cart.Rows)
            {
                if (dr["Tên sản phẩm"].ToString() == ten)
                {
                    dr["Số lượng"] = txtsoluong.Text;
                   
                }
            }
            con.Close();
            hiengiohang();
        }
    }
}