using System;
using System.Collections.Generic;
namespace laba4
{
    class MyList<T> : List<T>
    {
        Owner Ivan = new Owner(4409, "Ivan", "MyCorp");
        Date date = new Date(16, 10, 2020);

        public static MyList<T> operator +(MyList<T> a, T b)
        {
            a.Add(b);

            return a;
        }
        public static MyList<T> operator -(MyList<T> a, T b)
        {
            a.Remove(b);

            return a;
        }
        public static bool operator !=(MyList<T> list1, MyList<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                return true;
            }

            for (var i = 0; i < list1.Count; i++)
            {
                if (!object.Equals(list1[i], list2[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator ==(MyList<T> list1, MyList<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (var i = 0; i < list1.Count; i++)
            {
                if (!object.Equals(list1[i], list2[i]))
                {
                    return false;
                }
            }

            return true;
        }


        public override string ToString()
        {
            var str = string.Empty;
            foreach (var item in this)
            {
                str = str + item + " ";
            }
            Console.WriteLine("---------------------------------------");

            return str;
        }
        class Date
        {
            private int day;

            private int month;

            private int year;
            public Date(int a, int b, int c)
            {
                day = a;
                month = b;
                year = c;
            }
        }
    }
    class Owner
    {
        private int id;
        private string name;
        private string name_corossion;
        public Owner(int a, string b, string c)
        {
            id = a;
            name = b;
            name_corossion = c;
        }
    }




    public static class Extensions
    {
        public static int CalculateItems<T>(this List<T> list)
        {
            return list.Count;
        }
    }

    public static class NullElements
    {
        public static bool SearchNullElements<T>(this List<T> list)
        {
            bool a;
            a = list == null;
            return a;
        }
    }

    public static class Sum
    {
        public static string SearchSum<T>(this List<T> list)
        {

            string s3 = list[0] + " " + list[1];

            return s3;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var list = new MyList<string>();
            var list1 = new MyList<string>();


            Console.WriteLine($"Введите первый элемент");
            string el1 = Console.ReadLine();
            Console.WriteLine($"Введите второй элемент");
            string el2 = Console.ReadLine();
            Console.WriteLine($"Введите третий элемент");
            string el3 = Console.ReadLine();
            Console.WriteLine($"Введите четвертый элемент");
            string el4 = Console.ReadLine();

            list = list + el1;
            list = list + el2;
            list = list + el3;
            list = list + el4;

            list = list1 + el1;
            list = list1 + el2;
            list = list1 + el3;
            list = list1 + el4;


            Console.WriteLine(list);
            Console.WriteLine("---------------------------------------");

            list = list - el4;

            bool result = list != list1;

            Console.WriteLine(list);
            Console.WriteLine("---------------------------------------");

            var itmesCount = list.CalculateItems();
            var nooelem = list.SearchNullElements();
            var sum = list.SearchSum();

            Console.WriteLine($"Подсчет количества слов:{itmesCount}");

            Console.WriteLine($"Проверка списка на нулевые элементы:{nooelem};");
            Console.WriteLine($"Проверка на неравенство:{result};");
            Console.WriteLine($"Сложение строк:{sum};");



        }
    }

}