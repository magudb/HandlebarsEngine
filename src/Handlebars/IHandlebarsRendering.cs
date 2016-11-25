using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Handlebars
{
    public interface IHandlebarsRendering
    {
        Task<string> Render(FileInfo hbsFile, object model, ViewDataDictionary viewData, ModelStateDictionary modelState);
    }
}