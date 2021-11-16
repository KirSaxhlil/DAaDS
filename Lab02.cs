using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, x, b, y, l;
            a = 0;
            x = 1000;
            b = 5;
            l = a + x;
            y = 2 * a + Math.Pow(x, 1.0 / 3.0);
            if (l > 0 && y != 0)
            {
                y = (a * x + b * Math.Log10(l)) / y;
                Console.WriteLine("Значение y: {0}", y);
            }
            else
            {
                Console.WriteLine("Вычисление невозможно!");
            }
            Console.ReadKey();
        }
    }
}

/*
 
 
a+x = 1000
 
a+x>0
 
2a+sqrt3(x)!=0
*/


/*
b/x^2>0
b/x^2!=0
 
x!=0
b>0
b!=x^2
*/
