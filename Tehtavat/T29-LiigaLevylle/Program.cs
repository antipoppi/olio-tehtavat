/* T29-LiigaLevylle
 * Tehtävänanto:
 * 
 * Toteuta edelliseen tehtävään tiedostoon tallentaminen. 
 * Lue kurssin lisämateriaali: olioiden tallentaminen levylle.
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            HaePelaajat(joukkue);
        }
        internal void HaePelaajat(string joukkue)
        {
            if (joukkue == "jyp")
            {
                Pelaajat.Add(new Pelaaja("Markus", "Ruusu", "MV", "40"));
                Pelaajat.Add(new Pelaaja("Anttoni", "Honka", "P", "3"));
                Pelaajat.Add(new Pelaaja("Juuso", "Vainio", "P", "5"));
                Pelaajat.Add(new Pelaaja("Jani", "Tuppurainen", "LH", "12"));
                Pelaajat.Add(new Pelaaja("Juha-Pekka", "Hytönen", "KH", "15"));
                Pelaajat.Add(new Pelaaja("Samuli", "Ratinen", "LH", "17"));
            }
            else if (joukkue == "kalpa")
            {
                Pelaajat.Add(new Pelaaja("Eero", "Kilpeläinen", "MV", "37"));
                Pelaajat.Add(new Pelaaja("Otto", "Huttunen", "P", "2"));
                Pelaajat.Add(new Pelaaja("Mikael", "Seppälä", "P", "5"));
                Pelaajat.Add(new Pelaaja("Tuomas", "Vartiainen", "LH", "13"));
                Pelaajat.Add(new Pelaaja("Joni", "Ikonen", "KH", "16"));
                Pelaajat.Add(new Pelaaja("Tommi", "Jokinen", "LH", "42"));
            }
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
            return $"Joukkueesta {Nimi} on poistettu pelaaja {etunimi + " " + sukunimi} \n";
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
            return $"Joukkueeseen {Nimi} on lisätty pelaaja {etunimi + " " + sukunimi}\n";
        }
        public string TulostaPelaajat()
        {
            string pelaajat = "";
            foreach (Pelaaja item in Pelaajat)
            {
                pelaajat += item.ToString() + "\n";
            }
            return $"Joukkueessa {Nimi} on seuraavat pelaajat:\n{pelaajat}";
        }
        public string TallennaPelaajat()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                StreamWriter outputFile = new StreamWriter("joukkue.txt");
                string pelaajat = "";
                foreach (Pelaaja item in Pelaajat)
                {
                    pelaajat += item.ToString() + "\n";
                }
                outputFile.WriteLine($"Joukkueessa {Nimi} on seuraavat pelaajat:\n{pelaajat}");
                try
                {
                    outputFile.Close();
                }
                catch (EncoderFallbackException ex)
                {
                    return $"Tiedoston sulkeminen ei onnistu: {ex.Message}";
                }
                return $"Tiedosto tallennettu onnistuneesti:\n{path}\\joukkue.txt"+"\n";
            }
            catch (UnauthorizedAccessException ex)
            {
                return $"Tiedostoa ei voitu tallentaa: {ex.Message}";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Joukkue kalpa = new Joukkue("kalpa") { Nimi = "Kalpa", Kotikaupunki = "Kuopio" };
                Console.WriteLine(kalpa.TulostaPelaajat());
                Console.WriteLine(kalpa.PoistaPelaaja(kalpa.Pelaajat, "Mikael", "Seppälä", "P", "5"));
                Console.WriteLine(kalpa.TulostaPelaajat());
                Console.WriteLine(kalpa.LisääPelaaja(kalpa.Pelaajat, "Jesse", "Graham", "P", "64"));
                Console.WriteLine(kalpa.TulostaPelaajat());
                Console.WriteLine(kalpa.TallennaPelaajat()); // tallentaa joukkueen tekstitiedostoon
                Joukkue jyp = new Joukkue("jyp") { Nimi = "JYP", Kotikaupunki = "Jyväskylä" };
                Console.WriteLine(jyp.TulostaPelaajat());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Virhe: " + ex.Message);
            }
        }
    }
}
