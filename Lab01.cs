using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte byte1 = 167;
            sbyte byte2 = -13;
            Console.WriteLine("byte1(I1): {0:D}d, {0:X}h", byte1);
            Console.WriteLine("byte2(I2): {0:D}d, {0:X}h\n", byte2);

            short word1 = byte1, word2 = byte2;
            Console.WriteLine("word1(I1): {0:D}d, {0:X}h", word1);
            Console.WriteLine("word2(I2): {0:D}d, {0:X}h\n", word2);

            word1 = 270;
            word2 = -610;
            Console.WriteLine("word1(I3): {0:D}d, {0:X}h", word1);
            Console.WriteLine("word2(I4): {0:D}d, {0:X}h\n", word2);

            int dword1 = word1, dword2 = word2;
            Console.WriteLine("dword1(I3): {0:D}d, {0:X}h", dword1);
            Console.WriteLine("dword2(I4): {0:D}d, {0:X}h\n", dword2);

            byte1 = (byte)word1;
            byte2 = (sbyte)dword1;
            Console.WriteLine("byte1(I3): {0:D}d, {0:X}h", byte1);
            Console.WriteLine("byte2(I3): {0:D}d, {0:X}h\n", byte2);

            char c = 'Х';
            Console.WriteLine("Символ С: {0}", c);
            Console.WriteLine("Код символа С: {0:D}d, {0:X}h", (short)c);
            Console.ReadKey();
        }
    }
}
