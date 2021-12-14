using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class ProgLib
    {
        public List<AppliedProg> list = new List<AppliedProg>();

        public void Add(AppliedProg prog)
        {
            list.Add(prog);
        }
        public void Edit(int n, int field, string value)
        {
            list[n].Edit(field, value);
        }
        public void Delete(int n)
        {
            list.RemoveAt(n);
        }
        public void Output()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", list[i].name, list[i].code_size, list[i].lang, list[i].point, list[i].user_category);
            }
        }
    }

    public abstract class CompProg
    {
        public string name;
        public int code_size;
        public string lang;

        public abstract void Edit(int field, string value);
    }

    public class AppliedProg : CompProg
    {
        public string point;
        public string user_category;

        public AppliedProg() { }
        public AppliedProg(string name, int code_size, string lang, string point, string user_category)
        {
            this.name = name;
            this.code_size = code_size;
            this.lang = lang;
            this.point = point;
            this.user_category = user_category;
        }

        public override void Edit(int field, string value)
        {
            switch (field)
            {
                case 1: name = value; break;
                case 2: code_size = int.Parse(value); break;
                case 3: lang = value; break;
                case 4: point = value; break;
                case 5: user_category = value; break;
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
                    case 1:
                        {
                            Console.Clear();
                            AppliedProg prog = new AppliedProg();
                            try
                            {
                                Console.Write("Название: ");
                                prog.name = Console.ReadLine();
                                Console.Write("Объем кода: ");
                                prog.code_size = int.Parse(Console.ReadLine());
                                Console.Write("Язык программирования: ");
                                prog.lang = Console.ReadLine();
                                Console.Write("Назначение: ");
                                prog.point = Console.ReadLine();
                                Console.Write("Категория пользователей: ");
                                prog.user_category = Console.ReadLine();
                                list.Add(prog);
                            }
                            catch (FormatException ex) { Console.WriteLine(ex.Message); Console.ReadKey(); }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            try
                            {
                                Console.WriteLine("Введите номер элемента: ");
                                int n = int.Parse(Console.ReadLine());
                                Console.WriteLine("Выберите изменяемое поле:\n1) Название\n2) Объем кода\n3) Язык программирования\n4) Назначение\n5) Категория пользователей");
                                int field = int.Parse(Console.ReadKey().KeyChar.ToString());
                                Console.WriteLine("Введите новое значение: ");
                                string value = Console.ReadLine();
                                list.Edit(n, field, value);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); Console.ReadKey(); }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите номер элемента: ");
                            try { list.Delete(int.Parse(Console.ReadLine())); }
                            catch (Exception ex) { Console.WriteLine(ex.Message); Console.ReadKey(); }
                            break;
                        }
                    case 4: Console.Clear(); list.Output(); Console.ReadKey(); break;
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
