using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    struct PData
    {
        public int number;
        public string name;
        public string profession;
        public string rank;
        public int experience;
    }

    class Program
    {
        static PData InputData()
        {
            PData data = new PData();
            Console.Clear();
            Console.Write("Введите номер цеха: ");
            data.number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите фамилию и инициалы: ");
            data.name = Console.ReadLine();
            Console.Write("Введите название профессии: ");
            data.profession = Console.ReadLine();
            Console.Write("Введите разряд: ");
            data.rank = Console.ReadLine();
            Console.Write("Введите стаж работы: ");
            data.experience = Convert.ToInt32(Console.ReadLine());
            return data;
        }

        static void SaveData(PData s, StreamWriter fs)
        {
            fs.WriteLine(data.number + " ");
        }

        static void Main(string[] args)
        {
            PData data = new PData();
            string filename;
            filename = Console.ReadLine();
            File.Create(filename);
            StreamWriter input = new StreamWriter(filename);

        }
    }
}
