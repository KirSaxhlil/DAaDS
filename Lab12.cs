using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class ProgLib
    {
        List<AppliedProg> list = new List<AppliedProg>();

        public void Add(AppliedProg prog)
        {
            list.Add(prog);
        }
        public void Edit(int n)
        {
            list[n].Edit();
        }
        public void Delete(int n)
        {
            list.RemoveAt(n);
        }
        public void Output()
        {
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", list[i].name, list[i].code_size, list[i].lang, list[i].point, list[i].user_category);
            }
        }
    }

    abstract class CompProg
    {
        public string name;
        public int code_size;
        public string lang;

        public abstract void Edit();
    }

    class AppliedProg : CompProg
    {
        public string point;
        public string user_category;

        public override void Edit()
        {
            Console.WriteLine("Выберите изменяемое поле:\n1) Название\n2) Объем кода\n3) Язык программирования\n4) Назначение\n5) Категория пользователей");
            int choice = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            switch(choice)
            {
                case 1: name = Console.ReadLine(); break;
                case 2: code_size = int.Parse(Console.ReadLine()); break;
                case 3: lang = Console.ReadLine(); break;
                case 4: point = Console.ReadLine(); break;
                case 5: user_category = Console.ReadLine(); break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProgLib list = new ProgLib();
            int choice = 0;
            bool work = true;
            string[] actions = { "Добавить объект в коллекцию", "Внести изменение в объект", "Удалить объект из коллекции", "Вывести сведения об объектах коллекции", "Выйти в Windows" };
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите одно из следующих действий: ");
                for (int i = 0; i < actions.Length; i++)
                {
                    Console.WriteLine((i + 1) + " - " + actions[i] + ".");
                }
                try { choice = int.Parse(Console.ReadKey(true).KeyChar.ToString()); }
                catch (FormatException ex)
                {
                    choice = 0;
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
                switch (choice)
                {
                    case 1: {
                            AppliedProg prog = new AppliedProg();
                            try
                            {
                                prog.name = Console.ReadLine();
                                prog.code_size = int.Parse(Console.ReadLine());
                                prog.lang = Console.ReadLine();
                                prog.point = Console.ReadLine();
                                prog.user_category = Console.ReadLine();
                                list.Add(prog);
                            }
                            catch(FormatException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    case 2:
                        {
                            try { list.Edit(int.Parse(Console.ReadLine())); }
                            catch (FormatException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    case 3:
                        {
                            try { list.Delete(int.Parse(Console.ReadLine())); }
                            catch (FormatException ex) { Console.WriteLine(ex.Message); }
                            break;
                        }
                    case 4: list.Output(); break;
                    case 5: Quit(ref work); break;
                }
            } while (work);
        }

        static void Quit(ref bool work)
        {
            Console.Clear();
            Console.WriteLine("Вы действительно хотите выйти? (y/n)");
            char c = Console.ReadKey().KeyChar;
            if (c == 'y' || c == 'н')
                work = false;
        }
    }
}
