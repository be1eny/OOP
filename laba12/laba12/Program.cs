using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    public interface Show //интерфейс
    {
        void Show();
    }
    public class Test : Show
    {
        public string name;
        public Test(string name) //строка имени
        {
            this.name = name;
        }
        public Test()
        {
            this.name = null;
        }
        public void Show() //вывод имени
        {
            Console.WriteLine(name);
        }
        public void ToConsole(List<string> spisok) //вывод в консоль
        {
            foreach (string str in spisok)
            {
                Console.WriteLine(str);
            }
        }
        public override string ToString()
        {
            return "Объект класса Test с именем " + name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
    static class Reflector //класс рефлексии
    {
        static public void ClName(string classname) //класс вывода сборки
        {
            Assembly tekushchayaAssembly = Assembly.GetExecutingAssembly();
            Type t = tekushchayaAssembly.GetType(classname);
            Assembly assem = t.Assembly;
            Console.WriteLine("Полное имя сборки: ");
            Console.WriteLine(assem.FullName);
            Console.WriteLine();
            Console.WriteLine("Расположение сборки: ");
            Console.WriteLine(assem.CodeBase);
        }
        static public void GetConstructor(string classname) //класс показывающий конструкторы
        {
            ConstructorInfo[] p = Type.GetType(classname).GetConstructors();
            Console.WriteLine();
            Console.WriteLine("Имеет ли класс конструкторы?");
            if (p.Length > 0)
                Console.WriteLine($"Да, {p.Length}");
            else
                Console.WriteLine("Нет!");
        }
        static public void Publi(string classname) //класс показывающий методы
        {
            Type t = Type.GetType(classname);
            Console.WriteLine();
            Console.WriteLine("Список методов: ");
            foreach (MethodInfo cMethod in t.GetMethods())
            {
                Console.WriteLine(cMethod.Name);
            }
        }
        static public void Field(string classname) //класс показывающий поля
        {
            Type t = Type.GetType(classname);
            Console.WriteLine();
            Console.WriteLine("Список полей: ");
            foreach (FieldInfo fInfo in t.GetFields())
            {
                Console.WriteLine(fInfo.FieldType.Name + " " + fInfo.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Список свойств: ");
            foreach (PropertyInfo pInfo in t.GetProperties())
            {
                Console.WriteLine(pInfo.PropertyType.Name + " " + pInfo.Name);
            }
        }
        static public void Interface(string classname) //класс показывающий интерфейсы
        {
            Type t = Type.GetType(classname);
            Console.WriteLine();
            Console.WriteLine("Список интерфейсов: ");
            foreach (Type tp in t.GetInterfaces())
            {
                Console.WriteLine(tp.Name);
            }
        }
        static public void MethodForType(string classname, string parametr) //класс показывающий методы с определенным типом
        {
            Type t = Type.GetType(classname);
            MethodInfo[] methods = t.GetMethods();
            Console.WriteLine();
            Console.WriteLine("Методы класса {0} с типом аргумента: {1}", classname, parametr);
            for (int i = 0; i < methods.Length; i++)
            {
                ParameterInfo[] param = methods[i].GetParameters();
                for (int j = 0; j < param.Length; j++)
                {
                    if (parametr == param[j].ParameterType.Name)
                    {
                        Console.WriteLine(methods[i].Name);
                    }
                }
            }
        }
        public static void CallMethod(string className, string methodName) //класс выполнения метода
        {
            Type type = Type.GetType(className);
            List<string> FirstParam = File.ReadAllLines(@"/Users/Alex/Univercity/OOP/laba12/laba12/Refl.txt").ToList();
            List<string>[] parametrs = new List<string>[] { FirstParam };
            try
            {
                object obj = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod(methodName);
                Console.WriteLine();
                Console.WriteLine("Результат выполнения метода: ");
                Console.WriteLine(method.Invoke(obj, parametrs));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static public void Create(string classname, string name) //класс создания 
        {
            Type t = Type.GetType(classname);
            ConstructorInfo[] p = Type.GetType(classname).GetConstructors();
            object obj = Activator.CreateInstance(t, args: name);
            Console.WriteLine(obj.ToString());
        }
    }

    //№ 3-2

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    namespace _3_2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Park<Taxi> Uber = new Park<Taxi>();
                Uber.Add(new Taxi() { Number = 1, Position = new Location() { Lat = 12.3439493f, Long = 483.129849384f, Speed = 63.2f }, Status = Statuses.busy });
                Uber.Add(new Taxi() { Number = 2, Position = new Location() { Lat = 42.3439493f, Long = 452.129849384f, Speed = 0f }, Status = Statuses.free });
                Uber.Add(new Taxi() { Number = 3, Position = new Location() { Lat = 22.3439493f, Long = 495.129849384f, Speed = 44.2f }, Status = Statuses.free });
                Uber.Add(new Taxi() { Number = 4, Position = new Location() { Lat = 17.3439493f, Long = 457.129849384f, Speed = 68f }, Status = Statuses.busy });

                Console.WriteLine("---Введите свои координаты---");
                Location UserLocation = new Location();
                Console.Write("Широта: ");
                UserLocation.Lat = float.Parse(Console.ReadLine());
                Console.Write("Долгота: ");
                UserLocation.Long = float.Parse(Console.ReadLine());

                List<Taxi> taxis = new List<Taxi>(Uber.park);
                var TaxisToUser = taxis.OrderBy(x => Math.Sqrt(Math.Pow(x.Position.Lat - UserLocation.Lat, 2) + Math.Pow(x.Position.Long - UserLocation.Long, 2)));
                foreach (var taxi in TaxisToUser)
                    Console.WriteLine(taxi.Number);

                using (FileStream sw = new FileStream("Taxi.bin", FileMode.Create))
                {
                    //XmlSerializer xml = new XmlSerializer(TaxisToUser.First().GetType());
                    //xml.Serialize(sw, TaxisToUser.First());
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(sw, TaxisToUser.First());
                }
            }
            [Serializable]
            public class Location
            {
                public float Lat { get; set; }
                public float Long { get; set; }
                public float Speed { get; set; }

            }
            [Serializable]
            public class Taxi
            {
                public int Number { get; set; }
                public Location Position { get; set; }
                public Statuses Status { get; set; }
            }
            [Serializable]
            public enum Statuses
            {
                busy,
                free
            }
            public class Park<T>
            {
                public List<T> park { get; } = new List<T>();
                public void Add(T obj)
                {
                    park.Add(obj);
                }
                public void Remove(int index)
                {
                    park.RemoveAt(index);
                }
                public void Clear()
                {
                    park.Clear();
                }
                public T Find(Predicate<T> predicate)
                {
                    foreach (var obj in park)
                    {
                        if (predicate(obj))
                            return obj;
                    }
                    return default(T);
                }
            }
        }
    }

    //end

    class Program
    {
        static void Main(string[] args) 
        {
            Reflector.ClName("laba12.Test"); //вызовы функций
            Reflector.GetConstructor("laba12.Test");
            Reflector.Publi("laba12.Test");
            Reflector.Field("laba12.Test");
            Reflector.Interface("laba12.Test");
            Reflector.MethodForType("laba12.Test", "Int32");
            Reflector.CallMethod("laba12.Test", "ToConsole");
            Reflector.Create("laba12.Test", "Alex FIT");
        }
    }
}