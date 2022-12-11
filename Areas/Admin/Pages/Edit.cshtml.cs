using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_053502_Selhanovich.Data;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WEB_053502_Selhanovich.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EditModel(IWebHostEnvironment environment, WEB_053502_Selhanovich.Data.ApplicationDbContext context)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Dish Dish { get; set; } = default!;
        public DishCategory DishCategory { get; set; }
        [BindProperty]
        public IFormFile FormFile { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish =  await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            Dish = dish;
            DishCategory = await _context.DishCategories.FirstOrDefaultAsync(c => dish.CategoryId == c.Id);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FormFile != null)
            {
                string extension = Path.GetExtension(FormFile.FileName).Replace(".", string.Empty); ;
                Dish.MimeType = extension;
                string filePath = Path.Combine(_environment.WebRootPath, "images", Dish.ImageName + '.' + Dish.MimeType);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await FormFile.CopyToAsync(fileStream);
                }
            }

            _context.Attach(Dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(Dish.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DishExists(int id)
        {
          return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
