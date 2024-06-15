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
        public void OnGet()
        {
            var connection = new SqliteConnection(@"data source=Database\MyDB.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM [Picture]";
            var reader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
        }

        public void OnPostAdd()
        {
            Response.Redirect("Album2Add");
        }
    }
}
