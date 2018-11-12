using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace BaitaplonTKW
{
    public partial class dangky : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //kiểm tra email chưa tồn tại mới cho thực hiện đăng ký
            if (Datontaiemail(txtemail.Text))
            {
                ScriptManager.RegisterStartupScript(this,this.GetType(),"","alert('Email này đã được đăng ký,vui lòng nhập email khác')",true);
            }
            else
            {
                //nếu email chưa tồn tại, kiểm tra tên tài khoản có trùng không
                if (Datontaitentk(txtuser.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('ten tài khoản này đã được đăng ký,vui lòng nhập tên tài khoản khác')", true);
                }
                else
                {
                    //thêm mới tk khách hàng
                    con.Open();
                    SqlCommand cmd = new SqlCommand("them_nguoidung", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tentk", txtuser.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                   // cmd.Parameters.AddWithValue("@ngaysinh"
                    cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }
      
        //kiểm tra email đã tồn tại chưa 
        private bool Datontaiemail(string email)
        {
              con.Open();
              SqlCommand Cmd = new SqlCommand("nguoidung_byemail",con);
              Cmd.CommandType = CommandType.StoredProcedure;
              Cmd.Parameters.AddWithValue("@email", txtemail.Text);
              Cmd.ExecuteNonQuery();
              SqlDataReader datareader = Cmd.ExecuteReader();
              bool tontaiemail = datareader.HasRows;
              con.Close();
             return tontaiemail;
        }
        //kiểm tra tên tài khoản có trùng không (đã tồn tại chưa)
        private bool Datontaitentk(string tentaikhoan)
        {
            con.Open();
            SqlCommand Cmd = new SqlCommand("nguoidung_bytennd", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@tennd", txtuser.Text);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            bool tontaitaikhoan = datareader.HasRows;
            con.Close();
            return tontaitaikhoan;
        }
       
     

    }
}