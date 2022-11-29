using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WEB_053502_Selhanovich.Data
{
    public class DbInitializer
    {
        public static void InitializeData(WebApplication app) {
            var serviceProvider = app.Services.CreateScope().ServiceProvider;

        }
    }
}
