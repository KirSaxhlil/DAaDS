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
            if (line.IndexOf(symb) != -1)
                return line.IndexOf(symb);
            else return 0;
        }

        static int DivideStringReg(String line, char symb)
        {
            Regex reg = new Regex(@"" + symb);
            return reg.Match(line).Index;
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
