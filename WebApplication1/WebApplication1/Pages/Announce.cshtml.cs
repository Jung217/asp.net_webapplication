using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System.Data;

namespace WebApplication1.Pages
{
    public class AnnounceModel : PageModel
    {
		[BindProperty]
		public DataTable dataTable { get; set; }
		public string who { get; set; }
		public void OnGet()
		{
			//who = "Geust";
			//if (HttpContext.Session.GetString("userId") == "admin") who = "ad";

			var connection = new SqliteConnection(@"data source=Database\MyDB.db");
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = @"SELECT * FROM [Announce]";
			var reader = command.ExecuteReader();
			dataTable = new DataTable();
			dataTable.Load(reader);
			reader.Close();
			connection.Close();
		}
        public void OnPostAdd()
        {
            Response.Redirect("AnnounceAdd");
        }
    }
	
}
