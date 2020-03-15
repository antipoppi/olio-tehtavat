/* T27-Kulkuneuvot
 * Tehtävänanto:
 * 
 * Tee Rengas-luokka (tai käytä edellisen tehtävän luokkaa), jolla on seuraavat ominaisuudet:
 * Valmistaja, Malli ja Rengaskoko
 * Tee tämän jälkeen Kulkuneuvo-luokka muutamilla kulkuneuvoon kuuluvilla ominaisuuksilla (nimi, malli)
 * ja käytä tekemääsi Rengas-luokkaa apuna renkaiden käsittelyyn. 
 * Tässä vaiheessa voit koostaa kulkuneuvon renkaat Rengas-olioina List-rakenteeseen. 
 * Tee pääohjelma, jossa luot muutamia kulkuneuvoja (esim. auto ja moottoripyörä) renkaineen. 
 * Tietoja ei tarvitse kysyä käyttäjältä, vaan voit alustaa niitä suoraan pääohjelman koodissa.
 */

using System;
using System.Collections.Generic;

namespace T27_Kulkuneuvot
{
    public class Rengas
    {
        public string Valmistaja { get; set; }
        public string Malli { get; set; }
        public string RengasKoko { get; set; }
        public override string ToString()
        {
            return $"{Valmistaja}, {Malli}, {RengasKoko}";
        }
    }
    public abstract class Kulkuneuvo
    {
        public string Tyyppi { get; set; }
        public string Nimi { get; set; }
        public string Malli { get; set; }
        public List<Rengas> Renkaat { get; set; }
        public int RenkaidenLkm
        {
            get
            {
                return Renkaat.Count;
            }
        }
        public override string ToString()
        {
            return $"{Nimi} {Malli} on {Tyyppi} jossa on {RenkaidenLkm} rengasta";
        }
        public string PalautaRenkaat()
        {
            try
            {
                string kaikkiRenkaat = "";
                foreach (Rengas item in Renkaat)
                {
                    kaikkiRenkaat += "\n - " + item.ToString();
                }
                return kaikkiRenkaat;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
    class Auto : Kulkuneuvo
    {
        public Auto()
        {
            Renkaat = new List<Rengas>()
                {new Rengas { Valmistaja = "Nokia", Malli = "Hakkapeliitta", RengasKoko = "205/45R16" },
                new Rengas { Valmistaja = "Nokia", Malli = "Hakkapeliitta", RengasKoko = "205/45R16" },
                new Rengas { Valmistaja = "Nokia", Malli = "Hakkapeliitta", RengasKoko = "205/45R16" },
                new Rengas { Valmistaja = "Nokia", Malli = "Hakkapeliitta", RengasKoko = "205/45R16" } };
        }
    }
    class Mopo : Kulkuneuvo
    {
        public Mopo()
        {
            Renkaat = new List<Rengas>()
                {new Rengas { Valmistaja = "Mitas", Malli = "Maxima", RengasKoko = "120/70R12" },
                new Rengas { Valmistaja = "Mitas", Malli = "Maxima", RengasKoko = "120/70R12" } };
        }
    }
    class Kolmipyora : Kulkuneuvo
    {
        public Kolmipyora()
        {
            Renkaat = new List<Rengas>()
                {new Rengas { Valmistaja = "Pinepeak", Malli = "Reino", RengasKoko = "60/35R8" },
                new Rengas { Valmistaja = "Pinepeak", Malli = "Reino", RengasKoko = "60/35R8" },
                new Rengas { Valmistaja = "Pinepeak", Malli = "Reino", RengasKoko = "60/35R8" } };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // luodaan auto, mopo ja kolmipyörä
            Auto auto = new Auto() { Tyyppi = "Auto", Nimi = "Seat", Malli = "Leon" };
            Mopo mopo = new Mopo() { Tyyppi = "Mopo", Nimi = "Tunturi", Malli = "SuperSport" };
            Kolmipyora kolmipyörä = new Kolmipyora() { Tyyppi = "Kolmipyörä", Nimi = "Hulda", Malli = "Hulina" };
            // tulostetaan kaikki kulkuneuvot konsoliin renkaineen
            Console.WriteLine(auto.ToString() + auto.PalautaRenkaat());
            Console.WriteLine(mopo.ToString() + mopo.PalautaRenkaat());
            Console.WriteLine(kolmipyörä.ToString() + kolmipyörä.PalautaRenkaat());
        }
    }
}
