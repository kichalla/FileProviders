using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.FileProviders;
using Microsoft.Framework.Runtime;

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
            var physicalFileProvider = new PhysicalFileProvider(_appEnvironment.ApplicationBasePath);
            physicalFileProvider.GetInfo(@"c:\github\kichalla\FileProvidersExample\src\FileProvidersExample\Program.cs");
            physicalFileProvider.GetInfo("Program.cs");
            physicalFileProvider.GetInfo("/Program.cs");
            physicalFileProvider.GetInfo(@"\Program.cs");
            physicalFileProvider.GetInfo("FileProvidersExample/Program.cs");
            physicalFileProvider.GetInfo("/FileProvidersExample/Program.cs");
            physicalFileProvider.GetInfo(@"\FileProvidersExample\Program.cs");
        }
    }

    public static class FileProviderExtensions
    {
        public static void GetInfo(this IFileProvider provider, string path)
        {
            Console.WriteLine("Path         : {0}", path);
            Console.WriteLine("Physical Path: {0}", provider.GetFileInfo(path)?.PhysicalPath);
            Console.WriteLine("Exists       : {0}", provider.GetFileInfo(path)?.Exists);
            Console.WriteLine("Name         : {0}", provider.GetFileInfo(path)?.Name);
            Console.WriteLine();
        }
    }
}
