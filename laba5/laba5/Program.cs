using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {

            Hunter hunter1 = new Hunter("Sam", 1743, 190, " kosa", 24);
            Archer archer1 = new Archer("Gos", 7312, 185, "lyk", 32, 1000);
            Shaman shaman1 = new Shaman("Trall", 3523, 215, "magic", 25);
            Psychic psychic1 = new Psychic("Sun", 4823, 170, "golos", 39, 1000);

            psychic1.Clone();                   // вызов метода у класса
            ((Ialive)psychic1).Clone();         // вызов метода у интерфейса


            Console.WriteLine("hunter1 is Hunter:" + (hunter1 is Hunter));
            Console.WriteLine("hunter1 is Archer:" + (hunter1 is Archer));
            Console.WriteLine("archer1 is Hunter:" + (archer1 is Hunter));
            Console.WriteLine("archer1 is Archer:" + (archer1 is Archer));

            //ToString дял всех 
            Console.WriteLine(archer1.ToString());

            // printer

            Printer printer = new Printer();
            printer.IAmPrinting(psychic1);

            Console.WriteLine("------------------Вывод через массив------------------------------");
            Fighter[] fighters = new Fighter[] { hunter1, archer1, shaman1, psychic1 };
            for (int i = 0; i < fighters.Length; i++)
            {
                printer.IAmPrinting(fighters[i]);
                Console.WriteLine("-------------------------");
            }
            Console.WriteLine("=============================");



            GenFighter<Fighter>.Func(shaman1);

        }
    }
}

