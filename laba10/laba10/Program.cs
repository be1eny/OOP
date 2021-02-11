using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public class Game<T> : IEnumerable<T> where T : Player //наследуемый класс
    {
        public BlockingCollection<T> players = new BlockingCollection<T>();
        public Dictionary<int, T> dict = new Dictionary<int, T>();
        public Player winner;
        Random rnd = new Random();
        public void StartGame() //старт игры
        {
            foreach (var item in players)
            {
                item.number = rnd.Next(1, 1000);
            }
            winner = players.OrderByDescending(i => i.number).First(); //операция упорядочевания 
        }
        public void Show() //показ игроков
        {
            foreach (var item in players)
            {
                Console.WriteLine(item);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() //получение счетчика
        {
            return this.GetEnumerator();
        }
        IEnumerator<T> GetEnumerator()
        {
            foreach (T foo in this.players)
            {
                yield return foo;
            }
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)players).GetEnumerator();
        }
    }
    public class Player //класс игрок 
    {
        public string name; //переменные класса 
        public int number;
        public Player(string name)
        {
            this.name = name;
            this.number = 0;
        }
        public override string ToString() //вывод числа игрока
        {
            return name + " создал число " + number;
        }
    }

    //№2-6

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;

    namespace _2_6
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<User> Users = new List<User>();
                Users.Add(new User("Ivan", "a@example.com", "123"));
                Users.Add(new User("Petr", "c@example.com", "123"));
                Users.Add(new User("Gosha", "a@example.com", "123"));
                Users.Add(new User("Daniil", "a@example.com", "123"));
                Users.Add(new User("Alexey", "op@example.com", "123"));

                for (int i = 0; i < Users.Count - 1; i++)
                    Console.WriteLine($"Результат сравнения {Users[i]} и {Users[i + 1]}: {Users[i].CompareTo(Users[i + 1])}");

                foreach (var user in Users)
                {
                    WebNet.Add(user);
                    Console.WriteLine(user.Status);
                }

                Console.WriteLine("Count: " + WebNet.CountOfSingIn());
                WebNet.Serialization();

            }
            public static class WebNet
            {
                private static LinkedList<User> GitHub = new LinkedList<User>();
                public static void Add(User u)
                {
                    GitHub.AddLast(u);
                }
                public static void Remove(User u)
                {
                    GitHub.Remove(u);
                }
                public static int CountOfSingIn()
                {
                    return GitHub.Where(x => x.Status == Statuses.SingnIn).Count();
                }
                public static void Serialization()
                {

                    using (FileStream fs = new FileStream("Users.bin", FileMode.Create))
                    {
                        List<User> Users = new List<User>();
                        foreach (var user in GitHub.Where(x => x.Status == Statuses.SingnIn))
                            Users.Add(user);
                        //XmlSerializer xml = new XmlSerializer(Users.GetType());
                        //xml.Serialize(fs, Users);
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, Users);

                    }
                }
            }
            [Serializable]
            public class User : IComparable
            {
                public User(string name, string email, string password)
                {
                    Name = name;
                    Email = email;
                    Password = password;
                    Random rnd = new Random();
                    Status = (Statuses)rnd.Next(0, 2);
                    ID = id++;
                }
                private static int id = 1;
                public string Name { get; set; }
                public int ID { get; private set; }
                private string Email { get; set; }
                private string Password { get; set; }
                public Statuses Status { get; set; }

                public int CompareTo(object obj)
                {
                    return Email.CompareTo(((User)obj).Email);
                }

                public override bool Equals(object obj)
                {
                    return ID == ((User)obj).ID;
                }
                public override int GetHashCode()
                {
                    return ID;
                }
                public override string ToString()
                {
                    return Name;
                }

            }
            public enum Statuses
            {
                SingnIn,
                SingOut
            }
        }
    }

    //end

    class Program
    {
        public static void Ch(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Коллекция изменилась с действием: " + e.Action);
        }
        static void Main(string[] args)
        {
            Player firstPlayer = new Player("Леша"); //создание игроков
            Player secondPlayer = new Player("Артем");
            Player thirdPlayer = new Player("Женя");
            Player foursPlayer = new Player("Дима");

            Game<Player> RollGame = new Game<Player>();

            RollGame.players.Add(firstPlayer); //вызовы функций 
            RollGame.players.Add(secondPlayer);
            RollGame.players.TryAdd(thirdPlayer);
            RollGame.players.TryAdd(foursPlayer);
            /*RollGame.players.Take();*/
            RollGame.players.CompleteAdding();

            RollGame.StartGame();

            RollGame.Show();
            Console.WriteLine("Игрок-победитель -  " + RollGame.winner.name);
            BlockingCollection<int> test = new BlockingCollection<int>();
            test.Add(1);
            test.Add(5);
            test.TryAdd(6);
            int x;
            test.TryTake(out x);
            foreach (var item in test)
                Console.WriteLine(item);
            RollGame.dict.Add(1, firstPlayer);
            RollGame.dict.Add(2, secondPlayer);
            RollGame.dict.Add(3, thirdPlayer);
            RollGame.dict.Add(4, foursPlayer);

            foreach (KeyValuePair<int, Player> element in RollGame.dict)
                Console.WriteLine("Ключ: {0}. Значение: {1}", element.Key, element.Value);

            if (RollGame.dict.ContainsValue(secondPlayer))
                Console.WriteLine("Содержит значение");
            else Console.WriteLine("Не содержит значение");

            ObservableCollection<int> obs = new ObservableCollection<int>();
            obs.CollectionChanged += Ch;
            obs.Add(5);
            obs.Remove(5);
        }
    }
}