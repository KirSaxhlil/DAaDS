using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
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
            for (int i = 0; i < list.Count; i++)
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

    class AppliedProg : CompProg, IComparable, IComparer<AppliedProg>
    {
        public string point;
        public string user_category;

        public override void Edit()
        {
            Console.WriteLine("Выберите изменяемое поле:\n1) Название\n2) Объем кода\n3) Язык программирования\n4) Назначение\n5) Категория пользователей");
            int choice = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            switch (choice)
            {
                case 1: name = Console.ReadLine(); break;
                case 2: code_size = int.Parse(Console.ReadLine()); break;
                case 3: lang = Console.ReadLine(); break;
                case 4: point = Console.ReadLine(); break;
                case 5: user_category = Console.ReadLine(); break;
            }
        }

        public int CompareTo(object b)
        {
            AppliedProg a = b as AppliedProg;
            if (a != null)
            {
                return this.code_size.CompareTo(a.code_size);
            }
            else throw new NullReferenceException();
        }

        public int Compare(AppliedProg obj1, AppliedProg obj2)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
