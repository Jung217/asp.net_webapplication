using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        public string message { set; get; }

        [BindProperty]
        public string user_id { set; get; }
        
        [BindProperty]
        public string user_password { set; get; }

        public void OnGet()
        {
        }

        public void OnPostLogin()
        {
            if(user_id == "john" && user_password == "12345")
            {
                //message = "success to login.";
                Response.Redirect("Index");
            }
            else
            {
                message = "faild to login.";
            }
        }
    }
}
