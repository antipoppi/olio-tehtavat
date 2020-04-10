/* T39-Kalat
 * Tehtävänanto:
 * 
 * Toteuta sovellus MyFishApp, jossa voit hallita kalastukseen liittyviä tietoja.
 * Ohjelman pitää pystyä käsittelemään:
 *  - kalastajan perustiedot (nimi, puhelinnumero)
 *  - saadun kalan perustiedot (laji, pituus ja paino)
 *  - sekä kalapaikan perustiedot (nimi ja paikka) 
 *  
 * Suunnittele tarvittava luokkarakenne, ja piirrä siitä UML-kaavio. 
 * Toteuta pääohjelma MyFishApp, jossa käyttäjä voi lisätä kalastajia ja heidän saamiansa kaloja. 
 * Tee toiminto jolla voi tulostaa kalarekisterin sisältö eli kaikkien kalastajien saamat kaikki kalat.
 * 
 * Ja lopuksi toteuta kalarekisterille toiminto, että kalat voidaan tulostaa suuruusjärjestykessä (painavin ensin).
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace T39_Kalat
{
    public class Fisherman
    {
        public string Name { get; }
        public string Phone { get; }
        public Fisherman(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public override string ToString()
        {
            return $"- Fisherman: {Name}";
        }
    }
    public class Fish
    {
        public string Specie { get; }
        public double Length { get; }
        public double Weight { get; }
        public Fish(string specie, double length, double weight)
        {
            Specie = specie;
            Length = length;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"- Specie: {Specie} {Length} cm {Weight} kg";
        }
    }
    public class Location
    {
        public string Place { get; }
        public string LocationName { get; }
        public Location(string place, string location)
        {
            Place = place;
            LocationName = location;
        }
        public override string ToString()
        {
            return $"- Place: {Place} \n- Location: {LocationName}";
        }
    }
    public class FishingEvent
    {
        public Fisherman Fisher { get; }
        public Fish Fish { get; }
        public Location Location { get; }
        public FishingEvent(Fisherman fisherman, Fish fish, Location location)
        {
            Fisher = fisherman;
            Fish = fish;
            Location = location;
        }
    }
    public class FishRegister
    {
        public List<Fisherman> Fishers { get; }
        public List<FishingEvent> FishingEventList { get; set; }
        public FishRegister()
        {
            Fishers = new List<Fisherman>();
            FishingEventList = new List<FishingEvent>();
        }
    }

    class MyFishApp
    {
        static void Main(string[] args)
        {
            // create a new FishRegister and add some fishers to it
            FishRegister myFishRegister = new FishRegister();
            AddFisher(myFishRegister, new Fisherman("Tatu Alatalo", "0401234567"));
            AddFisher(myFishRegister, new Fisherman("Matti Meikäläinen", "0407654321"));
            // add some fishes to FishRegister
            AddFish(myFishRegister, "Tatu Alatalo", new Fish("Pike", 0.62, 1.52), new Location("Pyhäjoki", "Kärsämäki"));
            AddFish(myFishRegister, "Matti Meikäläinen", new Fish("Pike", 0.98, 3.15), new Location("Pyhäjärvi", "Pyhäjärvi"));
            AddFish(myFishRegister, "Tatu Alatalo", new Fish("Salmon", 0.51, 1.12), new Location("Kalajoki", "Ylivieska"));
            // print FishRegister
            PrintMyFishApp(myFishRegister);
            // sort fishes by weight and print the register
            PrintBiggestFishes(myFishRegister);
        }
        private static void AddFisher(FishRegister myFishRegister, Fisherman fisher)
        {
            myFishRegister.Fishers.Add(fisher);
            Console.WriteLine($"Fisher {fisher.Name} added into the Fishregister.\n");
        }
        private static void AddFish(FishRegister myFishRegister, string fisher, Fish fish, Location location)
        {
            Fisherman fisherMan = myFishRegister.Fishers.Find(x => x.Name == fisher);
            if (fisherMan != null)
                myFishRegister.FishingEventList.Add(new FishingEvent(fisherMan, fish, location));
            else
                Console.WriteLine("Fisher can't be found. Typo in the name?");
            Console.WriteLine($"{fisherMan.Name} got a new fish!");
            Console.WriteLine(fish.ToString());
            Console.WriteLine(location.ToString() + "\n");
        }
        private static void PrintMyFishApp(FishRegister myFishRegister)
        {
            Console.WriteLine("\n*** All the fishes sorted by fishermen: ***\n");
            for (int i = 0; i < myFishRegister.Fishers.Count; i++)
            {
                string fisherName = myFishRegister.Fishers[i].Name;
                var hold = myFishRegister.FishingEventList.FindAll(x => x.Fisher.Name == fisherName).ToArray();
                if (hold != null)
                {
                    foreach (var item in hold)
                    {
                        Console.WriteLine(item.Fish.ToString());
                        Console.WriteLine(item.Location.ToString());
                        Console.WriteLine(item.Fisher.ToString() + "\n");
                    }
                }
            }
        }
        private static void PrintBiggestFishes(FishRegister myFishRegister)
        {
            FishRegister holderRegister = new FishRegister();
            holderRegister = myFishRegister;
            var hold = holderRegister.FishingEventList.OrderByDescending(x => x.Fish.Weight).ToList(); // tää oli tehtävän vaikein juttu. Kätevää ja toimii
            if (hold != null)
                holderRegister.FishingEventList = hold;
            Console.WriteLine("\n*** All fishes sorted by weight in the Fishregister: ***\n");
            foreach (var item in holderRegister.FishingEventList)
            {
                Console.WriteLine(item.Fish.ToString());
                Console.WriteLine(item.Location.ToString());
                Console.WriteLine(item.Fisher.ToString() + "\n");
            }
        }
    }
}
