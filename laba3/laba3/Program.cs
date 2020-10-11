using System;

namespace laba3
{
    class Program
    {
        public partial class Book
        {
            //Свойства get set
            private int o = 49;
            public int a
            {
                get
                {
                    return o;
                }
                protected set
                {
                    o = value;
                }

            }

            public int idP;
            public readonly string nameP;
            public string authorP;
            public string publishP;
            public const int pages_pu = 228;
            public int costP;
            public string bindtypeP;

            public static int idS;
            public static readonly string nameS;
            public static string authorS;
            public static string publishS;
            public static int pagesS;
            public static int costS;
            public static string bindtypeS;

            static int count = 0;

            static Book()
            {
                idS = 112233;
                nameS = "Война и Мир";
                authorS = "Булгаков";
                publishS = "2012год";
                pagesS = 1430;
                costS = 25;
                bindtypeS = "Твердый";
                count++;
            }



            public Book(ref string x)
            {
                idP = 123123;
                nameP = x;
                authorP = "Лермонтов";
                publishP = "2011год";
                costP = 25;
                bindtypeP = "Твердый";
                count++;
            }

            private Book(string y)
            {
                idP = 123123;
                nameP = "Война и Мир";
                authorP = "Толстой";
                publishP = y;
                costP = 25;
                bindtypeP = "Твердый";
                count++;
            }

            public Book(string z = "Горе от ума", string v = "мягкий")
            {

                nameP = z;
                authorP = "Пушкин";
                publishP = "2010год";
                costP = 25;
                bindtypeP = v;
                count++;

            }
            public static void DisplayCounter()
            {
                Console.WriteLine($"Создано {count} объектов ");
            }
            public void GetInfo1()
            {
                Console.WriteLine($"-----------------------------------\n" +
                    $"ID книги:{idP} \n" +
                    $" Название книги:{nameP}\n" +
                    $" Автор:{authorP}\n" +
                    $" Издательство:{publishP}\n" +
                    $" Кол-во страниц:{pages_pu}" +
                    $"Стоимость:{costP}\n" +
                    $" Тип переплета:{bindtypeP}" +
                    $"\n-----------------------------------\n\n\n");
            }

            public void GetInfo2()
            {
                Console.WriteLine($"-----------------------------------\n" +
                    $"ID книги:{idS} \n" +
                    $" Название книги:{nameS}\n" +
                    $" Автор:{authorS}\n" +
                    $" Издательство:{publishS}\n" +
                    $" Кол-во страниц:{pagesS}" +
                    $"Стоимость:{costS}\n" +
                    $" Тип переплета:{bindtypeS}" +
                    $"\n-----------------------------------\n\n\n");
            }

            public override string ToString()
            {
                return "Переопределенный тустринг:    " + costS;
            }
        }


        static void Main(string[] args)
        {
            string b = "Книжка";
            Book Book1 = new Book();
            Book Book2 = new Book(ref b);
            Book Book3 = new Book("название чего-нибудь");

            Book1.GetInfo2();
            Book2.GetInfo1();
            Book3.GetInfo1();
            Book.DisplayCounter();

            Book c1 = new Book();
            Book c2 = new Book();

            Console.WriteLine("Tostring::{0}", c1.ToString());
            Console.WriteLine("Tostring::{0}", c2.ToString());
            Console.WriteLine("\n\n\nHashcode1: {0}", c1.GetHashCode());
            Console.WriteLine("Hashcode1: {0}", c2.GetHashCode());

            if (c1.Equals(c2) && c2.Equals(c1))
                Console.WriteLine("\n\nTrue");
            else
                Console.WriteLine("\n\nFalse");

            Console.WriteLine("Введите автора");
            string u = Console.ReadLine();
            Console.WriteLine("Введите год издания");
            string k = Console.ReadLine();

            Book[] arr = new Book[] { Book2, Book3 };
            for (int i = 0; i < 3; i++)
            {
                if (u == arr[i].authorP && k == arr[i].publishP)
                {

                    Console.WriteLine($"-----------------------------------\n" +
                        $"ID книги:{arr[i].idP} \n" +
                        $" Название книги:{arr[i].nameP}\n" +
                        $" Автор:{arr[i].authorP}\n" +
                        $" Издательство:{arr[i].publishP}\n" +
                        $"Стоимость:{arr[i].costP}\n" +
                        $"Тип переплета:{arr[i].bindtypeP}\n" +
                        $"\n-----------------------------------\n\n\n");
                }

                else
                {
                    if (u != arr[1].authorP

                      && u != arr[0].authorP
                      || k != arr[0].publishP
                      && k != arr[1].publishP)
                    {
                        Console.WriteLine("В заданной конфигурации книг нет");
                        break;
                    }
                    else
                        continue;
                }
            }
            var anonim = new { Name = "Книга", value = 5 };
            Console.WriteLine($"{anonim}");
        }

    }
}
