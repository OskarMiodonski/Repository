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
        public delegate void WypiszDaneZwierza(IAnimal ani);
        public delegate void WpiszDaneZwierzaDoPliku(IAnimal ani, StreamWriter swr);

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            WypiszDaneZwierza wpda = DescribeMe;
            wpda += MakeSound;


            WpiszDaneZwierzaDoPliku wpdp = DescribeMeToFile;
            wpdp += MakeMySoundToFile;

            Doge dog = new Doge("janus");
            Catz kitty = new Catz("frankie");

            
            wpda(dog);
            wpda(kitty);
            wpda(new Fishy("lilmo"));

            HelpPrint(wpda, dog);
            HelpPrint(wpda, kitty);
            HelpPrint(wpda, new Fishy("fis"));


            string ti;
            decimal pi;
            double rad = 3.0;
            double circle = 2 * Math.PI * rad;

            ti = (circle / (2 * rad)).ToString();
            pi = decimal.Parse(ti);
            
            Console.WriteLine(pi);



            Console.ReadLine();
        }

        public static void HelpPrint(WypiszDaneZwierza wpd, IAnimal ani)
        {
            wpd(ani);
        }

        public static void DescribeMeToFile(IAnimal ani, StreamWriter swr)
        {
            swr.WriteLine(ani.Describe());
        }

        public static void MakeMySoundToFile(IAnimal ani, StreamWriter swr)
        {
            swr.WriteLine(ani.makeSound());
        }





        public static void DescribeMe(IAnimal ani)
        {
            Console.WriteLine("Describing {0} : {1} ", ani.GetType(), ani.Describe());
        }


        public static void MakeSound(IAnimal ani)
        {
            Console.WriteLine("Making sound of {0} : {1} ", ani.GetType(), ani.makeSound());
        }

    }

    interface IAnimal
    {
        string Describe();
        string makeSound();
    }

    public static class MyUltility
    {
        public static bool isNumeric(this string s)
        {
            return float.TryParse(s, out float outpt);
        }
        
        public static void add1(ref int val)
        {
            val += 1;
        }
        

    }

    class testClass<VariableType> where VariableType: struct
    {

        public static void PrintType()
        {
            Console.WriteLine("Type of variable is: " + typeof(VariableType));
        }



    }

    class Doge : IAnimal
    {
        public Doge(string name)
        {
            this.Name = name;   
        }

        private string Name;
  
        public  string Describe()
        {
            return "Imma dogge named " + Name;
        }
        public string makeSound()
        {
            return "WHOOF";
        }

    }

    class Catz : IAnimal
    {
        public Catz(string name)
        {
            this.Name = name;
        }

        private string Name { get; set; }
        public string Describe()
        {
            return "Imma catz named " + Name;
        }
        public string makeSound()
        {
            return "Meow";
        }
    }

    class Fishy : IAnimal
    {
        public Fishy(string name)
        {
            this.Name = name;
            this.Race = "Pstrag";

        }   

        public string Name { get; set; }
        public string Race { get; set; }


        public string Describe()
        {
            return "Imma fishy named " + Name + "of race " + Race.ToString();
        }
        public string makeSound()
        {
            return "blurp";
        }
    }
}
