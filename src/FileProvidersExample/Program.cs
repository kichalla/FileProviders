using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        }
    }
}
