using Microsoft.AspNetCore.Mvc;
using WEB_053502_Selhanovich.Models;

namespace WEB_053502_Selhanovich.Components
{
	public class Cart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
