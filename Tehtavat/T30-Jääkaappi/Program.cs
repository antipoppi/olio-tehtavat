/* T30-Jääkaappi
 * Tehtävänanto:
 * 
 * Pohdi jääkaappia reaalimaailman käsitteenä ja erityisesti sitä mitä sieltä löytyy.
 * Tee pienimuotoinen toteutus, joka koostaa jääkaapin sisältöä muutamista eri asioista/olioista.
 * Jääkaappi on siis olio, jolla on kokoelma erilaisia elintarvikkeita.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace T30_Jääkaappi
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
    public class Fridge
    {
        // properties
        public List<Item> Content { get; set; }
        // constructor
        public Fridge()
        {
            Content = new List<Item>();
            GetItems();
        }
        // methods
        private void GetItems()
        {
            Content.Add(new Milk("Valio laktoositon maito", 2));
            Content.Add(new Bread("Fazerin Kaurapalat", 1));
            Content.Add(new Butter("Oivariini", 1));
            Content.Add(new Cheese("Valio edam", 1));
            Content.Add(new Cheese("Kerrosjogurtti", 4));
        }
        public string ShowContent()
        {
            string contentHold = "";
            foreach (Item item in Content)
            {
                contentHold += "- " + item.Name + " " + item.Amount + "kpl\n";
            }
            return $"Jääkaapin sisältö: \n" + contentHold; 
        }
        public string Consume(string itemName)
        {
            try
            {
                var foo = Content.FirstOrDefault(x => x.Name == itemName);
                if (foo != null)
                {
                    foo.Amount = foo.Amount - 1;
                    if (foo.Amount == 0)
                    {
                        string nameHold = foo.Name;
                        Content.Remove(foo);
                        return $"{nameHold} on nyt loppu!\n";
                    }
                    else
                        return $"Jääkaapista syötiin yksi kappale {foo.Name}. Niitä jäi jäljelle {foo.Amount}\n";
                }
                else
                    return $"Kirjoita kulutettavan tuotteen nimi oikein\n";
            }
            catch (ArgumentNullException ex)
            {
                return $"Jääkaappia ei olekkaan: {ex.Message}";
            }
                
        }
    }
    public class Milk : Item
    {
        public Milk(string nimi, int määrä)
        {
            Name = nimi;
            Amount = määrä;
        }
    }
    public class Bread : Item
    {
        public Bread(string nimi, int määrä)
        {
            Name = nimi;
            Amount = määrä;
        }
    }
    public class Butter : Item
    {
        public Butter(string nimi, int määrä)
        {
            Name = nimi;
            Amount = määrä;
        }
    }
    public class Cheese : Item
    {
        public Cheese(string nimi, int määrä)
        {
            Name = nimi;
            Amount = määrä;
        }
    }
    public class Yoghurt : Item
    {
        public Yoghurt(string nimi, int määrä)
        {
            Name = nimi;
            Amount = määrä;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fridge jääkaappi = new Fridge();
            Console.WriteLine(jääkaappi.ShowContent()); // tulostetaan jääkaapin sisältö konsoliin
            Console.WriteLine(jääkaappi.Consume("Kerrosjogurtti")); // syödään jääkaapista yksi kerrosjogurtti
            Console.WriteLine(jääkaappi.Consume("Oivariini")); // kulutetaan voi loppuun
            Console.WriteLine(jääkaappi.ShowContent());
            jääkaappi.Content.Add(new Butter("Oivariini", 1)); // ostetaan voita lisää
            Console.WriteLine(jääkaappi.ShowContent());
        }
    }
}
