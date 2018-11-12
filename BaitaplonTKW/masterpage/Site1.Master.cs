using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaitaplonTKW.masterpage
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        SqlConnection con1 = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra đã đăng nhập chưa
                if (Session["khachhang"] != null && Session["khachhang"].ToString() == "1")
                {
                    //đã đăng nhập
                    pldangnhap.Visible = true;
                    plchuadangnhap.Visible = false;
                    ltrtenkhachhang.Text = Session["tendangnhap"].ToString();
                }
                    //chưa đăng nhập hoặc đăng xuất
                if(Session["khachhang"] ==null) {
                    pldangnhap.Visible = false;
                    plchuadangnhap.Visible = true;

                }
                if (Session["admin"] != null && Session["admin"].ToString() == "1")
                {
                    ltrtenkhachhang.Text = Session["tendangnhap"].ToString();
                    plchuadangnhap.Visible = false;
                    pldangnhap.Visible = true;
                    pladmin.Visible = true;
                }
            
                sanphammoi();
                hiendanhmuc();
                TextBox1.Attributes.Add("placeholder", "Tìm kiếm sản phẩm");
            }
              
        }
        //
        public void sanphammoi()
        {
            string sql = "select top 2* from sanpham";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con1);
            adapter.Fill(dt);
            dtl.DataSource = dt;
            dtl.DataBind();
        }
        //
        public void hiendanhmuc()
        {
            string sql = "SELECT maloaihang,tenloaihang FROM loaihang";
            DataTable dt = new DataTable();
            
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con1);
            adapter.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Timkiemsanpham.aspx?t=" + TextBox1.Text);
        }
        protected void btndangnhap_Click(object sender, EventArgs e)
        {
            Response.Redirect("dangnhap.aspx");
        }
        protected void btndangky_Click(object sender, EventArgs e)
        {
            Response.Redirect("dangky.aspx");
        }
        protected void btndangxuat_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Session["Khachhang"] = null;
            Session["tendangnhap"] = null;
            Response.Redirect("~/Trangchu.aspx");
        }
    }
}