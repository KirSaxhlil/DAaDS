using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void DivideStringRegOutput(String[] line, char symb)
        {
            Regex reg = new Regex(@"" + symb);
            FileInfo file = new FileInfo("lab6d.s2");
            StreamWriter output = file.CreateText();
            output.WriteLine(symb);
            for (int j = 0; j < line.Length; j++)
            {
                int i = reg.Match(line[j]).Index;
                if (i != 0)
                    output.WriteLine(line[j].Substring(0, i) + "\t" + line[j].Substring(i));
                else
                    output.WriteLine(line[j]);
            }
            output.Close();

        }
        static void Main(string[] args)
        {
            char a;
            int i, n;
            string filename = "lab6d.s1";
            FileInfo file = new FileInfo(filename);
            StreamReader input = null;
            try
            {
                input = file.OpenText();
                n = File.ReadAllLines(filename).Length - 1;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                Console.ReadKey();
                return;
            }
            a = input.ReadLine().First();
            string[] line = new string[n];
            for(i = 0; i < n; i++)
            {
                line[i] = input.ReadLine();
            }
            input.Close();
            DivideStringRegOutput(line, a);
            Console.WriteLine("Successful.");
            Console.ReadKey();
        }
    }
}
