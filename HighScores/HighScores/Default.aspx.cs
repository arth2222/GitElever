using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HighScores
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            InsertToDB();
            BindData();
        }

        private void BindData()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["hsconnstrLocalDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from HS",conn);

            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();
        }

        private void InsertToDB()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["hsconnstrLocalDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            int score = 1;
            string username = "Kjell";

            SqlCommand cmd = new SqlCommand("INSERT INTO HS (score,username) values (@score,@username)", conn);

            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.ExecuteNonQuery();
        }
    }
}