using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebApplication1.Pages
{
    
    public class popModel : PageModel
    {
        [BindProperty]
        public string message { set; get; }
        [BindProperty]
        public int score { set; get; }
        public void OnGet()
        {    
            Random rand = new Random();
		    int randomIntMax = rand.Next(789);
			score = randomIntMax;
		}
		public void OnPost()
		{
            
        }
	}
}
