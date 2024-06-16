using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace WebApplication1.Pages
{
    public class AnnouenceShowModel : PageModel
    {
        [BindProperty]
        public string ann_id { set; get; }
        [BindProperty]
        public string ann_title { get; set; }

        [BindProperty]
        public string ann_content { get; set; }

        [BindProperty]
        public string ann_time { get; set; }

        [BindProperty]
        public string ann_who { get; set; }
        [BindProperty]
        public string who { get; set; }
        [BindProperty]
        public string message { get; set; }
        public void OnGet(string id)
        {
            who = HttpContext.Session.GetString("userId");
            message = id;

            try
            {
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
        public void OnPostDelete(string id)
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Announce WHERE id = @id";
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

            connection.Close();

            Response.Redirect("Announce");
        }
        public void OnPostUpdate(string id)
        {
            Response.Redirect("AnnounceUpdate?id=" + id);
        }
    }
}
