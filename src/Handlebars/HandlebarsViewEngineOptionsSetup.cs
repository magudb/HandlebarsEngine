using Microsoft.Extensions.Options;

namespace HandlebarsViewEngine
{
    public class HandlebarsViewEngineOptionsSetup : ConfigureOptions<HandlebarsViewEngineOptions>
    {
        public HandlebarsViewEngineOptionsSetup()
            : base(options => Configure(options))
        {
        }

        private static new void Configure(HandlebarsViewEngineOptions options)
        {            
            options.ViewLocationFormats.Add("Views/{1}/{0}" + global::HandlebarsViewEngine.HandlebarsViewEngine.ViewExtension);
            options.ViewLocationFormats.Add("Views/Shared/{0}" + global::HandlebarsViewEngine.HandlebarsViewEngine.ViewExtension);
        }
    }    
}
