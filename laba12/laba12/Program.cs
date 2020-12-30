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
    public interface Show
    {
        void Show();
    }
    public class Test : Show
    {
        public string name;
        public Test(string name)
        {
            this.name = name;
        }
        public Test()
        {
            this.name = null;
        }
        public void Show()
        {
            Console.WriteLine(name);
        }
        public void ToConsole(List<string> spisok)
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
    static class Reflector
    {
        static public void ClName(string classname)
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
        static public void GetConstructor(string classname)
        {
            ConstructorInfo[] p = Type.GetType(classname).GetConstructors();
            Console.WriteLine();
            Console.WriteLine("Имеет ли класс конструкторы?");
            if (p.Length > 0)
                Console.WriteLine($"Да, {p.Length}");
            else
                Console.WriteLine("Нет!");
        }
        static public void Publi(string classname)
        {
            Type t = Type.GetType(classname);
            Console.WriteLine();
            Console.WriteLine("Список методов: ");
            foreach (MethodInfo cMethod in t.GetMethods())
            {
                Console.WriteLine(cMethod.Name);
            }
        }
        static public void Field(string classname)
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
        static public void Interface(string classname)
        {
            Type t = Type.GetType(classname);
            Console.WriteLine();
            Console.WriteLine("Список интерфейсов: ");
            foreach (Type tp in t.GetInterfaces())
            {
                Console.WriteLine(tp.Name);
            }
        }
        static public void MethodForType(string classname, string parametr)
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
        public static void CallMethod(string className, string methodName)
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
        static public void Create(string classname, string name)
        {
            Type t = Type.GetType(classname);
            ConstructorInfo[] p = Type.GetType(classname).GetConstructors();
            object obj = Activator.CreateInstance(t, args: name);
            Console.WriteLine(obj.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.ClName("laba12.Test");
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