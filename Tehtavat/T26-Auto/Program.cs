/* T26-Auto
 * Tehtävänanto:
 * 
 * Toteuta alla olevan määrittelyn mukaisesti kaksi luokkaa Auto- ja Rengas. 
 * Tee luokille tarvittavat ominaisuudet ja metodit. Tee pääohjelma, jossa luot kaksi-kolme autoa, 
 * ja varustat ne erilaisilla renkailla. Autojen ja rengastietoja ei tarvitse kysyä käyttäjältä, 
 * vaan voit alustaa ne suoraan pääohjelman koodissa.
 * 
 * Auto
 * +Merkki:string
 * +Malli:string
 * +RenkaidenLkm:int {readonly}
 * +MaxRenkaidenLkm:int
 * +Renkaat:List {readonly}
 * 
 * Rengas
 * +Valmistaja:string
 * +Malli:string
 * +RengasKoko:string (esim: "205/45R16")
 */

using System;
using System.Collections.Generic;

namespace T26_Auto
{
    class Rengas
    {
        public string Valmistaja { get; set; }
        public string Malli { get; set; }
        public string RengasKoko { get; set; }
    }
    class Auto
    {
        public string Merkki { get; set; }
        public string Malli { get; set; }
        public List<Rengas> Renkaat { get; set; }
        public Auto()
        {
            Renkaat = new List<Rengas>(); // Auto olio sisältää nyt tyhjän listan
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testataan autoa ja sen renkaita");
            Auto auto = new Auto() { Merkki = "Skoda", Malli = "Octavia" };
            // ostetaan neljä rengasta ja lisätään ne auto-olioon
            for (int i = 0; i < 4; i++)
            {
                Rengas rengas = new Rengas() { Valmistaja = "Nokia", Malli = "Hakkapeliitta", RengasKoko = "205/45R16" };
                auto.Renkaat.Add(rengas);
            }
            // näytetään auton renkaat
            Console.WriteLine($"Arskan autossa {auto.Merkki} {auto.Malli} on seuraavat renkaat");
            foreach (var item in auto.Renkaat)
            {
                Console.WriteLine($" - {item.Valmistaja} {item.Malli} {item.RengasKoko}");
            }
        }
    }
}
