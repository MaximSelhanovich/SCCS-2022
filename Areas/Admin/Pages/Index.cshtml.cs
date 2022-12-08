using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_053502_Selhanovich.Data;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WEB_053502_Selhanovich.Data.ApplicationDbContext _context;

        public IndexModel(WEB_053502_Selhanovich.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; } = default!;
        public IList<DishCategory> DishCategory { get; set; } = default;

        public async Task OnGetAsync()
        {
            if (_context.Dishes != null)
            {
                Dish = await _context.Dishes.ToListAsync();
            }

            if (_context.DishCategories != null)
            {
                DishCategory = await _context.DishCategories.ToListAsync();
            }

        }
    }
}
