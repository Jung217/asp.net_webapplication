using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class GalleryShowModel : PageModel
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
		public string picture_data { get; set; }
		public void OnGet(string id)
        {

            try
            {
				Showpic(id);
			}
            catch
            {
                Response.Redirect("Gallery");
            }
        }
        private void Showpic(string id)
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
                picture_data = reader[6].ToString();
            }
            connection.Close();
        }
        public void OnPostBack()
        {
            Response.Redirect("Gallery");
        }
    }
}
