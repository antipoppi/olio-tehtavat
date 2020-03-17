/* T31-MiniASIO
 * Tehtävänanto:
 * 
 * Toteuteta konsolipohjainen MiniASIO-ohjelma, jolla voidaan lisätä, poistaa ja hakea opiskelijoiden tietoja. 
 * Luo Opiskelija-luokka, jolla on ominaisuudet Etunimi, Sukunimi, AsioID ja Ryhmä.
 * AsioID on aina uniikki, yksilöllinen. Se muodostetaan ottamalla etunimen ja sukunimen ensimmäinen kirjain, sekä juokseva numero alkaan 001:sta.
 * Lisää rekisteriin aluksi viiden testi-oppilaan tiedot tässä järjestyksessä: Hanna Husso, Kirsi Kernell, Masa Niemi, Teppo Testaaja, Allan Aalto.
 * 
 * Lisää sen jälkeen toiminnallisuus, jolla kysytään käyttäjältä lisättävän opiskelijan tiedot.
 * Opiskelija-olio lisätään listaan, jos samalla AsioID:lle olevaa opiskelijaa ei ole vielä listassa.
 * Joten toteuta tarkistus, ettei annettua AsioID:tä ole jo rekisterissä.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace T31_MiniASIO
{
    public class Opiskelija : IDisposable
    {
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string AsioID { get; set; }
        public string Ryhmä { get; set; }
        public Opiskelija() { }
        public Opiskelija(string etunimi, string sukunimi, string ryhmä, string asioID)
        {
            Etunimi = etunimi;
            Sukunimi = sukunimi;
            Ryhmä = ryhmä;
            AsioID = asioID;
        }
        public void Dispose() // tämä koska IDisposable-rajapinta vaatii sitä. Tällä poistetaan turha olio.
        {

        }
        public override string ToString()
        {
            return $"{Etunimi} {Sukunimi}, AsioID: {AsioID}, Ryhmä: {Ryhmä}";
        }
    }
    public class ASIO
    {
        private int AsioINT { get; set; }
        public string AsioID { get; set; }
        public List<Opiskelija> Rekisteri { get; private set; }
        public ASIO()
        {
            Rekisteri = new List<Opiskelija>();
            Rekisteri.Add(new Opiskelija("Hanna", "Husso", "TTV17S", AsioID = LuoAsioID("Hanna", "Husso")));
            Rekisteri.Add(new Opiskelija("Kirsi", "Kernell", "TTV18S", AsioID = LuoAsioID("Kirsi", "Kernell")));
            Rekisteri.Add(new Opiskelija("Masa", "Niemi", "TTV19S", AsioID = LuoAsioID("Masa", "Niemi")));
            Rekisteri.Add(new Opiskelija("Teppo", "Testaaja", "TTV17SM", AsioID = LuoAsioID("Teppo", "Testaaja")));
            Rekisteri.Add(new Opiskelija("Allan", "Aalto", "TTV18SMM", AsioID = LuoAsioID("Allan", "Aalto")));
        }
        public string LuoAsioID(string etunimi, string sukunimi)
        {
            try
            {
                AsioINT++;
                AsioID = etunimi.First().ToString() + sukunimi.First().ToString() + AsioINT.ToString("000");
                return AsioID;
            }
            catch (ArgumentNullException ex)
            {
                return "Nimisyöte on tyhjä: " + ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                return "Nimen kirjaimen valinta epäonnistui: " + ex.Message;
            }
            catch (FormatException ex)
            {
                return "ASIOnumeron muotoilu epäonnistui: " + ex.Message;
            }
        }
        public string TulostaKaikki()
        {
            string säilytys = "";
            foreach (Opiskelija item in Rekisteri)
            {
                säilytys += item.ToString() + "\n";
            }
            return säilytys;
        }
        public string EtsiOpiskelija(string etunimi, string sukunimi, string ryhmä)
        {
            try
            {
                var foo = Rekisteri.FindAll(x => x.Etunimi == etunimi && x.Sukunimi == sukunimi && x.Ryhmä == ryhmä);
                if (foo != null)
                {
                    string säilytys = "";
                    foreach (Opiskelija item in foo)
                    {
                        säilytys += item.ToString() + "\n";
                    }
                    return säilytys;
                }
                else
                    return "Opiskelijaa ei löydy";
            }
            catch (ArgumentNullException ex)
            {
                return "Tietosyöte on tyhjä: " + ex.Message;
            }
        }
        public string LisääOpiskelija(string etunimi, string sukunimi, string ryhmä)
        {
            Opiskelija hold = new Opiskelija(etunimi, sukunimi, ryhmä, AsioID = LuoAsioID(etunimi, sukunimi));
            try
            {
                var oof = Rekisteri.Find(x => x.AsioID == hold.AsioID);
                if (oof == null)
                {
                    AsioINT--; // vähennetään juoksevasta luvusta äsken lisätty yksi kerta jotta se pysyy mukana
                    Rekisteri.Add(new Opiskelija(etunimi, sukunimi, ryhmä, AsioID = LuoAsioID(etunimi, sukunimi)));
                    return $"Opiskelija {etunimi} {sukunimi} lisättiin rekisteriin onnistuneesti.";
                }
                else
                    return $"Opiskelijaa {etunimi} {sukunimi} ei voitu lisätä.";
            }
            catch (ArgumentNullException ex)
            {
                return "AsioID:n etsintä epäonnistui: " + ex.Message;
            }
            finally
            {
                hold.Dispose();
            }
        }
        public string PoistaOpiskelija(string asioID)
        {
            try
            {
                var opiskelija = Rekisteri.First(x => x.AsioID == asioID);
                if (opiskelija != null)
                {
                    Rekisteri.Remove(opiskelija);
                }
                return $"Opiskelija {opiskelija.ToString()} poistettiin rekisteristä\n";
            }
            catch (ArgumentNullException ex)
            {
                return "ASIOsyöte on tyhjä: " + ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                return "Operaatiota ei voitu suorittaa: " + ex.Message;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ASIO miniASIO = new ASIO();
            Console.WriteLine(miniASIO.TulostaKaikki());
            // poistetaan Allan Aalto 
            Console.WriteLine(miniASIO.PoistaOpiskelija("AA005"));
            // tulostetaan kaikki
            Console.WriteLine(miniASIO.TulostaKaikki());
            // lisätään olli opiskelija
            Console.WriteLine(miniASIO.LisääOpiskelija("Olli", "Opiskelija", "TTV19SMM"));
            // tulostetaan kaikki
            Console.WriteLine(miniASIO.TulostaKaikki());
            // koska voi olla saman niminen opiskelija samassa ryhmässä, uuden Olli Opiskelijan lisäys pitäisi onnistua
            Console.WriteLine(miniASIO.LisääOpiskelija("Olli", "Opiskelija", "TTV19SMM"));
            Console.WriteLine(miniASIO.TulostaKaikki());
            // samassa ryhmässä olevat samannimiset opiskelijatkin voidaan etsiä
            Console.WriteLine(miniASIO.EtsiOpiskelija("Olli", "Opiskelija", "TTV19SMM"));

        }
    }
}
