using System;
using System.IO;
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
            for (int i = 0; i < n - 1; i++)
            {
                if (tmp != null)
                {
                    tmp = tmp.Next;
                }
                else return;
            }
            if (tmp != null)
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
        static void LoadFile(ref List list)
        {
            StreamReader input;
            try { input = new StreamReader("input.txt"); }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            list = new List();
            while (!input.EndOfStream)
            {
                PData data = new PData();
                string[] line = new string[5];
                line = input.ReadLine().Split(' ');
                data.number = int.Parse(line[0]);
                data.name = line[1];
                data.profession = line[2];
                data.rank = int.Parse(line[3]);
                data.experience = int.Parse(line[4]);
                list.Insert(data);
            }
        }

        static void Main(string[] args)
        {
            List list = null;
            int choice = 0;
            bool work = true;
            string[] actions = { "Создать список", "Загрузить список из файла", "Добавить запись в список", "Удалить запись из списка", "Изменить запись в списке", "Вывести список", "Выйти в Windows" };
            do
            {
                Console.Clear();
                Console.WriteLine("Введите одно из следующих действий: ");
                for (int i = 0; i < (list == null ? 3 : actions.Length); i++)
                {
                    Console.WriteLine((i + 1) + " - " + actions[(list == null && (i == 2) ? actions.Length - 1 : i)] + ".");
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
                    case 1: list = new List(); break;
                    case 2: LoadFile(ref list); break;
                    case 3 when list == null: Quit(ref work); break;
                    case 3 when list != null: {
                            try { list.Insert(List.InputData()); }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }
                            break; 
                        }
                    case 4 when list != null: list.Remove(); break;
                    case 5 when list != null:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите номер элемента: ");
                            try { list.Edit(Convert.ToInt32(Console.ReadLine())); }
                            catch(FormatException ex) {
                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 6 when list != null: {
                            Console.Clear();
                            Console.WriteLine("Содержимое списка:");
                            list.Output();
                            Console.ReadKey();
                            break;
                        }
                    case 7 when list != null: {
                            Quit(ref work);
                            break;
                        }
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
