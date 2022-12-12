using Microsoft.AspNetCore.Mvc;
using WEB_053502_Selhanovich.Models;

namespace WEB_053502_Selhanovich.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab 2"},
            new MenuItem{ Controller="Dish", Action="Index", Text="Каталог"},
            new MenuItem{ IsPage=true, Area="Admin", Page="/Index", Text="Администрирование"}
        };
        public IViewComponentResult Invoke() {
            foreach (var item in _menuItems) {
                var controller = ViewContext.RouteData.Values["controller"]?.ToString();
                var area = ViewContext.RouteData.Values["area"]?.ToString();

                if ((controller != null && controller == item.Controller) ||
                     (area != null && area == item.Area))
                {
                    item.Active = "active";
                }
            }

            return View(_menuItems);
        }
    }
}
