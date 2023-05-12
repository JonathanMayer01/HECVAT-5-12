using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HECVAT_Survery.Pages
{
    public class Signup_FormModel : PageModel
    {
       public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String wrongPassword = "";
        public String success = "";
        public void OnPost()
        {
            clientInfo.Customer_Username = Request.Form["username"];
            clientInfo.Customer_Email = Request.Form["email"];
            clientInfo.Customer_Phone = Request.Form["Phone_number"];
            clientInfo.Customer_City = Request.Form["Vendor_city"];
            clientInfo.Customer_Product = Request.Form["productName"];
            clientInfo.Product_Description = Request.Form["productDescription"];
            clientInfo.Product_Privacy = Request.Form["Privacy_notice"];
            clientInfo.Client_Password = Request.Form["password"];
            clientInfo.Client_Password_Confirm = Request.Form["confirm_password"];


            if(clientInfo.Customer_Username.Length == 0 || clientInfo.Customer_Email.Length==0 ||
                clientInfo.Customer_Phone.Length==0 || clientInfo.Customer_City.Length==0 || clientInfo.Customer_Product.Length==0
                || clientInfo.Product_Description.Length == 0 || clientInfo.Product_Privacy.Length == 0 
                || clientInfo.Client_Password.Length == 0 || clientInfo.Client_Password_Confirm.Length ==0)
            {
                errorMessage = "All fields must be filled out";
                return;
            }


            if(clientInfo.Client_Password != clientInfo.Client_Password_Confirm)
            {
                wrongPassword = "Passwords must be matching";
                return;
            }

            try
            {

                string connectionString = "Data Source=sql.elmcsis.com;Initial Catalog=HECVAT_DB;Persist Security Info=True;User ID=hecvat;Password=byRQadsknbdkEnB!";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Sign_In_Table" +
                        "(Username, Email, Phone_number, City, Product_name, Product_Description, Privacy_Notice, Password, Confirm_password) VALUES"
                        + "(@Customer_Username, @Customer_Email, @Customer_Phone, @Customer_City, @Customer_Product, @Product_Description, @Product_Privacy, @Client_Password, @Client_Password_Confirm);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_Username", clientInfo.Customer_Username);
                        command.Parameters.AddWithValue("@Customer_Email", clientInfo.Customer_Email);
                        command.Parameters.AddWithValue("@Customer_Phone", clientInfo.Customer_Phone);
                        command.Parameters.AddWithValue("@Customer_City", clientInfo.Customer_City);
                        command.Parameters.AddWithValue("@Customer_Product", clientInfo.Customer_Product);
                        command.Parameters.AddWithValue("@Product_Description", clientInfo.Product_Description);
                        command.Parameters.AddWithValue("@Product_Privacy", clientInfo.Product_Privacy);
                        command.Parameters.AddWithValue("@Client_Password", clientInfo.Client_Password);
                        command.Parameters.AddWithValue("@Client_Password_Confirm", clientInfo.Client_Password_Confirm);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            clientInfo.Customer_Username = "";
            clientInfo.Customer_Email = "";
            clientInfo.Customer_Phone = "";
            clientInfo.Customer_City = "";
            clientInfo.Product_Description = "";
            clientInfo.Product_Privacy = "";
            clientInfo.Client_Password = "";
            clientInfo.Client_Password_Confirm = "";

            success = "New Client Login Added Successfully";

            Response.Redirect("/Login_Page");
        }

    }

}
    
