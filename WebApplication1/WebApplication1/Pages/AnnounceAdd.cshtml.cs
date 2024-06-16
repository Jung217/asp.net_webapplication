using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication1.Pages
{
    public class AnnounceAddModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "標題未輸入")]
        public string ann_title { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "內容未輸入")]
        public string ann_content { get; set; }

        [BindProperty]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ann_time { get; set; }

        [BindProperty]
        public string ann_who { get; set; }
        public void OnGet()
        {
            ann_time = DateTime.Now;
            ann_who = HttpContext.Session.GetString("userId");
            if (ann_who == null) ann_who = "Guest";
        }
        public void OnPostAdd()
        {
            bool ok = false;
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Announce (title, content, time, who) VALUES (@title, @content, @time, @who)";
                command.Parameters.AddWithValue("title", ann_title);
                command.Parameters.AddWithValue("content", ann_content);
                command.Parameters.AddWithValue("time", ann_time);
                command.Parameters.AddWithValue("who", ann_who);
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

            if (ok) Response.Redirect("Announce");
            //else message = "Faild to add new user.";
        }
    }
}
