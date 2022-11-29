using Microsoft.AspNetCore.Mvc;

namespace WEB_053502_Selhanovich.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
