using Microsoft.AspNetCore.Mvc;
using WEB_053502_Selhanovich.Data;
using WEB_053502_Selhanovich.Entities;
using WEB_053502_Selhanovich.Extensions;
using WEB_053502_Selhanovich.Models;

namespace WEB_053502_Selhanovich.Controllers
{
    [Route("Catalog")]
    public class DishController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IQueryable<Dish> Dishes { get; set; } 

        private List<DishCategory> DishCategories { get; set; }
        private readonly int _pageSize = 3;

        [Route("Page")]
        [Route("Page_{pageNumber:int}")]
        public IActionResult Index(int pageNumber = 1, int? category = 0)
        {
            ViewData["DishCategories"] = DishCategories;
            ViewData["CurrentCategory"] = category ?? 0;

            if (category == 0) category = null;
            var items = ListViewModel<Dish>.GetModel(Dishes, pageNumber, _pageSize, 
                                                    dish => !category.HasValue || dish.CategoryId == category.Value);
            
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", items);
            else
                return View(items);
        }
      
        public DishController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            Dishes = _applicationDbContext.Dishes;
            DishCategories = _applicationDbContext.DishCategories.ToList();
        }
    }
}
