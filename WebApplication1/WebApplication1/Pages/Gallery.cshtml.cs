using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System.Data;

namespace WebApplication1.Pages
{
    public class GalleryModel : PageModel
    {
        [BindProperty]
        public DataTable dataTable { get; set; }
        public string who { get; set; }
        public void OnGet()
        {
            who = "Geust";
			if (HttpContext.Session.GetString("userId") == "admin") who = "ad";
			var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM [Picture4]";
            var reader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();

        }
        public void OnPostShow(string id)
        {
            string href = "GalleryShow?id=" + id;
            Response.Redirect(href);
        }
        public void OnPostTo()
        {
            Response.Redirect("Album2");
        }
        public void OnPostNo()
        {
            Response.Redirect("Gallery");
        }
        public void OnPostAdd()
        {
            Response.Redirect("Album2Add");
        }
        public void OnPostDelete(string id)
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var transaction = connection.BeginTransaction();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Picture4 WHERE id = @id";
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

            connection.Close();

            Response.Redirect("Gallery");
        }
        public void OnPostUpdate(string id)
        {
            Response.Redirect("GalleryEdit?id=" + id);
        }
        public void OnPostDownload(string id)
        {
            Response.Redirect("GalleryDownload?id=" + id);
        }
    }
}
