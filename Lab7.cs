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
        public int rank;
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
            data.rank = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите стаж работы: ");
            data.experience = Convert.ToInt32(Console.ReadLine());
            return data;
        }

        static void SaveData(PData s, StreamWriter fs)
        {
            fs.WriteLine(s.number + "\t" + s.name + "\t" + s.profession + "\t" + s.rank + "\t" + s.experience);
        }

        static void UnitTest(PData s, string source_file_name)
        {
            StreamWriter output = new StreamWriter("test.log");
            string dataS = s.number + "\t" + s.name + "\t" + s.profession + "\t" + s.rank + "\t" + s.experience;
            string dataF = File.ReadAllLines(source_file_name).Last();
            if (dataS == dataF) output.Write("Записи совпали. ");
            else output.Write("Записи не совпали. ");
            output.Write("Запись PData: {0}; Запись в файле: {1}\n", dataS, dataF);
            output.Close();
        }

        static void Main(string[] args)
        {
            PData data = new PData();
            string filename;
            filename = Console.ReadLine() + ".txt";
            StreamWriter output = null;
            try
            {
                output = new StreamWriter(filename);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Ошибка: недопустимое имя файла.");
                return;
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Ошибка: слишком длинное имя файла.");
                return;
            }
            do
            {
                data = InputData();
                try
                {
                    SaveData(data, output);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Ошибка: файл не существует.");
                    return;
                }
            } while (Console.ReadKey(true).KeyChar == '+');
            try
            {
                output.Close();
                Console.WriteLine("Файл сохранен в: " + Path.GetFullPath(filename));
                Console.WriteLine("Записей в файле: " + File.ReadAllLines(filename).Length);
                UnitTest(data, filename);
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Ошибка: файл не существует.");
            }
            Console.ReadKey();
        }
    }
}
