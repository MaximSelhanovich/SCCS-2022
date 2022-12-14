using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Data
{
    public class DbInitializer
    {   
        public static async void InitializeData(WebApplication app) {
            var serviceProvider = app.Services.CreateScope().ServiceProvider;
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (!applicationDbContext.DishCategories.Any())
            {
                applicationDbContext.DishCategories.AddRange(
                    new DishCategory { Name = "Салат" },
                    new DishCategory { Name = "Суп" }
                    );
            }

            if (!applicationDbContext.Dishes.Any())
            {
                applicationDbContext.Dishes.AddRange(
                    new Dish
                    {
                        Name = "Цезарь",
                        Description = "Пал под ножом",
                        CategoryId = 1,
                        Price = 10.56m,
                        ImageName = "1",
                        MimeType = "jpg"
                    },
                    new Dish
                    {
                        Name = "Греческий",
                        Description = "Хорош с вином",
                        CategoryId = 1,
                        Price = 8.0m,
                        ImageName = "2",
                        MimeType = "jpg"
                    },
                    new Dish
                    {
                        Name = "Оливье",
                        Description = "Рецепт неизвестен",
                        CategoryId = 1,
                        Price = 9.6m,
                        ImageName = "3",
                        MimeType = "jpg"
                    },
                    new Dish
                    {
                        Name = "Мимоза",
                        Description = "Рыбов есть?",
                        CategoryId = 1,
                        Price = 9.6m,
                        ImageName = "4",
                        MimeType = "jpg"
                    },
                    new Dish
                    {
                        Name = "Борщ",
                        Description = "А где вы берете красную воду?",
                        CategoryId = 2,
                        Price = 13.33m,
                        ImageName = "5",
                        MimeType = "jpg"
                    },
                    new Dish
                    {
                        Name = "Луковый",
                        Description = "Только не плачь",
                        CategoryId = 2,
                        Price = 16.19m,
                        ImageName = "6",
                        MimeType = "jpg"
                    });
            }

            if (applicationDbContext.Users.Any())
                return;

            await roleManager.CreateAsync(new IdentityRole("admin"));
            await roleManager.CreateAsync(new IdentityRole("user"));

            string password = "password";
            ApplicationUser admin = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            ApplicationUser user = new ApplicationUser
            {
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }

            result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "user");
            }

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
