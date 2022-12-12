using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_053502_Selhanovich.Entities;
using WEB_053502_Selhanovich.Extensions;
using WEB_053502_Selhanovich.Models;
using WEB_053502_Selhanovich.Services;
namespace WEB_053502_Selhanovich.Components
{
	public class CartViewComponent : ViewComponent
    {
        private readonly Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            //var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            return View(_cart);
        }
    }
}
