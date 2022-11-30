using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB_053502_Selhanovich.Entities;

namespace WEB_053502_Selhanovich.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager)
        {
            _environment = environment;
            _userManager = userManager;
        }

        public async Task<FileResult> GetImage()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.Image != null)
                return File(user.Image, "image/...");
            else
            {
                var avatarPath = "/images/avatar.jpg";
                return File(_environment.WebRootFileProvider
                    .GetFileInfo(avatarPath)
                    .CreateReadStream(), "image/...");
            }
        }
    }
}
