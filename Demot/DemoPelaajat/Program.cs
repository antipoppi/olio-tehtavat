using System;
using System.IO;
using System.Collections.Generic;

namespace DemoPelaajat
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

    /* Jyp.csv sisältö
     * Jarkko;Immonen;hyökkääjä;26
     * Juha-Pekka;Hytönen;hyökkääjä;15
     * Ossi;Louhivaara;hyökkääjä;23
     * Juuso;Vainio;puolustaja;5
     * Eetu;Laurikainen;vaalimahti;41
     */

    class Program
    {
        static void Main(string[] args) // tää on kuin T28 HaePelaajat(string joukkue)
        {
            try
            {
                string erotin = ";"; // csv:ssä sanat on eroteltu toisistaan puolipisteellä
                Console.WriteLine("Luetaan pelaajatietoja tiedostosta");
                string filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Jyp.csv";
                // jos tekstitiedosto on samassa kansiossa kuin solutionin exe, valitaan current folder
                string[] lines = File.ReadAllLines(filename);
                List<Pelaaja> tiimi = new List<Pelaaja>();
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                    // splitataan tekstirivi neljäksi merkkijonoksi
                    string[] words = line.Split(erotin.ToCharArray());
                    // luodaan pelaaja-olio
                    Pelaaja pelaaja = new Pelaaja(words[0], words[1], words[2], words[3]);
                    // lisätään pelaaja tiimiin
                    tiimi.Add(pelaaja);
                    // näytetään pelaajan nimi
                    Console.WriteLine(pelaaja.ToString());
                }
                // lopuksi tiimin pelaajien määrä
                Console.WriteLine("Joukkueessa on {0} pelaajaa", tiimi.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
