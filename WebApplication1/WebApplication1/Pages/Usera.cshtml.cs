using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace WebApplication1.Pages
{
    public class UseraModel : PageModel
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
            if (HttpContext.Session.GetString("userId") == null) Response.Redirect("Login3");
            else
            {
                string user_name = HttpContext.Session.GetString("userName");
                WelcomeMessage = "Hello, " + user_name + ". Nice to meet you.";
            }
        }
		public void OnPostLogout()
		{
			HttpContext.Session.Remove("userId");
			Response.Redirect("Login3");
		}
	}
}
