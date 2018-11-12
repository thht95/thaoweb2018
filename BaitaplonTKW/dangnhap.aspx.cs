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
    public partial class dannhap : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //kiểm tra user có trong tồn tại bản ghi ko nếu có lấy pass,user ở bản ghi để kiểm tra vs pass,users đã nhập,đúng thì đăng nhập thành công
                    con.Open();
                    SqlCommand Cmd = new SqlCommand("nguoidung_bytennd", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@tennd",txtuser.Text);
                    Cmd.ExecuteNonQuery();
                    SqlDataReader datareader = Cmd.ExecuteReader();
                    datareader.Read(); 
                    if (datareader.HasRows)
                    {
                        string user = datareader["tentaikhoan"].ToString();
                        string pass = datareader["pass"].ToString();
                        user = user.TrimEnd();
                        pass = pass.TrimEnd();//cắt khoảng trắng cuối chuỗi
                        string user_nhap = txtuser.Text;
                        string pass_nhap = txtpass.Text;
                        //nếu mật khẩu ở bản ghi bằng mật khẩu nhập thì đăng nhập thành công
                        if (pass==pass_nhap && user==user_nhap)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Thanhcong')", true);
                            if (Convert.ToInt32(datareader["maquyen"]) == 2)
                            {
                                Session["Khachhang"] = "1";//gán session =1 thể hiện đăng nhập thành công
                                Session["tendangnhap"] = user_nhap;//lấy tên đăng nhập
                               Session["mataikhoan"] = Convert.ToInt32(datareader["mataikhoan"].ToString());
                                Response.Redirect("Trangchu.aspx");
                            }
                            if (Convert.ToInt32(datareader["maquyen"]) == 1)
                            {
                                Session["tendangnhap"] = datareader["tentaikhoan"].ToString();
                                Session["admin"] = "1";//gán session =1 thể hiện đăng nhập thành công
                                Response.Redirect("quanly.aspx");
                            }
                        }
                        //ngược lại, thì mật khẩu sai
                      else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Tên tài khoản hoặc mật khẩu sai')", true);
                        }
                    }
                        //ko có bản ghi nào thì thông báo tk chưa dky
                   else {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Tên tài khoản chưa được đăng ký, vui lòng nhập lại')",true);

                    }
                    con.Close();
            }
        
        
        }
    }
