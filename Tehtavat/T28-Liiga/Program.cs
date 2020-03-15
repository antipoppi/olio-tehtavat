/* T28-Liiga
 * Tehtävänanto:
 * 
 * Toteuta ohjelma, jolla voidaan lisätä, poistaa ja listata Liiga-joukkueen (esim JYPin tai Kalpan) pelaajia.
 * Luo Pelaaja-luokka, jolla on ominaisuudet Etunimi, Sukunimi, Pelipaikka ja Numero.
 * Luo myös Joukkue-luokka. Luokalla on ominaisuudet Nimi, Kotikaupunki ja Pelaajat.
 * Ominaisuus Pelaajat on siis lista Pelaaja-olioita. 
 * Tee Joukkue-luokalle sisäinen metodi HaePelaajat(string joukkue), jota konstruktori kutsuu. 
 * HaePelaajat metodi luo Pelaajat-listaan oikeat pelaajat.
 */

using System;
using System.Collections.Generic;

namespace T28_Liiga
{
    class Pelaaja
    {
        public string EtuNimi { get; set; }
        public string SukuNimi { get; set; }
        public string PeliPaikka { get; set; }
        public string Numero { get; set; }
        public Pelaaja() { }
        public Pelaaja(string etunimi, string sukunimi, string pelipaikka, string numero)
        {
            EtuNimi = etunimi;
            SukuNimi = sukunimi;
            PeliPaikka = pelipaikka;
            Numero = numero;
        }
        public override string ToString()
        {
            return EtuNimi + " " + SukuNimi + " " + PeliPaikka + " #" + Numero;
        }
    }
    class Joukkue
    {
        public string Nimi { get; set; }
        public string Kotikaupunki { get; set; }
        public string StringPelaajat { get; private set; }
        public List<Pelaaja> Pelaajat { get; private set; }
        public Joukkue() { }
        public Joukkue(string joukkue)
        {
            Pelaajat = new List<Pelaaja>();
            StringPelaajat = HaePelaajat(joukkue);
        }
        internal string HaePelaajat(string joukkue)
        {
            if (joukkue == "jyp")
            {
                string pelaajat = "";
                Pelaajat.Add(new Pelaaja { EtuNimi = "Markus", SukuNimi = "Ruusu", PeliPaikka = "MV", Numero = "40" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Anttoni", SukuNimi = "Honka", PeliPaikka = "P", Numero = "3" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Juuso", SukuNimi = "Vainio", PeliPaikka = "P", Numero = "5" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Jani", SukuNimi = "Tuppurainen", PeliPaikka = "LH", Numero = "12" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Juha-Pekka", SukuNimi = "Hytönen", PeliPaikka = "KH", Numero = "15" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Samuli", SukuNimi = "Ratinen", PeliPaikka = "LH", Numero = "17" });
                foreach (Pelaaja item in Pelaajat)
                {
                    pelaajat += item.ToString() + "\n";
                }
                return pelaajat;
            }
            else if (joukkue == "kalpa")
            {
                string pelaajat = "";
                Pelaajat.Add(new Pelaaja("Eero", "Kilpeläinen", "MV", "37" ));
                Pelaajat.Add(new Pelaaja { EtuNimi = "Otto", SukuNimi = "Huttunen", PeliPaikka = "P", Numero = "2" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Mikael", SukuNimi = "Seppälä", PeliPaikka = "P", Numero = "5" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Tuomas", SukuNimi = "Vartiainen", PeliPaikka = "LH", Numero = "13" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Joni", SukuNimi = "Ikonen", PeliPaikka = "KH", Numero = "16" });
                Pelaajat.Add(new Pelaaja { EtuNimi = "Tommi", SukuNimi = "Jokinen", PeliPaikka = "LH", Numero = "42" });
                foreach (Pelaaja item in Pelaajat)
                {
                    pelaajat += item.ToString() + "\n";
                }
                return pelaajat;
            }
            else
                return $"Väärä joukkueen nimi!";
        }
        public string PoistaPelaaja(List<Pelaaja> Pelaajat, string etunimi, string sukunimi, string pelipaikka, string numero)
        {
            try
            {
                Pelaajat.RemoveAll(x => x.EtuNimi == etunimi && x.SukuNimi == sukunimi && x.PeliPaikka == pelipaikka && x.Numero == numero);
            }
            catch (ArgumentNullException e)
            {
                return $"Pelaajan poistaminen joukkueesta {Nimi} ei onnistunut: " + e.Message;
            }
            return $"Joukkueesta {Nimi} on poistettu pelaaja {etunimi + " " +sukunimi}";
        }
        public string LisääPelaaja(List<Pelaaja> Pelaajat, string etunimi, string sukunimi, string pelipaikka, string numero)
        {
            try
            {
                Pelaajat.Add(new Pelaaja(etunimi, sukunimi, pelipaikka, numero));
            }
            catch (ArgumentNullException e)
            {
                return $"Pelaajan poistaminen joukkueesta {Nimi} ei onnistunut: " + e.Message;
            }
            return $"Joukkueeseen {Nimi} on lisätty pelaaja {etunimi + " " + sukunimi}" + "\n";
        }
        public string TulostaPelaajat()
        {
            return $"Joukkueessa {Nimi} on seuraavat pelaajat: \n" + StringPelaajat;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Joukkue kalpa = new Joukkue("kalpa") { Nimi = "Kalpa", Kotikaupunki = "Kuopio" };
            Console.WriteLine(kalpa.TulostaPelaajat());
            Console.WriteLine(kalpa.PoistaPelaaja(kalpa.Pelaajat, "Mikael", "Seppälä", "P", "5"));
            Console.WriteLine(kalpa.TulostaPelaajat());
            Console.WriteLine(kalpa.LisääPelaaja(kalpa.Pelaajat, "Jesse", "Graham", "P", "64"));
            Console.WriteLine(kalpa.TulostaPelaajat());
            Joukkue jyp = new Joukkue("jyp") { Nimi = "JYP", Kotikaupunki = "Jyväskylä" };
            Console.WriteLine(jyp.TulostaPelaajat());
        }
    }
}
