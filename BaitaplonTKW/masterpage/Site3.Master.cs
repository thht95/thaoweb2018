using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaitaplonTKW.masterpage
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null && Session["admin"].ToString() == "1")
            {
                ltradmin.Text = Session["tendangnhap"].ToString();
            }
            else {
               // Response.Redirect("~/Trangchu.aspx");
            }
        }

        protected void btndangxuat_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Session["tendangnhap"] = null;
            Response.Redirect("~/quanly.aspx");
        }
    }
}