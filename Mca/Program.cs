using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mca
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();

            string path = @"C:\Users\Daniel\Desktop\Navigation.csv";

            List<NavModel> navModels = service.ReadFile(path);

            service.OutPut(service.AllList(navModels));

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Written by Daniel Simonovski");

            Console.ReadLine();
        }
    }
}
