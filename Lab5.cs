using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static int DivideString(String line, char symb)
        {
            int i;
                i = line.IndexOf(symb);
            try
            {
                Console.WriteLine(line.Substring(0, i) + " " + line.Substring(i));
            }
            catch (ArgumentOutOfRangeException)
            {
                i = 0;
                Console.WriteLine(line);
            }
            return i;
        }

        static int DivideStringReg(String line, char symb)
        {
            int i;
            Regex reg = new Regex(@"" + symb);
            i = reg.Match(line).Index;
            Console.WriteLine(line.Substring(0, i) + " " + line.Substring(i));
            return i;
        }

        static void Main(string[] args)
        {
            string line;
            char a;
            int x, y;
            Console.Write("Введите строку: ");
            line = Console.ReadLine();
            Console.Write("Введите символ: ");
            a = Console.ReadKey().KeyChar;
            Console.Write("\n");
            x = DivideString(line, a);
            y = DivideStringReg(line, a);
            Console.WriteLine("By String: " + x);
            Console.WriteLine("By Regex: " + y);
            Console.ReadKey();
        }
    }
}
