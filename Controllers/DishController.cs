using Microsoft.AspNetCore.Mvc;
using WEB_053502_Selhanovich.Entities;
using WEB_053502_Selhanovich.Extensions;
using WEB_053502_Selhanovich.Models;

namespace WEB_053502_Selhanovich.Controllers
{
    public class DishController : Controller
    {
        private List<Dish> Dishes { get; set; } 

        private List<DishCategory> Categories { get; set; }
        private int _pageSize = 3;

        public IActionResult Index(int pageNumber = 1, int? category = 0)
        {
            ViewData["Categories"] = Categories;
            ViewData["CurrentCategory"] = category ?? 0;

            if (category == 0) category = null;
            var items = ListViewModel<Dish>.GetModel(Dishes.AsQueryable(), pageNumber, _pageSize, 
                                                    dish => !category.HasValue || dish.CategoryId == category.Value);
            
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", items);
            else
                return View(items);
        }

        public DishController()
        {
            FillLists();
        }

        public void FillLists()
        { 
            Categories = new List<DishCategory> 
            {   
                new DishCategory { Id = 1, Name = "Салат" },
                new DishCategory { Id = 2, Name = "Суп" }
            };
            Dishes = new List<Dish>
            {
                new Dish { Id = 1, Name = "Цезарь", Description = "Пал под ножом",
                    CategoryId = 1, Price = 10.56m,
                    ImageName = "Салат Цезарь", MimeType = "jpg" },
                new Dish { Id = 2, Name = "Греческий", Description = "Хорош с вином",
                    CategoryId = 1, Price = 8.0m,
                    ImageName = "Салат Греческий", MimeType = "jpg" },
                new Dish { Id = 3, Name = "Оливье", Description = "Рецепт неизвестен",
                    CategoryId = 1, Price = 9.6m,
                    ImageName = "Салат Оливье", MimeType = "jpg" },
                new Dish { Id = 3, Name = "Оливье", Description = "Рецепт неизвестен",
                    CategoryId = 1, Price = 9.6m,
                    ImageName = "Салат Оливье", MimeType = "jpg" },
                new Dish { Id = 4, Name = "Борщ", Description = "А где вы берете красную воду?",
                    CategoryId = 2, Price = 13.33m,
                    ImageName = "Суп Борщ", MimeType = "jpg" },
                new Dish { Id = 5, Name = "Луковый", Description = "Только не плачь",
                    CategoryId = 2, Price = 16.19m,
                    ImageName = "Суп Луковый", MimeType = "jpg" },

            };
        }
    }
}
