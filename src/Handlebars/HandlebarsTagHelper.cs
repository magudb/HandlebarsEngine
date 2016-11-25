using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HandlebarsViewEngine
{
    [HtmlTargetElement("handelbars")]
    public class HandlebarsTagHelper : TagHelper
    {
        public IHandlebarsRendering HandelbarsRendering { get; set; }

        public HandlebarsTagHelper(IHandlebarsRendering handlebarsRendering)
        {
            HandelbarsRendering = handlebarsRendering;
        }

        [HtmlAttributeName("model")]
        public object Model { get; set; }

        [HtmlAttributeName("view")]
        public string View { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var result = await HandelbarsRendering.Render(new FileInfo(View), Model, null, null);
            output.TagName = null;
            output.Content.AppendHtml(result);
        }

    }
}
