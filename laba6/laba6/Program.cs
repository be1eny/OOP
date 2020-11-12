using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    enum Doc : int
    {
        Receipt, Waybill, Check
    }
    partial struct Information
    {
        public string client;
        public string organization;
    }
    interface IDocument
    {
        void Info();
    }
    public abstract class Document
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private Client client;
        private Organization organization;
        public Document(string title, DateTime date, Client client, Organization organization)
        {
            this.title = title;
            this.date = date;
            this.client = client;
            this.organization = organization;
        }
        public string Name
        {
            get { return client.Name; }
            set { client.Name = value; }
        }
        public string NameOfOrganization
        {
            get { return organization.NameOfOrganization; }
            set { organization.NameOfOrganization = value; }
        }
        public abstract void Info();
        virtual public int GetTotalPrice() { return 0; }
    }
    sealed public class Receipt : Document, IDocument //квитанция
    {
        private int servicePrice;
        public Receipt(string title, DateTime date, Client client, Organization organization, int servicePrice) : base(title, date, client, organization)
        {
            this.servicePrice = servicePrice;
        }
        public override string ToString()
        {
            return Title + " " + Date.ToString("MM/dd/yyyy") + " " + Name + " " + NameOfOrganization + " " + servicePrice;
        }
        public override void Info()
        {
            Console.WriteLine(Title + "\n" + "Дата заключения: " + Date.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + servicePrice);
        }
        override public int GetTotalPrice()
        {
            return servicePrice;
        }
    }
    sealed public class Waybill : Document, IDocument //накладная
    {
        private int servicePrice;
        public Waybill(string title, DateTime date, Client client, Organization organization, int servicePrice) : base(title, date, client, organization)
        {
            this.servicePrice = servicePrice;
        }
        public override string ToString()
        {
            return Title + " " + Date.ToString("MM/dd/yyyy") + " " + Name + " " + NameOfOrganization + " " + servicePrice;
        }
        public override void Info()
        {
            Console.WriteLine(Title + "\n" + "Дата заключения: " + Date.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + servicePrice);
        }
        override public int GetTotalPrice()
        {
            return servicePrice;
        }
    }
    sealed public class Check : Document, IDocument
    {
        private int totalPrice;
        public Check(string title, DateTime date, Client client, Organization organization, int totalPrice) : base(title, date, client, organization)
        {
            this.totalPrice = totalPrice;
        }
        public override string ToString()
        {
            return Title + " " + Date.ToString("MM/dd/yyyy") + " " + Name + " " + NameOfOrganization + " " + totalPrice;
        }
        public override void Info()
        {
            Console.WriteLine(Title + "\n" + "Дата заключения: " + Date.ToString("MM/dd/yyyy") + "\n" + "Клиент: " + Name + "\n" + "Организация: " + NameOfOrganization + "\n" + "Итоговая стоимость: " + totalPrice);
        }
        override public int GetTotalPrice()
        {
            return totalPrice;
        }
    }
    public class Client
    {
        private string name;
        public Client(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    public class Organization
    {
        private string nameOfOrganization;
        public Organization(string nameOfOrganization)
        {
            this.nameOfOrganization = nameOfOrganization;
        }
        public string NameOfOrganization
        {
            get { return nameOfOrganization; }
            set { nameOfOrganization = value; }
        }
    }
    public class Summa
    {
        List<Receipt> receipts = new List<Receipt>();
        List<Waybill> waybills = new List<Waybill>();
        List<Check> checks = new List<Check>();
        public Receipt this[int ind]
        {
            get
            {
                if (ind > receipts.Count)
                {
                    Console.WriteLine("Превышен максимальный индекс списка квитанций"); return null;
                }
                return receipts[ind];
            }
            set
            {
                if (ind > receipts.Count)
                    Console.WriteLine("Элемента с таким индексом не существует");
                else receipts[ind] = value;
            }
        }
        public void AddReceipt(Receipt a) { receipts.Add(a); }
        public void AddWaybill(Waybill a) { waybills.Add(a); }
        public void AddCheck(Check a) { checks.Add(a); }
        public void DelReceipt(Receipt a) { receipts.Remove(a); }
        public void DelWaybill(Waybill a) { waybills.Remove(a); }
        public void DelCheck(Check a) { checks.Remove(a); }

        public void ShowList()
        {
            Console.WriteLine("\n" + "Список квитанций: ");
            foreach (Receipt item in receipts)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n" + "Список накладных: ");
            foreach (Waybill item in waybills)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n" + "Список чеков: ");
            foreach (Check item in checks)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public int GetWaybillPrice(string name)
        {
            int price = 0;
            foreach (Waybill item in waybills)
            {
                if (item.Title == name)
                    price += item.GetTotalPrice();
            }
            return price;
        }
        public int GetCheckCount()
        {
            Console.WriteLine("");
            Console.WriteLine("Количество чеков:");
            return checks.Count;
        }
        public void GetTime(DateTime firstDate, DateTime secondDate)
        {
            Console.WriteLine("");
            foreach (Receipt item in receipts)
                if (item.Date > firstDate && item.Date < secondDate)
                    Console.WriteLine(item.ToString());
            foreach (Waybill item in waybills)
                if (item.Date > firstDate && item.Date < secondDate)
                    Console.WriteLine(item.ToString());
            foreach (Check item in checks)
                if (item.Date > firstDate && item.Date < secondDate)
                    Console.WriteLine(item.ToString());
        }
        public class SummaController
        {
            public void Show(Summa lis) { lis.ShowList(); }
            public int Price(Summa lis, string name) { int a = lis.GetWaybillPrice(name); return a; }
            public int Count(Summa lis) { int a = lis.GetCheckCount(); return a; }
            public void Get(Summa lis, DateTime firstDate, DateTime lastDate) { lis.GetTime(firstDate, lastDate); }
        }
    }
    partial struct Information
    {
        public string document;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Client first_client = new Client("Самцевич Алексей");

            Waybill first_waybill = new Waybill("Накладная 1", new DateTime(2020, 11, 05), first_client, new Organization("111"), 7800);
            Receipt first_receipt = new Receipt("Квитанция 1", new DateTime(2020, 11, 05), first_client, new Organization("222"), 650);
            Check first_check = new Check("Чек 1", new DateTime(2019, 11, 05), first_client, new Organization("333"), 150);
            Check second_check = new Check("Чек 2", new DateTime(2019, 11, 05), first_client, new Organization("444"), 10);

            Waybill second_waybill = new Waybill("Накладная 2", new DateTime(2016, 06, 12), first_client, new Organization("555"), 1200);
            Waybill third_waybill = new Waybill("Накладная 3", new DateTime(2015, 04, 01), first_client, new Organization("666"), 800);
            Waybill fours_waybill = new Waybill("Накладная 4", new DateTime(2020, 07, 12), first_client, new Organization("777"), 1200);

            Summa summa = new Summa();
            summa.AddWaybill(first_waybill);
            summa.AddReceipt(first_receipt);
            summa.AddCheck(first_check);
            summa.AddCheck(second_check);

            summa.AddWaybill(second_waybill);
            summa.AddWaybill(third_waybill);
            summa.AddWaybill(fours_waybill);

            summa.ShowList();

            Console.WriteLine("\n" + "Суммарную стоимость продукции заданного наименования по всем накладным = {0}", summa.GetWaybillPrice("Накладная 1"));
            Console.WriteLine(summa.GetCheckCount());
            summa.GetTime(new DateTime(2019, 01, 01), new DateTime(2021, 01, 01));


            //Console.WriteLine(first_waybill);
        }
    }
}
