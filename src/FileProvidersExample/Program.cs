using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.FileProviders;
using Microsoft.Dnx.Runtime;
using System.Reflection;
using System.IO;

namespace FileProvidersExample
{
    public class Program
    {
        private readonly IApplicationEnvironment _appEnvironment;

        public Program(IApplicationEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public void Main(string[] args)
        {
            Console.WriteLine("Root path      : {0}", _appEnvironment.ApplicationBasePath);
            Console.WriteLine();

            var physicalFileProvider = new PhysicalFileProvider(_appEnvironment.ApplicationBasePath);
            physicalFileProvider.GetInfo(@"c:\github\kichalla\FileProvidersExample\src\FileProvidersExample\Program.cs");
            physicalFileProvider.GetInfo("Program.cs");
            physicalFileProvider.GetInfo("/Program.cs");
            physicalFileProvider.GetInfo(@"\Program.cs");
            physicalFileProvider.GetInfo("FileProvidersExample/Program.cs");
            physicalFileProvider.GetInfo("/FileProvidersExample/Program.cs");
            physicalFileProvider.GetInfo(@"\FileProvidersExample\Program.cs");

            Console.WriteLine("***********************************************************");

            var embeddedProvider = new EmbeddedFileProvider(this.GetType().GetTypeInfo().Assembly, "FileProvidersExample.EmbeddedResources");
            embeddedProvider.GetInfo("Blah.cshtml");
            embeddedProvider.GetInfo("/Views/Home/Index.cshtml");
            embeddedProvider.GetInfo("Views/Home/Index.cshtml");
            embeddedProvider.GetInfo(@"\Views\Home\Index.cshtml");
            embeddedProvider.GetInfo(@"Views\Home\Index.cshtml");
        }
    }

    public static class FileProviderExtensions
    {
        public static void GetInfo(this IFileProvider provider, string path)
        {
            Console.WriteLine("Path         : {0}", path);
            Console.WriteLine("Physical Path: {0}", provider.GetFileInfo(path)?.PhysicalPath);
            Console.WriteLine("Exists       : {0}", provider.GetFileInfo(path)?.Exists);
            Console.WriteLine("File.Exists  : {0}", File.Exists(provider.GetFileInfo(path).PhysicalPath));
            Console.WriteLine("Name         : {0}", provider.GetFileInfo(path)?.Name);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
