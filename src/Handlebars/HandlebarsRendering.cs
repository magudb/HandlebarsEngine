using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.NodeServices;

namespace Handlebars
{
    public class HandlebarsRendering : IHandlebarsRendering
    {
        public INodeServices NodeServices { get; set; }
        public IHandlebarsTempDirectoryProvider TempDirectoryProvider;
        public HandlebarsRendering(INodeServices nodeServices, IHandlebarsTempDirectoryProvider tempDirectoryProvider)
        {
            NodeServices = nodeServices;
            TempDirectoryProvider = tempDirectoryProvider;
            //ExpandEmbeddedFiles();
        }

        private void ExpandEmbeddedFiles()
        {
            var asm = GetType().GetTypeInfo().Assembly;
            var embeddedResourceName = asm.GetName().Name + ".embeddedNodeResources.zip";
            var tempDirectory = TempDirectoryProvider.TempDirectory;
            ZipFile.ExtractToDirectory(embeddedResourceName, tempDirectory);
          
        }

        public async Task<string> Render(FileInfo hbsFile, object model, ViewDataDictionary viewData, ModelStateDictionary modelState)
        {
            var result = await NodeServices.InvokeAsync<string>("./hbsCompile", hbsFile.FullName, model, viewData, modelState);
            return result;
        }
    }
}
