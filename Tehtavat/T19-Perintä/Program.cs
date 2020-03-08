/* T19-Perintä
 * Tehtävänanto:
 * Pohdi jokin reaalimaailman asia, jonka kautta voit toteuttaa pienimuotoisen C#-ohjelman/toteutuksen, joka käyttää perintää.
 */

using System;

namespace T19_Perintä
{
    class Bug
    {
        // properties
        public string Type { get; set; }
        public virtual int Legs { get; } // leg amount is standard in same species
        public int Eyes { get; set; } // eye amount varies between same species e.g. Spiders
        public int Wings { get; set; } // wings amount varies between same species e.g. Spiders

        // methods
        public string Eat()
        {
            return $"{Type} is eating!";
        }
        public string Move()
        {
            return $"{Type} is moving";
        }
        public string Mate()
        {
            return $"{Type} is looking for a mating partner";
        }
        public string FindFood()
        {
            return $"{Type} is looking for food to eat";
        }
        public string Fly()
        {
            if (Wings >= 2)
                return $"{Type} is flying around aimlessly...";
            else
                return $"{Type} can't fly!";
        }
        public override string ToString()
        {
            return $"{Type} has {Legs} legs, {Eyes} eyes and {Wings} wings.";
        }
    }
    class Spider : Bug
    {
        public override int Legs
        {
            get
            {
                return 8;
            }
        }
    }
    class Ant : Bug
    {
        public override int Legs
        {
            get
            { 
                return 6; 
            }
        }
    }
    class Fly : Bug
    {
        public override int Legs
        {
            get
            {
                return 4;
            }
        }
    }
    class Myriopoda : Bug // tuhatjalkainen
    {
        public override int Legs
        {
            get
            {
                return 750;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // create a spider and move it around
            Spider juoksuHämähäkki = new Spider { Eyes = 6, Type = "Juoksuhämähäkki", Wings = 0 };
            Console.WriteLine(juoksuHämähäkki.Move());
            Console.WriteLine(juoksuHämähäkki.Fly());
            Console.WriteLine(juoksuHämähäkki.ToString());
            // create another spider
            Spider mustaLeski = new Spider { Eyes = 8, Type = "Musta Leski", Wings = 0 };
            Console.WriteLine(mustaLeski.Mate());
            Console.WriteLine(mustaLeski.ToString());
            // create an ant and a queen ant
            Ant työläinenMuurahainen = new Ant { Type = "Työläinen", Eyes = 2, Wings = 0 };
            Ant kuningatarMuurahainen = new Ant { Type = "Kuningatar muurahainen", Eyes = 2, Wings = 2 };
            Console.WriteLine(työläinenMuurahainen.FindFood());
            Console.WriteLine(kuningatarMuurahainen.Eat());
            Console.WriteLine(kuningatarMuurahainen.Fly());
            Console.WriteLine(työläinenMuurahainen.ToString());
            Console.WriteLine(kuningatarMuurahainen.ToString());
            // create a myriopida
            Myriopoda tuhatjalkainen = new Myriopoda { Type = "Illacme plenipes", Eyes = 2, Wings = 0 };
            Console.WriteLine(tuhatjalkainen.ToString());
        }
    }
}
