/* T25-Jono
 * Tehtävänanto:
 * 
 * Toteuta ratkaisu, joka simuloi kaupan kassan asiakasvirtaa. Toteuta luokka Kassajono joka käyttää jonoa eli Queue-tietorakennetta.
 * Kassajono -luokalla voisi olla esimerkiksi metodit: 
 * MeneJonoon(parametrit)
 * PoistuJonosta(parametrit)
 * ja ominaisuus: Pituus
 * 
 * Voit myös suunnitella ja toteuttaa oman rajapinnan luokalle. 
 * Huom: tässä yhteydessä rajapinta tarkoittaa luokasta ulospäin näkyviä julkisia ominaisuuksia ja metodeja.
 */
using System;
using System.Collections.Generic;

namespace T25_Jono
{
    class Asiakkaat
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
    class Kassajono
    {
        // properties
        public Queue<Asiakkaat> Jono { get; private set; }
        public int Pituus
        {
            get
            {
                return Jono.Count;
            }
        }
        // constructors
        public Kassajono()
        {
            Jono = new Queue<Asiakkaat>();
        }
        // methods
        public void MeneJonoon(Asiakkaat asiakas)
        {
            Jono.Enqueue(asiakas);
        }
        public string MaksaOstokset(Asiakkaat asiakas)
        {
            return $"Asiakas {asiakas.ToString()} maksaa ostoksensa";
        }
        public string PoistuJonosta()
        {
            return $"{Jono.Peek()} lähti jonosta. {Jono.Dequeue()}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Kassajono alepanJono = new Kassajono();
            string nimi = "";
            do
            {
                Console.WriteLine("Anna jonoon tulevan asiakkaan nimi (enter lopettaa):");
                nimi = Console.ReadLine();
                if (nimi != "")
                {
                    alepanJono.MeneJonoon(new Asiakkaat() { Name = nimi });
                }
                Console.WriteLine($"Alepan jonossa on nyt {alepanJono.Pituus} asiakasta");
                foreach (Asiakkaat item in alepanJono.Jono)
                {
                    Console.WriteLine(item.ToString());
                }
            } while (nimi != "");
            while (alepanJono.Pituus > 0)
            {
                Console.WriteLine("----- Palvellaan jonon ensimmäistä asiakasta -----");
                Console.WriteLine("Palvelen asiakasta:" + alepanJono.Jono.Peek());
                Console.WriteLine(alepanJono.MaksaOstokset(alepanJono.Jono.Peek()));
                alepanJono.PoistuJonosta();
                Console.WriteLine($"Alepan jonossa on nyt {alepanJono.Pituus} asiakasta");
            }
            Console.WriteLine("Jono on nyt tyhjä.");
        }
    }
}
