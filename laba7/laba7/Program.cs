using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace laba7
{
    class Program
    {
        static void Main(string[] args)
        {
            Client first_client = new Client("Самцевич Алексей");
            try
            {
                Console.WriteLine("---------------------------------------------------------------------");
                try
                {
                    Waybill first_waybill = new Waybill("Накладная 1", new DateTime(2020, 11, 05), first_client, new Organization("111"), 7800, 0);
                }
                catch (IsNotNameOfOrganization ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");

                try
                {
                    Receipt first_receipt = new Receipt("Накладная 2", new DateTime(2020, 11, 05), first_client, new Organization("222"), 7800, 1);
                }
                catch (IsNotTitle ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");

                try
                {
                    Check first_check = new Check("Накладная 3", new DateTime(2020, 11, 05), first_client, new Organization("333"), 7800, 1);
                }
                catch (WrongIdValue ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");

                Waybill second_waybill = new Waybill("Накладная 1", new DateTime(2020, 11, 05), first_client, new Organization("111"), 7800, 0);
                Waybill third_waybill = new Waybill("Накладная 2", new DateTime(2020, 11, 05), first_client, new Organization("222"), 7800, 1);
                Waybill fours_waybill = new Waybill("Накладная 3", new DateTime(2020, 11, 05), first_client, new Organization("333"), 7800, 1);

                Document[] documents = new Document[] { second_waybill, third_waybill, fours_waybill };

                try
                {
                    Console.WriteLine(documents[4].Id);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");

                try
                {
                    object obj = third_waybill.Title;
                    int title = (int)obj;
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }
                Console.WriteLine("---------------------------------------------------------------------");
                try
                {
                    double countHashCode = third_waybill.Id / second_waybill.Id;

                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("---------------------------------------------------------------------");

                int index = 10;
                Debug.Assert(index > -1, "Значение должно быть больше -1");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
        }
    }
}
