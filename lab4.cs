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
            int q_pos = 0, x = -1, y = 30, t = 0;
            int[] array = new int[30];
            Random rand = new Random();
            for(int i = 0; i < 30; i++)
            {
                array[i] = -50 + rand.Next(101);
            }
            foreach(int i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            foreach (int i in array)
            {
                if (i > 0) q_pos++;
            }
            for(int i = 0; i < q_pos/2; i++)
            {
                for(int j = x+1; j < 30; j++)
                {
                    if (array[j] > 0) x = j;
                }
                for(int j = y-1; j > 0; j--)
                {
                    if (array[j] > 0) y = j;
                }
                t = array[x];
                array[x] = array[y];
                array[y] = t;
            }
            foreach(int i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();
        }
    }
}
