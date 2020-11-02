using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    interface Iactionable
    {
        void Run();
        void Attack();
        void Protect();
        void Speek();

    }

    interface Ialive
    {
        void Clone();
    }

    public abstract class Fighter : Iactionable
    {
        protected string name;
        protected int age;
        protected int height;
        protected string weapon;
        protected int id;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public string Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString() // переопределение с выводом доп инфы
        {
            Console.WriteLine(Name + " " + Age + " " + Height + " " + Weapon + " " + Id);
            return " type " + base.ToString();
        }


        virtual public bool ChangeWeapon(string newWeapon)
        {
            return true;
        }



        public abstract void Run(); // откладываем реализацию методов
        public abstract void Attack();
        public abstract void Protect();
        public abstract void Speek();


        public abstract void Clone();

    }

    public class Hunter : Fighter, Ialive
    {
        public Hunter(string name, int id, int height, string weapon, int age)
        {
            this.name = name;
            this.id = id;
            this.height = height;
            this.weapon = weapon;
            this.age = age;
        }
        override public void Speek() // реализуем методы из интерфейса
        {
            Console.WriteLine("Hello");
        }

        public override void Attack()
        {
            Console.WriteLine("Атака завершена");
        }

        public override void Run()
        {
            Console.WriteLine("Бежать вперёд");
        }

        public override void Protect()
        {
            Console.WriteLine("Защищаться");
        }

        public override void Clone() // метод из абстрактного класса с таким же названием
        {
            Console.WriteLine("Это метод из астрактного класса");
        }

        void Ialive.Clone()   // метод из интерсфеса с таким же названием
        {
            Console.WriteLine("метод интерфейса");
        }


        public override bool ChangeWeapon(string newWeapon)
        {
            if (newWeapon != null && newWeapon != "")
            {
                name = newWeapon;
                return true;
            }
            else return false;
        }

    }







    public class Shaman : Fighter, Ialive
    {



        public Shaman(string name, int id, int height, string weapon, int age)
        {
            this.name = name;
            this.id = id;
            this.height = height;
            this.weapon = weapon;
            this.age = age;
        }

        public override void Clone()
        {
            Console.WriteLine("Это метод из астрактного класса");
        }

        void Ialive.Clone()
        {
            Console.WriteLine("метод интерфейса");
        }
        override public void Speek()
        {
            Console.WriteLine("Hello");
        }

        public override void Attack()
        {
            Console.WriteLine("Атака завершена");
        }

        public override void Run()
        {
            Console.WriteLine("Бежать вперёд");
        }

        public override void Protect()
        {
            Console.WriteLine("Защищаться");
        }


        public override bool ChangeWeapon(string newWeapon)
        {
            if (newWeapon != null && newWeapon != "")
            {
                name = newWeapon;
                return true;
            }
            else return false;
        }

    }





    sealed public class Psychic : Shaman
    {


        public int soulsNumber;


        public Psychic(string name, int id, int height, string weapon, int age, int soulsNumber) : base(name, id, height, weapon, age)
        {
            this.soulsNumber = soulsNumber;
        }

        public bool canAttack()
        {
            if (soulsNumber < 7)
                return false;
            else
                return true;
        }


    }











    sealed public class Archer : Hunter
    {

        int arrowsNumber;

        public Archer(string name, int id, int height, string weapon, int age, int arrowsNumber) : base(name, id, height, weapon, age)
        {
            this.arrowsNumber = arrowsNumber;
        }


        public bool useTenArrows()
        {
            if (arrowsNumber < 10)
                return false;
            else
                return true;
        }
    }

    public static class GenFighter<Type> where Type : Fighter
    {

        public static void Func(Type fighter)
        {
            Console.WriteLine($"Имя {fighter.Name}");
            Console.WriteLine($"Возраст {fighter.Age}");
            Console.WriteLine($"Возраст {fighter.Weapon}");
        }

    }

    public class forObject : Object // переопределение методов Object
    {
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;
            return true; ;
        }

        public string Name { get; set; }
        int sNumber;

        public override int GetHashCode()
        {
            int hash = 269;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = (hash * 47) + sNumber.GetHashCode();
            return hash;
        }

    }
    public class Printer
    {
        public void IAmPrinting(Fighter fighter)
        {
            Console.WriteLine(fighter.ToString());
        }
    }
}
