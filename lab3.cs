using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, dx, y, y_min = 0, y_max = 0;
            int n, n_min, n_max;
            const int a = 2, b = 4;
 
            x = 2;
            dx = 0.2;
 
            n = 1; n_min = 1; n_max = 1;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|  n |   x  |      y     |    y_min   | n_min |   y_max    | n_max |");
            Console.WriteLine("--------------------------------------------------------------------");
            do
            {
                if (x <= 0)
                {
                    Console.WriteLine("| {0} | Вычисление невозможно.", n);
                    continue;
                }
                y = b * x * x - a * Math.Log10(x);
                if (n == 1)
                {
                    y_min = y;
                    y_max = y;
                }
                else
                {
                    if (y >= y_max)
                    {
                        y_max = y;
                        n_max = n;
                    }
                    if (y <= y_min)
                    {
                        y = y_min;
                        n_min = n;
                    }
                }
                Console.WriteLine("| {0,2} | {1,4:f2} | {2,10:f4} | {3,10:f4} | {4,5} | {5,10:f4} | {6,5} |", n, x, y, y_min, n_min, y_max, n_max);
                n++;
                x += dx;
            } while (x <= 7.0000000001); //14
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ReadKey();
        }
    }
}
