using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_053502_Selhanovich.Data;
using WEB_053502_Selhanovich.Entities;
using System;

namespace WEB_053502_Selhanovich.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WEB_053502_Selhanovich.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DeleteModel(IWebHostEnvironment environment, WEB_053502_Selhanovich.Data.ApplicationDbContext context)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
      public Dish Dish { get; set; }
        public DishCategory DishCategory { get; set; }
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
                DishCategory = await _context.DishCategories.FirstOrDefaultAsync(c => dish.CategoryId == c.Id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }
            var dish = await _context.Dishes.FindAsync(id);

            if (dish != null)
            {
                Dish = dish;
                _context.Dishes.Remove(Dish);
                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, "images", Dish.ImageName + '.' + Dish.MimeType));
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
