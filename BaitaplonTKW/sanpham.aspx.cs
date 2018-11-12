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
    public partial class sanpham : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                load_datalist();
                hienthihang();
               
                ddl1_SelectedIndexChanged(sender, e);
            }
        }
        //đổ dl vào dropdownlist -hãng
        private void hienthihang()
        {
            string sql = "select *from vhangloaihang";
            //hiển thị hãng theo loại hàng
            if (Request.QueryString["x"] != null)
            {
                sql = sql + " where maloaihang=" + Request.QueryString["x"] + "";
            }
            
            
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
            adapter.Fill(dt);
            ddlhang.DataTextField = "tenhang";
            ddlhang.DataValueField = "mahang";
            ddlhang.DataSource = dt;
            ddlhang.DataBind();
            ddlhang.Items.Insert(0, new ListItem("Tất cả", "0"));
           
        }
        
        //khi chọn hãng
        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var b = ddlhang.SelectedValue;
            string sql;
            //chọn hãng có mã hãng ở trong csdl (trừ "tất cả")
            if (ddlhang.SelectedIndex > 0)
            {
                sql = "select* from vsanpham where mahang=" + b + "";
               
                if (Request.QueryString["x"] != null)
                {
                    sql = sql + "and maloaihang=" + Request.QueryString["x"];
                }
            }
                //trường hợp chọn "Tất cả"
            else
            {
                sql = "select* from vsanpham";
                if (Request.QueryString["x"] != null)
                {
                    sql = sql + " where maloaihang=" + Request.QueryString["x"];
                }
            }
              
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(dt);
            dtl.DataSource = dt;
            dtl.DataBind();
        }
        //đổ dữ liệu vào datalisst
        public void load_datalist()
        {
            PagedDataSource objPage = new PagedDataSource();
            string sql = "select* from vsanpham";
            //khi chọn loại sản phẩm ở phần danh mục
            if (Request.QueryString["x"] != null)
            {
                sql = sql + " where maloaihang=" + Request.QueryString["x"];
            }
           
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
             DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtl.DataSource = dt;
            dtl.DataBind();
            con.Close();
         
        }

       
    }
}