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
    public partial class Shop : System.Web.UI.Page
    {
        //the connection string 
        public string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EvoDB.mdf;Integrated Security=True";

        //the 4 main classes 
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter adapt;
        SqlDataReader dreader;

        //Methods

        //Display to product list method
        private void DisplayList(string sql)
        {
            //try block
            try
            {   
                con = new SqlConnection(conStr);
                //opening the conection
                con.Open();
                com = new SqlCommand(sql, con);
                dreader = com.ExecuteReader();
                //whlie reading
                while (dreader.Read())
                {
                    lstProducts.Items.Add(dreader.GetValue(2) + " " + dreader.GetValue(1) + "," + '\t' + dreader.GetValue(3) + '\t' + "R " + dreader.GetValue(4));
                }
                con.Close();
            }//catch block
            catch(SqlException error)
            {
                lblError.Text = error.Message;
            }
        }
        //ReadToCart method
        private void AddToCart(string sql)
        {
            //try block
            try
            {
                con = new SqlConnection(conStr);
                //opening the connection
                con.Open();
                adapt = new SqlDataAdapter();
                com = new SqlCommand(sql, con);
                adapt.InsertCommand = com;
                adapt.InsertCommand.ExecuteNonQuery();
                con.Close();
            }//catch block
            catch(SqlException error)
            {
                lblError.Text = error.Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //Code to execute when the page is first loaded
            if (!Page.IsPostBack)
            {
                //connecting to the database 
                con = new SqlConnection(conStr);
                con.Open();
                con.Close();
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            //clearing the list box
            lstProducts.Items.Clear();


            //Displaying products from the product table based of the users selection 
            if (rbGain.Checked)
            {
                DisplayList("SELECT * FROM Products WHERE Type = 'Mass gainer'");
            }  
            else if (rbLose.Checked)
            {
                DisplayList("SELECT * FROM Products WHERE Type = 'Fat burner'"); 
            }
            else if (rbPerformance.Checked)
            {
                DisplayList("SELECT * FROM Products WHERE Type = 'Performance'");
            }
            else if (rbVegan.Checked)
            {
                DisplayList("SELECT * FROM Products WHERE Type LIKE '%Vegan%'"); 
            }
            else
            {
                lblError.Text = "Please select an item from the options provided";
            }

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            //If nothing is selected
            if (lstProducts.SelectedIndex == -1)
            {
                lblError.Text = "Please select an item from the list above";
            }
            else
            {
                //extracting the name
                int cPos = lstProducts.SelectedItem.ToString().IndexOf(',');
                string name = lstProducts.SelectedItem.ToString().Substring(0, cPos);
                //extracting the price
                int pPos = lstProducts.SelectedItem.ToString().IndexOf('R');
                decimal price = decimal.Parse(lstProducts.SelectedItem.ToString().Substring(pPos + 1, 6));

                //Adding the items to the cart
                AddToCart($"INSERT INTO Cart VALUES('{(int)(Session["num"])}','{name}','{price}')");

                lblError.ForeColor = System.Drawing.Color.White;
                lblError.Text = "Item " + Session["num"] + " has been added to the cart successfully";

                //incrementing num by 1 everytime an item is added to the cart
                Session["num"] = (int)(Session["num"]) + 1;

                //clearing the listbox
                lstProducts.Items.Clear();
            }
        }

        protected void btnGoToCart_Click(object sender, EventArgs e)
        {
            //validating the email address
            if(txtEmail.Text.IndexOf('@') < 1 || txtEmail.Text.IndexOf('.') < 3)
            {
                lblError.Text = "Please enter a valid email address"; 
            }
            else
            {
                //Creating a cookie for the user 
                HttpCookie userI = new HttpCookie("userInfo");
                userI["username"] = txtUsername.Text;
                userI["email"] = txtEmail.Text;
                Response.Cookies.Add(userI);
                Session["username"] = txtUsername.Text;
                
                //redirecting the user to the cart page
                Response.Redirect("Cart.aspx");
            }
        }
    }
}