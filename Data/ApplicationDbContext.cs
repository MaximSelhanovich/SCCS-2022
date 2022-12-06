using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> AplicationUsers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                  : base(options)
        {
        }
    }

}
