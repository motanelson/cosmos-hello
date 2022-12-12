using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        int icentrs(int i)
        {
            return i / 2;
        }
        string dstring(string s,int sizes)
        {
            string ss = "";
            int n = 0;
            for (n = 0; n < sizes; n++)
            {
                ss = ss + s;
            }
            return ss;
        }
        string spaces(int sizes)
        {
            return dstring(" ", sizes);
        }
        void center(string s,int cols)
        {
            Console.WriteLine(spaces((cols - s.Length) / 2)+s); 
        }
        protected override void BeforeRun()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            string s = "**";
            int n = 0;
            for (n = 0; n < 16;n++)
            {
                center(s, 80);
                s = s + "**";
            }
            
        }

        protected override void Run()
        {
           
            var input = Console.ReadLine();
            
            
        }
    }
}
