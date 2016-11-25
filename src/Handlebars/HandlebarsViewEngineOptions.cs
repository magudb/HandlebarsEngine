using System.Collections.Generic;

namespace HandlebarsViewEngine
{
    public class HandlebarsViewEngineOptions
    {
        public IList<string> ViewLocationFormats { get; } = new List<string>();
    }
}
