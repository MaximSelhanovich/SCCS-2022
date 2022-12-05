using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace WEB_053502_Selhanovich.TagHelpers
{
    [HtmlTargetElement(tag: "img", Attributes = "img-action, img-controller")]
    public class ImgTagHelper : TagHelper
    {
        LinkGenerator _linkGenerator;
        public string ImgAction { get; set; }
        public string ImgController { get; set; }

        public ImgTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("img-action");
            output.Attributes.RemoveAll("img-controller");
            var url = _linkGenerator.GetPathByAction(ImgAction, ImgController);
            output.Attributes.Add("src", url);
        }
    }
}
