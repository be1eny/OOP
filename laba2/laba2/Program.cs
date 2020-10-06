using System;
using System.Linq;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {

            // ТИПЫ //

            //Определение переменных

            Console.WriteLine($"Введите переменную типа bool: ");
            string bufer = Console.ReadLine();
            bool q = Convert.ToBoolean(bufer);

            byte w = 1;
            sbyte e = 1;
            char r = 'r';
            decimal t = 12.3m;
            double y = 11.01;
            float u = 12.3f;
            int i = -1;
            uint o = 815;
            long p = -100;
            ulong a = 904;
            short s = -7;
            ushort d = 4;

            Console.WriteLine($"bool: {q} \n" +
                $"byte: {w} \n" +
                $"sbyte: {e} \n" +
                $"char: {r} \n" +
                $"decimal: {t} \n" +
                $"double: {y} \n" +
                $"float: {u} \n" +
                $"int: {i} \n" +
                $"uint: {o} \n" +
                $"long: {p} \n" +
                $"ulong: {a} \n" +
                $"short: {s} \n" +
                $"ushort: {d} \n");

            //Явные преобразования

            int f;
            float g;

            y = (int)i;
            Console.WriteLine($"{y}");

            u = (int)i;
            Console.WriteLine($"{u}");

            t = (int)i;
            Console.WriteLine($"{t}");

            f = (int)i;
            Console.WriteLine($"{f}");

            g = (int)i;
            Console.WriteLine($"{g}");

            //Неявные преобразования

            int num = -1;

            long h = num;
            Console.WriteLine($"{h}");

            int j = num;
            Console.WriteLine($"{j}");

            double k = num;
            Console.WriteLine($"{k}");

            float l = num;
            Console.WriteLine($"{l}");

            double z = num;
            Console.WriteLine($"{z}");

            //упаковка и распаковка

            int ii = 123;
            object v = ii;

            int m = (int)o;

            //работа с неявно типизированной переменной

            var qq = 15;
            var ww = "Dada ya da";

            //nullable

            int? qwe;

            //Определить переменную var

            //var rrк = 5;
            //rrк = 5.1;
            //Ошибка из-за того, что неявной переменной присвоили значение int,
            //а потом ей же присвоили значение float.

            ////////////////////////////////////////////////////////////////////

            // СТРОКИ //

            //Объявите строковые литералы, сравните их

            var string1 = "Я съел пюре из брюквы";
            var string2 = "Я съел луковицу";

            var equal = string1 == string2;
            Console.WriteLine(equal);

            //Сцепление, копирование и тд.

            var string11 = "Я";
            var string12 = "съел";
            var string13 = "пюре";

            string string22 = string11 + ' ' + string12 + ' ' + string13;
            Console.WriteLine(string22);

            //Копирование

            string11 = String.Copy(string12);

            //Разделение на слова

            string[] info = { "Name: Alex", "Dada", "Eto ya" };
            Console.WriteLine(info);

            int found = 0;

            //Удаление

            foreach (string ss in info)
            {
                found = ss.IndexOf(":");
                Console.WriteLine("{0}", ss.Substring(found + 2));
            }

            //IsNullOrEmpty

            string st1 = " ";
            string st2 = null;

            string[] array = { st1, st2 };

            if (String.IsNullOrEmpty(st1))
            {
                Console.WriteLine("Is Null");
            }
            else { Console.WriteLine("Is Empty"); }

            if (String.IsNullOrEmpty(st2))
            {
                Console.WriteLine("Is Null");
            }
            else { Console.WriteLine("Is Empty"); }

            //String Builder

            System.Text.StringBuilder sb = new System.Text.StringBuilder("съел пюре ");
            sb.Insert(0, "Я ");
            sb.AppendFormat("из брюквы");
            Console.WriteLine(sb);

            // МАССИВЫ //

            //a

            int[,] myArray = { { 0, 1, 2 }, { 3, 4, 5 } };
            int rows = myArray.GetUpperBound(0) + 1;
            int columns = myArray.Length / rows;

            for (int count = 0; count < rows; count++)
            {
                for (int counter = 0; counter < columns; counter++)
                {
                    Console.Write($"{myArray[count, counter]} \t");
                }
                Console.WriteLine();
            }

            //b

            string[] daysOfWeek = { "Monday", "Tuersday", "Wednesday", "Thirsday", "Friday", "Saturday", "Sunday" };
            for (int jj = 0; jj < daysOfWeek.Length; jj++)
            {
                Console.WriteLine(daysOfWeek[jj]);
                Console.WriteLine(daysOfWeek.Length);

            }

            // c

            Random rand = new Random();
            int rr;
            int[][] array3 = new int[3][];
            array3[0] = new int[2];
            array3[1] = new int[3];
            array3[2] = new int[4];
            for (rr = 0; r < 2; r++)
            {
                array3[0][r] = rand.Next(1, 15);
                Console.WriteLine("{0}", array3[0][r]);
            }
            Console.WriteLine();
            for (rr = 0; r < 3; r++)
            {
                array3[1][r] = rand.Next(1, 15);
                Console.WriteLine("{0}", array3[1][r]);
            }
            Console.WriteLine();
            for (rr = 0; r < 4; r++)
            {
                array3[2][r] = rand.Next(1, 15);
                Console.WriteLine("{0}", array3[2][r]);
            }
            Console.WriteLine();

            //d

            var array4 = new Object[0];
            var str1 = "";

            // КОРТЕЖИ //

            //a

            (int, string, char, string, ulong) cart1 = (7, "Hi", 'r', "Brukva", 14);

            //b

            Console.WriteLine(cart1);
            Console.WriteLine(cart1.Item1 + " " + cart1.Item4);

            //c

            (var aa, var bb) = (10, "брюкв");
            Console.WriteLine(aa + " " + bb);

            //d

            var cart3 = (A: 1, B: 2);
            var cart4 = (A: 1, B: 2);
            Console.WriteLine((cart3.Item1, cart3.Item2) == (cart4.Item1, cart4.Item2));

            // Создайте локальную функцию в main и вызовите ее //

            static (int, int, int, char) fun(int[] a, string b)
            {
                int max = a.Max<int>();
                int min = a.Min<int>();
                int sum = a.Sum();
                (int, int, int, char) kor = (max, min, sum, b[0]);
                Console.WriteLine(kor);
                return kor;
            }

            int[] arr = { 2, 1, 4, 5, 3 };

            fun(arr, "abcdefg");

            //Работа с checked/unchecked

            int function1()
            {
                int maxVal = 2147483647;
                int z = 0;
                try
                {
                    z = checked(maxVal + 11);
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine(e.ToString());
                }
                return z;
            }

            int function2()
            {
                int maxVal = 2147483647;
                int z = 0;
                try
                {
                    z = maxVal + 11;
                }
                catch (System.OverflowException e)
                {
                    Console.WriteLine(e.ToString());
                }
                return z;
            }

            Console.WriteLine("fisrt : {0}", function1());
            Console.WriteLine("second : {0}", function2());
        }
    }
}
