using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HECVAT_Survery.Pages
{
    public class ClientsModel : PageModel
    {

        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=sql.elmcsis.com;Initial Catalog=HECVAT_DB;Persist Security Info=True;User ID=hecvat;Password=byRQadsknbdkEnB!";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Sign_In_Table";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo client = new ClientInfo();
                                client.Customer_Username = reader.GetString(0);
                                client.Customer_Email = reader.GetString(1);
                                client.Customer_Phone = reader.GetString(2);
                                client.Customer_City = reader.GetString(3);
                                client.Customer_Product = reader.GetString(4);
                                client.Product_Description = reader.GetString(5);
                                client.Product_Privacy = reader.GetString(6);
                                client.Client_Password = reader.GetString(7);
                                client.Client_Password_Confirm = reader.GetString(8);

                                listClients.Add(client);
                            }
                        }

                    }

                }
            }
            catch (Exception)
            {

            }

        }
    }

    public class ClientInfo
    {
        public int Customer_ID;
        public string Customer_Username;
        public string Customer_Email;
        public string Customer_Phone;
        public string Customer_City;
        public string Customer_Product;
        public string Product_Description;
        public string Product_Privacy;
        public string Client_Password;
        public string Client_Password_Confirm;
    }

}
