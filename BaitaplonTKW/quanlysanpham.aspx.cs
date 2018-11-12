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
    public partial class quanlysanpham : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hiendanhsachsanpham();
                hienthiloaihang();
                hienthihang();
               
            }
        }
        private void hiendanhsachsanpham()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("hiensanpham", con);
            adapter.Fill(dt);
            grvsanpham.DataSource = dt;
            grvsanpham.DataBind();
            con.Close();

        }
        //đổ dl vào ddl loại hàng
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
            ddlloaihang.Items.Insert(0,new ListItem("Loại hàng"));
        }
        //đổ dl vào dropdownlist -hãng
        private void hienthihang()
        {

            var a = ddlloaihang.SelectedValue;
            string sql = "select *from vhangloaihang";
            if (ddlloaihang.SelectedIndex > 0)
            {
                sql = sql + " where maloaihang=" + a;
            }
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dt);
                ddlhang.DataTextField = "tenhang";
                ddlhang.DataValueField = "mahang";
                ddlhang.DataSource = dt;
                ddlhang.DataBind();
            }
        //khi chọn loại sản phẩm
        protected void ddlloaihang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = ddlloaihang.SelectedValue;
            hienthihang();

        }


        protected void ddlhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var b = ddlhang.SelectedValue;
            
        }
        //ấn chọn trong grv (hiển thị lên control)
        protected void grvsanpham_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string ma = ((Label)grvsanpham.Rows[e.NewEditIndex].FindControl("lblma")).Text;
            con.Open();
            SqlCommand Cmd = new SqlCommand("hiensanphambyma", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", ma);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            datareader.Read();
            lblmasanpham.Text = ma;
            ddlloaihang.Text = Convert.ToString(datareader["maloaihang"]);
            ddlhang.Text = Convert.ToString(datareader["mahang"]);
            txttensp.Text = Convert.ToString(datareader["tensanpham"]);
            txtsoluong.Text = Convert.ToString(datareader["soluong"]);
            txtdongia.Text = String.Format("{0:0,0}", datareader["dongia"]);
            rbl_trangthai.Text = Convert.ToString(datareader["trangthai"]);
            con.Close();
        }
        protected void btnthem_Click(object sender, EventArgs e)
        {
            lblmess.Text = "";
            string fileName = "";
            var b = ddlhang.SelectedValue;
            if (hinhanh.HasFile)
            {
                fileName = "image/" + hinhanh.FileName;
                //Dòng lệnh này lấy đường dẫn tuyệt đối của tệp tin sẽ lưu trên website và lưu thông tin đó vào biến filePath.
                string filePath = MapPath(fileName);
                //Dòng lệnh dùng để lưu tệp tin lại theo đường dẫn filePath (đã có từ câu lệnh trên)
                hinhanh.SaveAs(filePath);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Chọn hình ảnh cho sản phẩm')", true);

            }
           
            con.Open();
            SqlCommand cmd = new SqlCommand("themsanpham", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tensanpham", txttensp.Text);
            cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
            cmd.Parameters.AddWithValue("@dongia", txtdongia.Text);
            cmd.Parameters.AddWithValue("@tenanh", fileName);
            cmd.Parameters.AddWithValue("@mahang", b);
            
            cmd.Parameters.AddWithValue("@trangthai", rbl_trangthai.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmasanpham.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "";
            hiendanhsachsanpham();
            lblmess.Text = "Sản phẩm đã được thêm";
        }
        protected void btncapnhap_Click(object sender, EventArgs e)
        {
            lblmess.Text = "";
            var b = ddlhang.SelectedValue;
            string fileName = "";
            if (hinhanh.HasFile)
            {
                fileName = "image/" + hinhanh.FileName;
                string filePath = MapPath(fileName);
                hinhanh.SaveAs(filePath);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Chọn hình ảnh cho sản phẩm')", true);

            }
            con.Open();
            SqlCommand cmd = new SqlCommand("capnhapsp", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mahang", b);
            cmd.Parameters.AddWithValue("@tensp", txttensp);
            cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);
            cmd.Parameters.AddWithValue("@dongia", txtdongia.Text);
            cmd.Parameters.AddWithValue("@trangthai", rbl_trangthai.Text);
            cmd.Parameters.AddWithValue("@tenanh", fileName);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmasanpham.Text = "";
             txttensp.Text = "";
             txtsoluong.Text = "";
             txtdongia.Text = "";
             hiendanhsachsanpham();
             lblmess.Text = "Sản phẩm đã được cập nhập";
        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            lblmess.Text = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("xoasanpham", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ma", lblmasanpham.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmasanpham.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "";
            hiendanhsachsanpham();
            lblmess.Text = "Sản phẩm đã được xóa";
        }


        
    }
}