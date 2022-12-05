using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WEB_053502_Selhanovich.TagHelpers
{
    public class ImgTagHelper : TagHelper
    {
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}
