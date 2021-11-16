using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    struct PData
    {
        public int number;
        public string name;
        public string profession;
        public int rank;
        public int experience;
    }

    class ListNode
    {
        PData data;
        ListNode next;

        public ListNode(PData newData) : this(newData, null) { }

        public ListNode(PData newData, ListNode next)
        {
            data = newData;
            this.next = next;
        }

        public PData Data
        {
            get { return data; }
            set { data = value; }
        }

        public ListNode Next
        {
            get { return next; }
            set { next = value; }
        }
    }

    class List
    {
        ListNode firstNode;
        ListNode lastNode;
        string name;

        public List(string name)
        {
            this.name = name;
            firstNode = lastNode = null;
        }
        public List() : this("List") { }

        public bool IsEmpty()
        {
            return lastNode == null;
        }

        public void Insert(PData item)
        {
            if (IsEmpty())
            {
                firstNode = lastNode = new ListNode(item);
            }
            else
            {
                ListNode tmp = new ListNode(item);
                lastNode.Next = tmp;
                lastNode = tmp;
            }
        }

        public PData Remove()
        {
            if (!IsEmpty())
            {
                PData tmp = firstNode.Data;
                firstNode = firstNode.Next;
                return tmp;
            }
            else return new PData();
        }

        public void Edit(int n)
        {
            ListNode tmp = firstNode;
            for (int i = 0; i <= n; i++)
            {
                if (tmp != null)
                {
                    tmp = tmp.Next;
                }
                else return;
            }
            tmp.Data = InputData();
        }

        public void Output()
        {
            ListNode tmp = firstNode;
            while (tmp != null)
            {
                Console.WriteLine(tmp.Data.number + "\t" + tmp.Data.name + "\t" + tmp.Data.profession + "\t" + tmp.Data.rank + "\t" + tmp.Data.experience);
                tmp = tmp.Next;
            }
        }

        public static PData InputData()
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            List list = null;
            int choice = 0;
            bool work = true;
            string[] actions = { "Создать список", "Добавить запись в список", "Удалить запись из списка", "Изменить запись в списке", "Выйти в Windows" };
            do
            {
                Console.WriteLine("Введите одно из следующих действий: ");
                for (int i = 0; i < (list == null ? 2 : 5); i++)
                {
                    Console.WriteLine((i + 1) + " - " + actions[(list == null && i == 1 ? 4 : i)] + ".");
                }
                Console.WriteLine(work);
                choice = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine(choice);
                switch (choice)
                {
                    case 1: list = new List(); break;
                    case 2 when list == null: work = false; break;
                    case 2 when list != null: list.Insert(List.InputData()); break;

                    case 3 when list != null: list.Remove(); break;
                    case 4 when list != null:
                        {
                            Console.WriteLine("Введите номер элемента: ");
                            list.Edit(Convert.ToInt32(Console.ReadLine()));
                            break;
                        }
                    case 5 when list != null: work = false; break;
                }
            } while (work);
        }
    }
}
