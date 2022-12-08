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
    public class DetailsModel : PageModel
    {
        private readonly WEB_053502_Selhanovich.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_053502_Selhanovich.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            else 
            {
                Dish = dish;
            }
            return Page();
        }
    }
}
