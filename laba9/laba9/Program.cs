using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void BeLate(string str);
    public delegate void TakeMoney(object obj, EventArgs args);
    public delegate void Promotion(object obj, EventArgs args, string str);
    public delegate void Balance(Student b);
    class Program
    {
        static void Main(string[] args)
        {
            BeLate massage = (str) => Console.WriteLine(str);
            Balance balance = (show) => Console.WriteLine($"Текущая зарплата: { show.Salary} рублей");

            Dekan dekan = new Dekan();

            Student student1 = new Student(220, "студент");
            Undergraduate undergraduate1 = new Undergraduate(380, "магистрант");
            student1.Late();
            student1.RegisterHandler(massage);
            student1.Late();

            balance(student1);
            dekan.money += student1.Money;
            dekan.money += undergraduate1.Money;
            dekan.newMoney();
            student1.Late();
            student1.Late();
            balance(student1);
            dekan.newMoney();
            balance(student1);

            dekan.promotion += student1.ToPromoteStudent;
            dekan.ToPromote("выпускник-студент");
            dekan.promotion -= student1.ToPromoteStudent;
            dekan.promotion += undergraduate1.ToPromoteUndergraduate;
            dekan.ToPromote("выпускник-магистрант");
            balance(undergraduate1);
            Console.WriteLine();

            string str1 = "BeOutiful girll";

            Func<string, string> func;
            func = ChangeString.Delet;
            str1 = func(str1);
            Console.WriteLine(str1);
            Action<string, char> action;
            action = ChangeString.AddLetter;
            action(str1, 's');
            func += ChangeString.Oa;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ChangeString.SToApper;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ChangeString.SToLower;
            str1 = func(str1);
            Console.WriteLine(str1);
        }
    }
}
