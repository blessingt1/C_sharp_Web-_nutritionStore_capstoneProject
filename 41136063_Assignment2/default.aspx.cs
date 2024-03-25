using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//signing the contract 
using System.Data.SqlClient;
using System.Data;


namespace _41136063_Assignment2
{
    public partial class _default : System.Web.UI.Page
    {
        //the connection string 
        public static string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EvoDB.mdf;Integrated Security=True";

        //the 4 main classes 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand com;
        SqlDataAdapter adapt;
        SqlDataReader dreader;

        //Methods

        //Delete method 
        public void Delete(string sql)
        {
            //try block
            try
            {
                //opening the connection 
                con.Open();
                //inst adapt
                adapt = new SqlDataAdapter();
                //inst com 
                com = new SqlCommand(sql, con);
                //delete command 
                adapt.DeleteCommand = com;
                //execute non query
                adapt.DeleteCommand.ExecuteNonQuery();
                //closing the connection
                con.Close();
            }//catch block
            catch (SqlException error)
            {
                //lblError.Text = error.Message;
            }

        }



        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Clearing the cart
            Delete("DELTE FROM Cart");
            //clearing cookies
            HttpCookie user = new HttpCookie("userInfo");
            user["username"] = "";
            user["email"] = "";
            user["orderprice"] = "";
            Response.Cookies.Add(user);

            //clearing up the sessoin
            Session["num"] = 1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Redirecting the user to the shopping page
            Response.Redirect("Shop.aspx");
        }
    }
}