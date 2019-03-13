using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NO._4
{
    class Product
    {
        static void Main(string[] args)
        {
            string a = "";
            double m = 0, n = 0, x;
            Console.WriteLine("please input a number:");
            a = Console.ReadLine();
            m = Double.Parse(a);
            Console.WriteLine("please input a number:");
            a = Console.ReadLine();
            n = Double.Parse(a);
            x = m *n;
            Console.WriteLine("the product is:" + x);
            Console.ReadKey(true);
        }
    }
}
