using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class ProgLib
    {
        public List<AppliedProg> list = new List<AppliedProg>();
        public delegate int del(AppliedProg prog1, AppliedProg prog2);

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

        public void SortBy(del delegat)
        {
            AppliedProg tprog;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (delegat(list[i], list[j]) == 1)
                    {
                        tprog = list[i];
                        list[i] = list[j];
                        list[j] = tprog;
                    }
                }
            }
        }
    }

    public abstract class CompProg
    {
        public string name;
        public int code_size;
        public string lang;

        public abstract void Edit();
    }

    public class AppliedProg : CompProg, IComparable, IComparer<AppliedProg>, ICloneable
    {
        public string point;
        public string user_category;

        public AppliedProg(string name, int code, string lang, string point, string category)
        {
            this.name = name;
            this.code_size = code;
            this.lang = lang;
            this.point = point;
            this.user_category = category;
        }

        public override void Edit()
        {
            Console.WriteLine("Выберите изменяемое поле:\n1) Название\n2) Объем кода\n3) Язык программирования\n4) Назначение\n5) Категория пользователей");
            int choice = -1;
            try { choice = int.Parse(Console.ReadKey().KeyChar.ToString()); }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public object Clone()
        {
            return (AppliedProg)this.MemberwiseClone();
        }

        public object GClone()
        {
            return new AppliedProg(name, code_size, lang, point, user_category);
        }

        public int CompareTo(object b)
        {
            AppliedProg a = b as AppliedProg;
            if (a != null)
            {
                return this.code_size.CompareTo(a.code_size);
            }
            else throw new NullReferenceException("Невозможно сравнить эти 2 объекта!");
        }

        public int Compare(AppliedProg obj1, AppliedProg obj2)
        {
            if (obj1.code_size > obj2.code_size) return 1;
            else if (obj1.code_size < obj2.code_size) return -1;
            else return 0;
        }

        static public int Compare_Name(AppliedProg obj1, AppliedProg obj2)
        {
            return obj1.name.CompareTo(obj2.name);
        }

        static public int Compare_Code(AppliedProg obj1, AppliedProg obj2)
        {
            return obj1.code_size.CompareTo(obj2.code_size);
        }

        static public int Compare_Lang(AppliedProg obj1, AppliedProg obj2)
        {
            return obj1.lang.CompareTo(obj2.lang);
        }

        static public int Compare_Point(AppliedProg obj1, AppliedProg obj2)
        {
            return obj1.point.CompareTo(obj2.point);
        }

        static public int Compare_Category(AppliedProg obj1, AppliedProg obj2)
        {
            return obj1.user_category.CompareTo(obj2.user_category);
        }
    }
    class Program
    {
        public delegate string LongestName(List<AppliedProg> list);
        static string Longest(List<AppliedProg> list)
        {
            string t = list[0].name;
            foreach (AppliedProg i in list)
            {
                if (i.name.Length > t.Length) t = i.name;
            }
            return t;
        }
        static void Main(string[] args)
        {
            try
            {
                ProgLib list = new ProgLib();
                list.Add(new AppliedProg("Name", 0, "lang", "point", "user"));
                list.Add(new AppliedProg("Ubername", 4, "prolang", "antipoint", "superuser"));
                list.Add(new AppliedProg("Cybername", 189, "underlang", "per-point", "megauser"));
                list.Add((AppliedProg)list.list[1].Clone());
                list.Add((AppliedProg)list.list[2].GClone());

                Console.WriteLine("Исходный список:");
                list.Output();
                Console.WriteLine();
                Console.WriteLine("Сортировка по name:");
                list.SortBy(AppliedProg.Compare_Name);
                list.Output();
                Console.WriteLine();
                Console.WriteLine("Сортировка по code_size:");
                list.SortBy(AppliedProg.Compare_Code);
                list.Output();
                Console.WriteLine();
                Console.WriteLine("Сортировка по lang:");
                list.SortBy(AppliedProg.Compare_Lang);
                list.Output();
                Console.WriteLine();
                Console.WriteLine("Сортировка по point:");
                list.SortBy(AppliedProg.Compare_Point);
                list.Output();
                Console.WriteLine();
                Console.WriteLine("Сортировка по user_category:");
                list.SortBy(AppliedProg.Compare_Category);
                list.Output();
                Console.WriteLine();

                List<AppliedProg> list2 = new List<AppliedProg>();
                for (int i = 0; i < list.list.Count; i++) list2.Add(list.list[i]);
                LongestName l = (List<AppliedProg> p) => Longest(p);
                Console.WriteLine();
                Console.WriteLine("Наидлиннейший name: " + l(list2));
                Console.ReadKey();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
