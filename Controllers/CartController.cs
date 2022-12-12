using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_053502_Selhanovich.Data;
using WEB_053502_Selhanovich.Extensions;
using WEB_053502_Selhanovich.Entities;
namespace WEB_053502_Selhanovich.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Cart _cart;
        public IActionResult Index()
        {
            return View(_cart);
        }

        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            var dish = _context.Dishes.Find(id);
            if (dish != null)
            {
                cart.AddToCart(dish);
                HttpContext.Session.Set<Cart>("cart", cart);

            }

            return Redirect(returnUrl);
        }

        [Authorize]
        public IActionResult Remove(int id, string returnUrl)
        {
            var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            cart.RemoveFromCart(id);
            HttpContext.Session.Set<Cart>("cart", cart);

            return Redirect(returnUrl);
        }
    }
}
