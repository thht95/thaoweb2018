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
    public partial class Chitietsanpham : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BTL;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["x"] != null)
                {
                    int masapham = Convert.ToInt32(Request.QueryString["x"]);
                    hiensanpham();
                    hiensplienquan();
                    
                  
                }
                else
                {
                    lb.Text = "Lỗi";
                    Label5.Text = "";
                    Label6.Text = "";
                }
            }
        }
        public void hiensanpham()
        {
                       string sql = "select  masanpham,tensanpham,soluong,dongia,tenanh,tenhang,mahang,case trangthai when 'False' then N'Hết hàng' when 'True' then N'Còn hàng' end as trangthai from vsanpham where masanpham=" + Request.QueryString["x"];
                       SqlCommand Cmd = new SqlCommand(sql, con);
                        Cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rd = Cmd.ExecuteReader();
                            if (rd.HasRows && rd.Read())
                            {
                                tenanh.ImageUrl = rd["tenanh"].ToString();
                                sanpham.Text = rd["tensanpham"].ToString();
                                tenhang.Text = rd["tenhang"].ToString();
                                dongia.Text = String.Format("{0:0,0}", rd["dongia"]);
                                trangthai.Text = rd["trangthai"].ToString();
                                int i ;
                                for (i = Convert.ToInt32(rd["soluong"].ToString()); i >= 1; i--)
                                {
                                    ddlsoluong.Items.Add("" +i);
                                }
                            //    btnthem.CommandArgument = masanpham.ToString();
                            rd.Close();
                        con.Close();
                    }
       }
        
        public void hiensplienquan()
        {
            
                string sql = "select * from sanpham where mahang in (select mahang from vsanpham where masanpham="
                    + Request.QueryString["x"] + ") EXCEPT(select *from sanpham where masanpham=" + Request.QueryString["x"] + ")";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dt);
                DataList1.DataSource = dt;
                DataList1.DataBind();
            
        }
        //thêm sản phẩm vào giỏ
        private void themsanpham(int ma,string ten,int soluong,double dongia,string tenhang)
        {
            if (Session["khachhang"] != null && Session["khachhang"].ToString() == "1")
            {
                DataTable cart = new DataTable();
                //nếu chưa có giỏ hàng thì tạo giỏ hàng
                if (Session["cart"] == null)
                {
                    cart.Columns.Add("Mã sản phẩm");
                    cart.Columns.Add("Tên sản phẩm");
                    cart.Columns.Add("Tên hãng");
                    cart.Columns.Add("Số lượng");
                    cart.Columns.Add("Đơn giá");
                    cart.Columns.Add("Thành tiền");
                    Session["cart"] = cart;
                }
                //nếu có r thì gán giỏ hàng bằng session
                else
                {
                    cart = Session["cart"] as DataTable;
                }
                //nếu trong giỏ hàng có sản phẩm r thì kiểm tra sản phẩm muốn thêm có trong giỏ hàng chưa      
                bool tontai = false;
                if (cart.Rows.Count != 0)
                {
                    foreach (DataRow dr in cart.Rows)
                    {
                        //nếu sản phẩm đã có trong giỏ thi tăng số lượng và thành tiền
                        if (Convert.ToInt32(dr["Mã sản phẩm"].ToString()) == ma)
                        {
                            dr["Số lượng"] = int.Parse(dr["Số lượng"].ToString()) + soluong;
                            dr["Thành tiền"] = (int.Parse(dr["Số lượng"].ToString()) + soluong) * dongia;
                            tontai = true;
                            break;
                        }


                    }
                    //nếu sản phẩm chưa có trong giỏ thêm vào
                    if (!tontai)
                    {

                        DataRow dr = cart.NewRow();
                        dr["Mã sản phẩm"] = ma;
                        dr["Tên sản phẩm"] = ten;
                        dr["Tên hãng"] = tenhang;
                        dr["Số lượng"] = soluong;
                        dr["Đơn giá"] = dongia;
                        dr["Thành tiền"] = soluong * dongia;
                        cart.Rows.Add(dr);
                    }
                }
                //nếu trong giỏ hàng chưa có giỏ hàng thì thêm sp vào
                else
                {
                    DataRow dr = cart.NewRow();
                    dr["Mã sản phẩm"] = ma;
                    dr["Tên sản phẩm"] = ten;
                    dr["Tên hãng"] = tenhang;
                    dr["Số lượng"] = soluong;
                    dr["Đơn giá"] = dongia;
                    dr["Thành tiền"] = soluong * dongia;
                    cart.Rows.Add(dr);
                }

                //chưa có giỏ hàng thì sau khi tạo thêm hang vào giỏ

                Session["cart"] = cart;
            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Vui lòng đăng nhập để mua hàng')", true);
            
            }
        }
        protected void btnthem_Click(object sender, EventArgs e)
        {
            
            int ma = Convert.ToInt32(Request.QueryString["x"]);
            con.Open();
            SqlCommand Cmd = new SqlCommand("hiensanphambyma", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", ma);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            datareader.Read();
            string ten = datareader["tensanpham"].ToString();
            string tenhang = datareader["tenhang"].ToString();
            int soluong = Convert.ToInt32(ddlsoluong.SelectedValue);
            double dongia = Convert.ToDouble(datareader["dongia"]);
            con.Close();
            themsanpham(ma, ten, soluong, dongia,tenhang);
            var x = (Literal) this.Master.FindControl("ltrCart");
            x.Text = "Đã thêm " + ten + " vào giỏ hàng";
        }

        protected void btnmuangay_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt32(Request.QueryString["x"]);
            con.Open();
            SqlCommand Cmd = new SqlCommand("hiensanphambyma", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@ma", ma);
            Cmd.ExecuteNonQuery();
            SqlDataReader datareader = Cmd.ExecuteReader();
            datareader.Read();
            string ten = datareader["tensanpham"].ToString();
            string tenhang = datareader["tenhang"].ToString();
            int soluong = Convert.ToInt32(ddlsoluong.SelectedValue);
            double dongia = Convert.ToDouble(datareader["dongia"]);
            con.Close();
            themsanpham(ma, ten, soluong, dongia, tenhang);
            Response.Redirect("Giohang.aspx");
        }

      

       
    }
}