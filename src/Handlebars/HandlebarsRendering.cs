using System.IO;
using System.Threading.Tasks;
using HandlebarsDotNet;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace HandlebarsViewEngine
{
    public class HandlebarsRendering : IHandlebarsRendering
    {
       
        public IHandlebarsTempDirectoryProvider TempDirectoryProvider;
        public HandlebarsRendering(IHandlebarsTempDirectoryProvider tempDirectoryProvider)
        {      
            TempDirectoryProvider = tempDirectoryProvider;
           
        }

        public async Task<string> Render(FileInfo hbsFile, object model, ViewDataDictionary viewData, ModelStateDictionary modelState)
        {
            var templateString = await hbsFile.OpenText().ReadToEndAsync();

            var pageModel = new {
                model=model,
                viewData=viewData,
                modelState=modelState
            };

            var template = Handlebars.Compile(templateString);

            return template(pageModel); 
        }
    }
}
