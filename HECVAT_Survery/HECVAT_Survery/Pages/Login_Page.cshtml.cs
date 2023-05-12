using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HECVAT_Survery.Pages
{
    public class Login_PageModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string Login { get; set; }
        public string Password { get; set; }

        public String errorMessage = "";
        public String success = "";

        public void OnPost()
        {

        }

        public void OnGet()
        {
            String id = Request.Query["ID"];

            try
            {
                string connectionString = "Data Source=sql.elmcsis.com;Initial Catalog=HECVAT_DB;Persist Security Info=True;User ID=hecvat;Password=byRQadsknbdkEnB!";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                  
                }
            }
            catch(Exception ex) 
            {
                errorMessage = ex.Message;
                return;
            }

        }
    }
}
