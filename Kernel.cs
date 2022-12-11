using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("hello world\n.");
        }

        protected override void Run()
        {
           
            var input = Console.ReadLine();
            
            
        }
    }
}
