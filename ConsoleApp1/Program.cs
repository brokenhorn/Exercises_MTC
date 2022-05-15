using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FailProcess();
            }
            catch
            { }
            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
        }

        static void FailProcess()
        {
            Random rnd = new Random();
            int i = rnd.Next(1, 3);

            switch (i)
            {
                case 1:
                    var process = Process.GetCurrentProcess();
                    process.Kill();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                case 3:
                    System.Environment.FailFast(null);
                    break;
            }
        }


    }
}


