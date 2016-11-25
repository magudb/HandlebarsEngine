using System.IO;

namespace Handlebars
{
    public interface IHandlebarsTempDirectoryProvider
    {
        string TempDirectory { get; }
    }

    public class HandlebarsTempDirectoryProvider : IHandlebarsTempDirectoryProvider
    {
        public string TempDirectory { get; private set; }
        public HandlebarsTempDirectoryProvider()
        {
            TempDirectory = GetTemporaryDirectory();
        }

        private string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
    }
}
