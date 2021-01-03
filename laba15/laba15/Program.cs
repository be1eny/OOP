using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace laba15
{
    class Program
    {
        public static bool Prostie(int n)
        {
            bool result = true;
            if (n > 1)
            {
                for (uint i = 2u; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static void Operation() //метод операции
        {
            int n = 100;
            for (int i = 2; i <= n; i++)
            {
                if (Prostie(i))
                {
                    Console.Write("Второй поток:");
                    Console.WriteLine(i);
                }
            }
        }
        public static void Event() //метод события
        {
            for (int i = 2; i < 100; i += 2)
            {
                Thread.Sleep(100); //время сна потока
                Console.WriteLine(i);
            }
            Thread.Sleep(20);
        }
        public static void NEvent() //метод нет события
        {
            for (int i = 1; i < 100; i += 2)
            {
                Thread.Sleep(100);
                Console.WriteLine(i);
            }
            Thread.Sleep(20);
        }
        public static void Count(object obj) //метод количество
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine($"{x * i}");
            }
        }
        static Mutex mutexObj = new Mutex();
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("prosesses.txt", false, System.Text.Encoding.Default))
            {
                foreach (Process p in Process.GetProcesses())
                {
                    sw.WriteLine("Id " + p.Id); //вывод инфомации о потоках 
                    sw.WriteLine("Name " + p.ProcessName);
                    sw.WriteLine("Priority " + p.BasePriority);
                    sw.WriteLine("Responding " + p.Responding);
                    sw.WriteLine("HandleConut " + p.HandleCount);
                    sw.WriteLine();
                }
            }
            using (StreamWriter sw = new StreamWriter("Domain.txt"))
            {
                AppDomain app = AppDomain.CurrentDomain;
                sw.WriteLine("Id: " + app.Id);
                sw.WriteLine("Name: " + app.FriendlyName);
                sw.WriteLine("Directory: " + app.BaseDirectory);
                Assembly[] assApp = app.GetAssemblies();
                foreach (Assembly item in assApp)
                {
                    sw.WriteLine("Assembly name: " + item.FullName);
                }
            }
            int n = 100;

            Thread th = new Thread(new ThreadStart(Operation));
            Console.WriteLine(th.ThreadState);
            Console.WriteLine(th.Priority);
            th.Name = "Second Thread";
            Console.WriteLine(th.Name);
            Console.WriteLine("id " + th.ManagedThreadId);
            th.Start();
            for (int i = 2; i <= n; i++)
            {
                if (Prostie(i))
                {
                    Console.Write("Главный поток:");
                    Console.WriteLine(i);
                }
            }
            Thread.Sleep(1000); //сон 1000 мс

            Thread th1 = new Thread(new ThreadStart(Event));
            Thread th2 = new Thread(new ThreadStart(NEvent));
            th1.Priority = ThreadPriority.AboveNormal;
            th1.Start();
            th2.Start();

            Console.ReadLine(); //чтение строки
            int num = 0;
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, num, 0, 2000);
            Console.ReadLine();
        }
    }
}
