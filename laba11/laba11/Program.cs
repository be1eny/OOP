using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    //№8-1

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    namespace _8_1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Shop Evroopt = new Shop("Евроопт");

                Evroopt.Add(new Item("Кока-кола 2л", 3.09f));
                Evroopt.Add(new Item("Спрайт 1л", 1.79f));
                Evroopt.Add(new Item("Фанта 0.5л", 1.19f));

                Console.WriteLine("Магазин: " + Evroopt);
                foreach (var item in Evroopt)
                    Console.WriteLine(item.Name + ":\t" + item.Price + " BYN");


                var Enumerator = Evroopt.GetEnumerator();
                Enumerator.MoveNext();
                Manager.Sale += new Manager.SaleHandler(Enumerator.Current.OnSale);
                Enumerator.MoveNext();
                Manager.Sale += new Manager.SaleHandler(Enumerator.Current.OnSale);

                Console.WriteLine("---------------РАСПРОДАЖА---------------");
                Manager.CommandSale();
                Console.WriteLine("Магазин: " + Evroopt);
                foreach (var item in Evroopt)
                    Console.WriteLine(item.Name + ":\t" + item.Price + " BYN");

                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Linq запрос: " + Evroopt.Where(x => x.Name == "Фанта 0.5л").Select(x => x.Price).First());
            }
            class Item
            {
                public Item(string name, float price)
                {
                    ID = ++id;
                    Name = name;
                    Price = price;
                }
                private static int id = 0;
                public string Name { get; set; }
                public int ID { get; set; }
                public float Price { get; set; }

                public void OnSale()
                {
                    Price = (float)Math.Round(Price / 2, 2);
                }
            }
            class Shop : IEnumerable<Item>
            {
                public Shop(string name)
                {
                    Name = name;
                }
                public string Name { get; }

                private Queue<Item> Items = new Queue<Item>();
                public void Add(Item item)
                {
                    Items.Enqueue(item);
                }
                public Item Remove()
                {
                    return Items.Dequeue();
                }
                public void Clear()
                {
                    Items.Clear();
                }

                public IEnumerator<Item> GetEnumerator()
                {
                    return Items.GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return Items.GetEnumerator();
                }
                public override string ToString()
                {
                    return Name;
                }
                public override bool Equals(object obj)
                {
                    return ((Shop)obj).Name == Name;
                }
                public static Shop operator +(Shop shop, Item item)
                {
                    shop.Add(item);
                    return shop;
                }
                public static Shop operator -(Shop shop, Item item)
                {
                    shop.Remove();
                    return shop;
                }

            }
            public static class Manager
            {
                public delegate void SaleHandler();
                public static event SaleHandler Sale;
                public static void CommandSale()
                {
                    Sale();
                }
            }
        }
    }

    //end

    class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }; //строки с месяцами 
            Console.WriteLine("Введите количество символов, которое должно совпадать с символами месяцев");
            int n = int.Parse(Console.ReadLine());
            IEnumerable<string> Months1 = months.Where(m => m.Length == n);
            foreach (string item in Months1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Только летние и зимние месяцы:");
            IEnumerable<string> Months2 = from m in months where m.StartsWith("J") || m.StartsWith("F") || m.StartsWith("Au") || m.StartsWith("D") select m; //вывод месяцев по первым буквам 
            foreach (string item in Months2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Месяц в алфавитном порядке:");
            IEnumerable<string> Months3 = months.OrderBy(s => s); //вывод по алфавиту
            foreach (string item in Months3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Месяцы с \"u\" и длиной строки не менне 4ех: ");
            IEnumerable<string> Months4 = months.Where(n1 => n1.Contains("u") && n1.Length >= 4); //4 и больше буквы
            foreach (string item in Months4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");

            Book book1 = new Book("Лесное чудище", "Дима", "Беларусь", 2001, 241, 44, "тонкий", 3); //создание книг
            Book book2 = new Book("Обитель Анубиса", "Саша", "Германия", 1995, 321, 32, "широкий", 6);
            Book book3 = new Book("Важный человек", "Дима", "США", 1950, 321, 100, "тонкий", 4);
            Book book4 = new Book("Величайший шоумен", "Женя", "Италия", 2010, 321, 28, "широкий", 2);
            Book book5 = new Book("Ведьмы", "Алина", "Норвегия", 1991, 321, 74, "тонкий", 8);

            List<Book> library = new List<Book>();
            library.Add(book1); //добваление в библиотеку 
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);

            Console.WriteLine("Введите автора для поиска:");
            string findAuthor = Console.ReadLine();
            var lib1 = library.Where(n3 => n3.Author == findAuthor); //поиск по автору 
            foreach (Book item in lib1)
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + item.Year);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Введите, после какого года необходим список книг:");
            int year = int.Parse(Console.ReadLine()); //поиск по году
            var lib2 = library.Where(n3 => n3.Year > year);
            foreach (Book item in lib2)
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + item.Year);
            }
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Cписок книг отсортированных по цене..."); //сортировка по цене 
            var lib3 = library.OrderBy(n4 => n4.Cost);
            foreach (Book item in lib3)
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + item.Cost);
            }
            Console.WriteLine("------------------------------------------------");

            var lib4 = library.Min(n5 => n5.BlindingTypeNumber);
            Console.WriteLine("Самая тонкая книга имеет толщину: " + lib4); //толщина книги
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("5 первых самых толстых книг...");
            var lib5 = library.OrderByDescending(n5 => n5.BlindingTypeNumber).Take(5);
            foreach (Book item in lib5)
            {
                Console.WriteLine(item.Author + " " + item.Title + " " + "толщина: " + item.BlindingTypeNumber);
            }
            Console.WriteLine("------------------------------------------------");

            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Оттава Сенаторз", Country ="Канада" }, //создание команды
                new Team { Name = "Сиэтл Кракен", Country ="США" }
            };
            List<Player> players = new List<Player>()
            {
            new Player {Name="Мэтт Мюррей", Team="Оттава Сенаторз"}, //создание игроков
            new Player {Name="Тома Шабо", Team="Оттава Сенаторз"},
            new Player {Name="Томми Томпсон", Team="Сиэтл Кракен"}
            };

            var result = players.Join(teams, p => p.Team, t => t.Name, (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country });
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
        }
    }
}
