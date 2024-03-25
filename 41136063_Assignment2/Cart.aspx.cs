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
    public partial class Cart : System.Web.UI.Page
    {
        //the connection string 
        public static string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\EvoDB.mdf;Integrated Security=True";

        //the 4 main classes 
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand com;
        SqlDataAdapter adapt;
        SqlDataReader dreader;



        protected void Page_Load(object sender, EventArgs e)
        {
            //Code to execute when the page is first loaded
            if (!Page.IsPostBack)
            {
                //connecting to the database 
                con = new SqlConnection(conStr);
                con.Open();
                con.Close();


                //clearing the listbox
                lstCart.Items.Clear();

                lstCart.Items.Add("Your order");
  

                //filling up the listbox
                ReadToCart("SELECT * FROM Cart");

               

                //The total cost
                int rPos; // = lstCart.Items[i].ToString().IndexOf('R');
                decimal cost; //= lstCart.Items[i].ToSting().SubString
                decimal totalCost = 0.0m;

                for (int i = 1; i < lstCart.Items.Count; i++)
                {
                    rPos = lstCart.Items[i].ToString().IndexOf('R');
                    cost = decimal.Parse(lstCart.Items[i].ToString().Substring(rPos + 2, 6));
                    totalCost = totalCost + cost;
                }

                //Adding the total cost to the session
                Session["orderCost"] = totalCost.ToString(); ;

                
                //checking if the session is null
                if (Session != null)
                {
                    //Adding the total cost to the listbox
                    lstCart.Items.Add("");
                    lstCart.Items.Add("Total cost: R" + Session["orderCost"]);
                }

               

                //Formatting the calendar
                //Setting the calender's selected date to today's date
                Calendar1.SelectedDate = DateTime.Today;

                //Disabling the relevant controls 
                btnDone.Enabled = false;
            }
        }

        

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
            catch(SqlException error)
            {
                lblError.Text = error.Message;
            }
           
        }

        //Reading
        private void ReadToCart(string sql)
        {
            //try block
            try
            {
                //opening the connection
                con.Open();
                //inst command 
                com = new SqlCommand(sql, con);
                //execute reader 
                dreader = com.ExecuteReader();
                //while reading 
                while (dreader.Read())
                {
                    //adding items to the listbox
                    lstCart.Items.Add(dreader.GetValue(0) + " " + dreader.GetValue(1) + ", " + '\t' + "R " + dreader.GetValue(2));
                }
                //closing the connection
                con.Close();
            }//catch block
            catch (SqlException error)
            {
                lblError.Text = error.Message;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Redirecting the user back to the store 
            Response.Redirect("Shop.aspx");
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            //disabling the relevent buttons
            btnAddItems.Enabled = false;
            btnRemoveItems.Enabled = false;
           
            
            //Object of the date time class
            DateTime orderDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            orderDate = Calendar1.SelectedDate;

            //adding 5 days to the estimated delivery day
            orderDate = orderDate.AddDays(5);
            //adding days to the order date, just incase it may be on a weekend
            if (orderDate.DayOfWeek.ToString() == "Friday")
            {
                orderDate = orderDate.AddDays(3);
            }
            else if (orderDate.DayOfWeek.ToString() == "Saturday")
            {
                orderDate = orderDate.AddDays(2);
            }
            else if (orderDate.DayOfWeek.ToString() == "Sunday")
            {
                orderDate = orderDate.AddDays(1);
            }

            //setting the selected date of the calendar control to the estimated delivery date 
            Calendar1.SelectedDate = orderDate;

           
            //Displaying a meessage to the user
            //Retrieving cookies by cookies name 
            HttpCookie user = Request.Cookies["userInfo"];
            //checking cookeis
            if(user != null)
            {
                lblMessage.ForeColor = System.Drawing.Color.White;
                //Message to the user after completing an order
                lblMessage.Text = "We appreciate your purchase, " + user["username"] + ". An email will be sent to you at " + user["email"] + " regarding your order. The expected delivery date for your order is " + orderDate.ToString("dd/MM/yyyy") + ". Kindly ensure that you have " + Session["orderCost"] + " available on the delivery date, as we solely accept cash upon delivery. Thank you for your support, and we look forward to serving you again in the future!";
            }

            //clearing the cart for the next user
            Delete("DELETE FROM Cart");

            //clearing the list box
            lstCart.Items.Clear();

            //Disabling the relevant controls 
            btnCompleteOrder.Enabled = false;
            //Enabling the relevant buttons 
            btnDone.Enabled = true;
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            //clearing the error label
            lblError.Text = "";

            //validating if a product to delete has been selected
            if (lstCart.SelectedIndex == -1)
            {
                lblError.Text = "Please select an item from the cart list that you want to delete.";
            }
            else
            {
                //getting the name of the product form the listbox
                int com = lstCart.SelectedItem.ToString().IndexOf(',');
                string name = lstCart.SelectedItem.ToString().Substring(0 + 2, com - 2);
                lblMessage.ForeColor = System.Drawing.Color.White;
                
                //calling the delete method to remove items from the cart 
                Delete("DELETE FROM Cart WHERE Name LIKE '%" + name + "%'");

                //clearing the listbox
                lstCart.Items.Clear();


                //showing the items that are in the cart
                lstCart.Items.Add("Your order");
                ReadToCart("SELECT * FROM Cart");

                //The total cost
                int rPos; // = lstCart.Items[i].ToString().IndexOf('R');
                decimal cost; //= lstCart.Items[i].ToSting().SubString
                decimal totalCost = 0.0m;

                for (int i = 1; i < lstCart.Items.Count; i++)
                {
                    rPos = lstCart.Items[i].ToString().IndexOf('R');
                    cost = decimal.Parse(lstCart.Items[i].ToString().Substring(rPos + 2, 6));
                    totalCost = totalCost + cost;
                }

                //Adding the total cost to the session
                Session["orderCost"] = totalCost.ToString(); ;


                //checking if the session is null
                if (Session != null)
                {
                    //Adding the total cost to the listbox
                    lstCart.Items.Add("");
                    lstCart.Items.Add("Total cost: R" + Session["orderCost"]);
                }
            }
        }

        protected void HyperLink1_Load(object sender, EventArgs e)
        {

        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        protected void lstCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            //Redirecting the user to the home page
            Response.Redirect("default.aspx");
        }
    }
}