using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_3
{
    class Program
    {
        // Creator, Controller, Low Coupling, InformationExpert
        static void Main(string[] args)
        {
            var x = new Lista_3.DependencyInversion.ReportComposerExample();
            x.Execute();

            Console.ReadKey();
        }
    }
}
