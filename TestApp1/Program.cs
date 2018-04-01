using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

enum weekDays
{
    Sunday,
    Monday, 
    Tuesday,
    Wednsday,
    Thursday,
    Friday,
    Saturday
}

namespace TestApp1
{

    class Program
    {
        static void Main(string[] args)
        {
           
        Dog dog = new Dog("Joseph", "Bullterier", new DateTime(1996, 5, 29));

        dog.Describe();




            




            Console.ReadLine();
        }
    }
    class Animal
    {
        //CONSTRUCTORS
        public Animal(string name, string race, DateTime birthdate)
        {
            _Name = name;
            _Race = race;
            _BirthDate = birthdate;

            Describe = PrintName;
            Describe += PrintRace;
            Describe += PrintAge;
            Describe += MakeSound;
        }


        //FIELDS
        protected string _Name;
        protected string _Race;
        protected DateTime _BirthDate;

        public DescribeMe Describe;

        //METHODS
        virtual public void MakeSound()
        {
            Console.WriteLine("Default sound");
        }
        
        public void PrintAge()
        {
            Console.WriteLine("Im {0} Years old", (int)DateTime.Now.Subtract(_BirthDate).TotalDays/365);
        }

        public void PrintName()
        {
            Console.WriteLine("My name is {0}", _Name);
        }

        public void PrintRace()
        {
            Console.WriteLine("My race is {0}", _Race);
        }

        public delegate void DescribeMe();


        //PROPERTIES
        public string Name
        {
            get { return _Name; }
            private set { }
        }

        public string Race
        {
            get { return _Race; }
            private set { }
        }

        public DateTime BirthDate
        {
            get { return _BirthDate; }
            private set { }
        }

    }

    class Dog : Animal
    {
        public Dog(string name, string race, DateTime birthdate)
            :base( name, race, birthdate)
        {
           
        }


        public override void MakeSound()
        {
            Console.WriteLine("Whooof!");
        }

    }
   
}
