using Microsoft.EntityFrameworkCore.Diagnostics;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Data
{
    public class DbInitializer
    {
        public static void InitializeData(WebApplication app) {
            var serviceProvider = app.Services.CreateScope().ServiceProvider;

            var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            applicationDbContext.DishCategories.AddRange(
                new DishCategory { Name = "Салат" },
                new DishCategory { Name = "Суп" }
                );
            applicationDbContext.Dishes.AddRange(
                new Dish
                {
                    Name = "Цезарь",
                    Description = "Пал под ножом",
                    CategoryId = 1,
                    Price = 10.56m,
                    ImageName = "Салат Цезарь",
                    MimeType = "jpg"
                },
                new Dish
                {
                    Name = "Греческий",
                    Description = "Хорош с вином",
                    CategoryId = 1,
                    Price = 8.0m,
                    ImageName = "Салат Греческий",
                    MimeType = "jpg"
                },
                new Dish
                {
                    Name = "Оливье",
                    Description = "Рецепт неизвестен",
                    CategoryId = 1,
                    Price = 9.6m,
                    ImageName = "Салат Оливье",
                    MimeType = "jpg"
                },
                new Dish
                {
                    Name = "Мимоза",
                    Description = "Рыбов есть?",
                    CategoryId = 1,
                    Price = 9.6m,
                    ImageName = "Салат Мимоза",
                    MimeType = "jpg"
                },
                new Dish
                {
                    Name = "Борщ",
                    Description = "А где вы берете красную воду?",
                    CategoryId = 2,
                    Price = 13.33m,
                    ImageName = "Суп Борщ",
                    MimeType = "jpg"
                },
                new Dish
                {
                    Name = "Луковый",
                    Description = "Только не плачь",
                    CategoryId = 2,
                    Price = 16.19m,
                    ImageName = "Суп Луковый",
                    MimeType = "jpg"
                });
            applicationDbContext.SaveChanges();
        }
    }
}
