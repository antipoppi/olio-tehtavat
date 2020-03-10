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
        private readonly int MaxRenkaidenLkm = 5;
        public string Merkki { get; set; }
        public string Malli { get; set; }
        public List<Rengas> Renkaat { get; private set; }
        public int RenkaidenLkm
        {
            get
            {
                return Renkaat.Count;
            }
        }
        public Auto()
        {
            Renkaat = new List<Rengas>(); // Auto olio sisältää nyt tyhjän listan
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // luodaan auto1
            Console.WriteLine("Testataan autoa ja sen renkaita");
            Auto auto1 = new Auto() { Merkki = "Skoda", Malli = "Octavia" };
            // ostetaan neljä rengasta ja lisätään ne auto1-olioon
            for (int i = 0; i < 4; i++)
            {
                Rengas skodaRengas = new Rengas() { Valmistaja = "Nokia", Malli = "Hakkapeliitta", RengasKoko = "205/45R16" };
                auto1.Renkaat.Add(skodaRengas);
            }
            // näytetään auto1 renkaat
            Console.WriteLine($"Arskan autossa {auto1.Merkki} {auto1.Malli} on seuraavat renkaat");
            foreach (var item in auto1.Renkaat)
            {
                Console.WriteLine($" - {item.Valmistaja} {item.Malli} {item.RengasKoko}");
            }
            // luodaan auto2 ja ostetaan lisätään siihen neljä rengasta
            Auto auto2 = new Auto() { Merkki = "Fiat", Malli = "Punto" };
            for (int i = 0; i < 4; i++)
            {
                Rengas fiatRengas = new Rengas() { Valmistaja = "Hankook", Malli = "HongKong", RengasKoko = "180/40R15" };
                auto2.Renkaat.Add(fiatRengas);
            }
            // lisäksi auto2 kuuluu yksi vararengas
            Rengas fiatVaraRengas = new Rengas() { Valmistaja = "Hankook", Malli = "SafetyFirst -BackUp tire", RengasKoko = "175/35R15" };
            auto2.Renkaat.Add(fiatVaraRengas);
            // näytetään auto2 renkaat
            Console.WriteLine($"Autossa {auto2.Merkki} {auto2.Malli} on seuraavat renkaat");
            foreach (var item in auto2.Renkaat)
            {
                Console.WriteLine($" - {item.Valmistaja} {item.Malli} {item.RengasKoko}");
            }
        }
    }
}
