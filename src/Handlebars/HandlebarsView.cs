using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace HandlebarsViewEngine
{
    public class HandlebarsView : IView
    {
        private string _path;
        private readonly IHandlebarsRendering _handelbarsRendering;

        public HandlebarsView(string path, IHandlebarsRendering pugRendering)
        {
            _path = path;
            _handelbarsRendering = pugRendering;
        }

        public string Path
        {
            get
            {
                return _path;
            }
        }

        public async Task RenderAsync(ViewContext context)
        {
            var result = await _handelbarsRendering.Render(new FileInfo(Path), context.ViewData.Model, context.ViewData, context.ModelState);
            context.Writer.Write(result);
        }
    }
}
