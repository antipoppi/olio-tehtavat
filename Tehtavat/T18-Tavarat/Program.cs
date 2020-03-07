/* T18-Tavarat
 * Tehtävänanto:
 * ICT-opiskelijan kirjahyllystä löytyy vaikka mitä erilaisia tavaroita: kirjoja, lehtiä,
 * cd-levyjä, dvd-levyjä, bluray-levyjä, puhelimia, tabletteja, läppäreitä, ... jne.
 * 
 * Pohdi UML-kaaviota käyttäen millaisia luokkarakenteita (ainakin luokkien ja ominaisuuksien osalta)
 * esiintyy ja käytä apua perintää, jos tavaroille löytyy yhteisiä ominaisuuksia.
 * Toteuta tämän jälkeen muutamia luokkia, joissa perintää esiintyy. Tee myös pääohjelma,
 * jossa käytät tekemiäsi luokkia ja luot olioita.
 */

using System;

namespace T18_Tavarat
{
    class Computer
    {
        public string ModelName { get; set; }
        public string OS { get; set; }
        public float Memory { get; set; }
        public float Storage { get; set; }
        public float Weight { get; set; }
        public string Compute()
        {
            return $"Some computing happens here";
        }
        public override string ToString()
        {
            return $"Computer model is {ModelName}, operating system is {OS}, it has {Memory} bytes of memory " +
                $"and {Storage} gigabytes of storage. It weights {Weight} kilograms";
        }
    }
    class Laptop : Computer
    {
        public int Battery { get; set; }
        public float ScreenSize { get; set; }
        public int Speakers { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"It has {Battery}% of battery left and it has {Speakers} speaker(s). " +
                $"Its screen size is {ScreenSize} inches";
        }
    }
    class Tablet : Laptop
    {
        public int Applications { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"{Applications} applications installed";
        }
    }
    class Phone : Tablet
    {
        public string Call()
        {
            return $"Some calling happens here";
        }
    }
    class CDrom
    {
        public string Name { get; set; }
        public float Size { get; set; }
        public string PlayAudio()
        {
            return $"Some audioplaying happens here";
        }
        public override string ToString()
        {
            return $"Disc-name is {Name} and it's size is {Size} gigabytes";
        }
    }
    class DVDrom : CDrom
    {
        public virtual string PlayMovie()
        {
            return $"Some DVD-movie playing happens here";
        }
    }
    class BluRay : DVDrom
    {
        public override string PlayMovie()
        {
            return $"Some BluRay-movie playing happens here";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // create a computer, make it count something and print it's info to the console
            Computer computer = new Computer() { ModelName = "Compaq", OS = "Windows 10", Memory = 8192f, Storage = 2000f, Weight = 8.3f };
            Console.WriteLine(computer.Compute());
            Console.WriteLine(computer.ToString());
            // create a phone, make it call and print its info to the console
            Phone telephone = new Phone();
            telephone.ModelName = "Huawei Mate 10 Pro";
            telephone.OS = "Android 10";
            telephone.Memory = 4096f;
            telephone.Storage = 128f;
            telephone.Weight = 0.352f;
            telephone.ScreenSize = 6f;
            telephone.Speakers = 2;
            telephone.Applications = 26;
            telephone.Battery = 78;
            Console.WriteLine(telephone.ToString());
            // create a bluray-disc and play a movie, also print info to console
            BluRay bluraymovie = new BluRay() { Name = "The call of Cthulhu", Size = 51f };
            Console.WriteLine(bluraymovie.PlayMovie());
            Console.WriteLine(bluraymovie.ToString());
        }
    }
}
