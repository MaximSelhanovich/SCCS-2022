using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using WEB_053502_Selhanovich.Data;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }
        [BindProperty]
        public IFormFile FormFile { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
                Dish.ImageName = (_context.Dishes.Max(d => d.Id) + 1).ToString();
                string filePath = Path.Combine(_environment.WebRootPath, "images", Dish.ImageName + '.' + Dish.MimeType);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await FormFile.CopyToAsync(fileStream);
                }
            }
            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
