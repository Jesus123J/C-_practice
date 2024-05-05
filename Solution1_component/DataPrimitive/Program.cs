using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataPrimitive
{
    internal class Program
    {
        private static string name;
        private static int age;
        private static double salary;
        private static bool merried;
        static void Main(string[] args)
        {
            component();
        }

        private static void component(){
            while (true)
            {
               Thread.Sleep(1000);
               Console.WriteLine("Procesing component");
            }
        } 
    }
}
