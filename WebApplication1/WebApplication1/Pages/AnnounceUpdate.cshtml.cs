using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.Data.SqlClient;
using System.Numerics;
namespace WebApplication1.Pages
{
    public class AnnounceUpdateModel : PageModel
    {
        [BindProperty]
        public string who { get; set; }
        [BindProperty]
        public string ann_id { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "標題未輸入")]
        public string ann_title { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "內容未輸入")]
        public string ann_content { get; set; }

        [BindProperty]
        public string ann_time { get; set; }

        [BindProperty]
        public string ann_who { get; set; }
        [BindProperty]
        public string message { get; set; }
        public void OnGet(string id) //id = null
        {
            try
            {
                
                who = HttpContext.Session.GetString("userId");
                if (who != "admin") Response.Redirect("Login3");
                ShowAnn(id);
            }
            catch
            {
                Response.Redirect("Announce");
            }
        }
        private void ShowAnn(string id)
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM [Announce] WHERE id = @id";
            command.Parameters.AddWithValue("id", id);
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                ann_id = reader[0].ToString();
                ann_title = reader[1].ToString();
                ann_content = reader[2].ToString();
                ann_time = reader[3].ToString();
                ann_who = reader[4].ToString();
            }
            connection.Close();
        }
        public void OnPostUpdate(string id)
        {
            bool ok = false;
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var command1 = connection.CreateCommand();
                command1.CommandText = @"UPDATE Announce SET title = @title, content = @content, who = @who WHERE Id = @Id";
                command1.Parameters.AddWithValue("title", ann_title);
                command1.Parameters.AddWithValue("content", ann_content);
                command1.Parameters.AddWithValue("who", ann_who);
                command1.Parameters.AddWithValue("Id", BigInteger.Parse(id));
                command1.ExecuteNonQuery();
                //message = command1.CommandText;
                transaction.Commit();
                ok = true;
            }
            catch
            {
                transaction.Rollback();
                ok = false;
                //Console.WriteLine("SQL Error: " + ex.Message);
                //Console.WriteLine(ann_id);
            }

            connection.Close();

            if (ok) Response.Redirect("Announce");
        }
    }
}
