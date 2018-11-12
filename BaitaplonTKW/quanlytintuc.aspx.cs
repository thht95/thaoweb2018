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
    public partial class quanlytintuc : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            hiendanhsachtin();
        }
        private void hiendanhsachtin()
        {
            con.Open();
           // string sql = "select* from tintuc";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("hientin", con);
            adapter.Fill(dt);
            grvtin.DataSource = dt;
            grvtin.DataBind();
            con.Close();
        
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            string fileName="";
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Chọn hình ảnh cho tin tức')", true);

            }
            con.Open();
            SqlCommand cmd = new SqlCommand("themtin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tieude", txttieude.Text);
            cmd.Parameters.AddWithValue("@ndtomtat", txtndtomtat.Text);
            cmd.Parameters.AddWithValue("@nd", txtnoidung.Text);
            cmd.Parameters.AddWithValue("@ngaydang", DateTime.Now);
            cmd.Parameters.AddWithValue("@hinhanh", fileName);
            cmd.ExecuteNonQuery();
            con.Close();
            txtndtomtat.Text = "";
            txtnoidung.Text = "";
            txttieude.Text = "";
            hiendanhsachtin();
        }

       
        protected void grvtin_RowEditing(object sender, GridViewEditEventArgs e)
        {
             string mabantin = ((Label)grvtin.Rows[e.NewEditIndex].FindControl("lblmabantin")).Text;
             con.Open();
             SqlCommand Cmd = new SqlCommand("hientinbyma", con);
             Cmd.CommandType = CommandType.StoredProcedure;
             Cmd.Parameters.AddWithValue("@matin", mabantin);
             Cmd.ExecuteNonQuery();
             SqlDataReader datareader = Cmd.ExecuteReader();
             datareader.Read();
             lblmabantin.Text = mabantin;
             txttieude.Text = Convert.ToString(datareader["tieude"]);
             txtnoidung.Text = Convert.ToString(datareader["noidung"]);
             txtndtomtat.Text = Convert.ToString(datareader["ndtomtat"]);
            
             con.Close();

        }

        protected void btncapnhap_Click(object sender, EventArgs e)
        {
            string fileName = "";
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Chọn hình ảnh cho tin tức')", true);

            }
            con.Open();
            SqlCommand cmd = new SqlCommand("capnhaptin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mabantin", lblmabantin.Text);
            cmd.Parameters.AddWithValue("@tieude", txttieude.Text);
            cmd.Parameters.AddWithValue("@ndtomtat", txtndtomtat.Text);
            cmd.Parameters.AddWithValue("@nd", txtnoidung.Text);
            cmd.Parameters.AddWithValue("@ngaydang", DateTime.Now);
            cmd.Parameters.AddWithValue("@hinhanh", fileName);
            cmd.ExecuteNonQuery();
            con.Close();
            txtndtomtat.Text = "";
            txtnoidung.Text = "";
            txttieude.Text = "";
            hiendanhsachtin();
        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("xoatin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@matin", lblmabantin.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmabantin.Text = "";
            txtndtomtat.Text = "";
            txtnoidung.Text = "";
            txttieude.Text = "";
            hiendanhsachtin();
        }
    }
}