using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Handlebars
{
    [HtmlTargetElement("handelbars")]
    public class HandlebarsTagHelper : TagHelper
    {
        public IHandlebarsRendering _handelbarsRendering { get; set; }

        public HandlebarsTagHelper(IHandlebarsRendering pugRendering)
        {
            _handelbarsRendering = pugRendering;
        }

        [HtmlAttributeName("model")]
        public object Model { get; set; }

        [HtmlAttributeName("view")]
        public string View { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var result = await _handelbarsRendering.Render(new FileInfo(View), Model, null, null);
            output.TagName = null;
            output.Content.AppendHtml(result);
        }

    }
}
