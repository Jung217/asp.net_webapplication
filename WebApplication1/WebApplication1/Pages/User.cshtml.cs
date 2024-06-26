using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace WebApplication1.Pages
{
    public class UserModel : PageModel
    {
        [BindProperty]
        public string user_id { get; set; }

        [BindProperty]
        public DataTable dataTable { get; set; }

        [BindProperty]
        public string WelcomeMessage { get; set; }

        public void OnGet()
        {
            user_id = HttpContext.Session.GetString("userId");
            if (user_id == null) Response.Redirect("Login3");
            else if (user_id != "admin") Response.Redirect("Usera");
            else
            {
                string user_name = HttpContext.Session.GetString("userName");
                WelcomeMessage = "Hello, " + user_name + ". Nice to meet you.";
                ShowUsers();
            }
        }

        private void ShowUsers()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();
 
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM [Member]";
            var reader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
        }

        public void OnPostAdd()
        {
            Response.Redirect("UserAdd");
        }

        public void OnPostUpdate(string id)
        {
            string href = "UserEdit?id=" + id;
            Response.Redirect(href);
        }

        public void OnPostDelete(string id)
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Member WHERE id = @id";
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

            connection.Close();

            Response.Redirect("User");
        }

        public void OnPostLogout()
        {
            HttpContext.Session.Remove("userId");
            Response.Redirect("Login3");
        }
    }
}
