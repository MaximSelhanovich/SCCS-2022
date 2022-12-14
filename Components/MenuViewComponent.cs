using Microsoft.AspNetCore.Mvc;
using WEB_053502_Selhanovich.Models;

namespace WEB_053502_Selhanovich.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab"},
            new MenuItem{ Controller="Dish", Action="Index", Text="Catalog"},

        };

        private List<MenuItem> _adminMenuItems = new()
        {
            new MenuItem{ Controller="Home", Action="Index", Text="Lab07"},
            new MenuItem{ Controller="Dish", Action="Index", Text="Catalog"},
            new MenuItem{ IsPage = true, Area = "Admin", Page = "/Index", Text = "Change"}
        };

        public IViewComponentResult Invoke() {

            var checkList = User.IsInRole("admin") ? _adminMenuItems : _menuItems;

            foreach (var item in checkList) {
                var controller = ViewContext.RouteData.Values["controller"]?.ToString();
                var area = ViewContext.RouteData.Values["area"]?.ToString();

                if ((controller != null && controller == item.Controller) ||
                     (area != null && area == item.Area))
                {
                    item.Active = "active";
                }
            }

            if (User != null && User.IsInRole("admin")) return View(_adminMenuItems);
            return View(_menuItems);
        }
    }
}
