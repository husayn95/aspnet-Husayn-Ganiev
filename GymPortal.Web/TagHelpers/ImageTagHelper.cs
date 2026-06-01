using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GymPortal.Web.TagHelpers
{
    [HtmlTargetElement("img", Attributes = ImageAttributeName)]
    public class ImageTagHelper : TagHelper
    {
        private const string ImageAttributeName = "asp-image";

        [HtmlAttributeName(ImageAttributeName)]
        public string Image { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(Image))
            {
                return;
            }

            var src = Image.StartsWith("/") ? Image : $"/images/{Image}";

            output.Attributes.SetAttribute("src", src);
        }
    }
}
