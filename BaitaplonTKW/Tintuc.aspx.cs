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
    public partial class Tintuc : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR;Initial Catalog=BTL;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            load_datalist();
        }
        public void load_datalist()
        {

            string sql = "select * from tintuc";

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(dt);
            dtl.DataSource = dt;
            dtl.DataBind();
        }
    }
}