using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class GalleryEditModel : PageModel
    {
        [BindProperty]
        public string user_id { set; get; }
        [BindProperty]
        public string picture_title { get; set; }

        [BindProperty]
        public string picture_description { get; set; }

        [BindProperty]
        public string picture_time { get; set; }

        [BindProperty]
        public string picture_filename { get; set; }
        [BindProperty]
        public string picture_who { get; set; }

        [BindProperty]
        public string message { get; set; }
        public void OnGet(string id)
        {
            try
            {
                user_id = HttpContext.Session.GetString("userId");
                if (user_id != "admin") Response.Redirect("Login3");
                ShowUser(id);
            }
            catch
            {
                Response.Redirect("Login3");
            }
        }
        private void ShowUser(string id)
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM [Picture4] WHERE id = @id";
            command.Parameters.AddWithValue("id", id);
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                picture_title = reader[1].ToString();
                picture_description = reader[2].ToString();
                picture_time = reader[3].ToString();
                picture_filename = reader[4].ToString();
                picture_who = reader[5].ToString();
            }
            connection.Close();
        }

        public void OnPostUpdate()
        {
            bool ok = false;
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE Picture4 SET title = @title, description = @description WHERE id = @id";
                command.Parameters.AddWithValue("title", picture_title);
                command.Parameters.AddWithValue("description", picture_description);
                command.ExecuteNonQuery();

                transaction.Commit();
                ok = true;
            }
            catch
            {
                transaction.Rollback();
                ok = false;
            }

            connection.Close();

            if (ok) Response.Redirect("Gallery");
            else message = "Faild to update this user.";
        }
    }
}
