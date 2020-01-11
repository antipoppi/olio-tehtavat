/* T3-Kulutus
 * Tehtävänanto:
 * 
 * Auton kulutus on 7½ litraa 100 kilometrin matkalla ja bensan hinta on 1,55 Euroa.
 * Tee metodi, jolla voi laskea tietyn ajomatkan bensakustannukset. 
 * Pääohjelmassa kysytään käyttäjältä ajettu matka, sen jälkeen pääohjelma kutsuu metodia, lähettäen
 * parametrina ajetun kilometrimäärän. Metodi palauttaa kuluvan bensan määrän sekä
 * bensaan menevän rahan määrän ja pääohjelma näyttää ne käyttäjälle.
 */

using System;

namespace T3_Kulutus
{
    class Program
    {
        static void Main(string[] args)
        {
            //muuttujat
            string tripLenghtString;
            double consumption = 0;
            double cost = 0;
            //kysytään käyttäjältä ajettu matka
            Console.Write("Give how many kilometers driven: ");
            tripLenghtString = Console.ReadLine();
            double.TryParse(tripLenghtString, out double tripLenght); //muutetaan matka-string doubleksi
            //kutsutaan metodia
            CountCost(tripLenght, out consumption, out cost);
            //tulostetaan käyttäjälle kuluva bensa- ja rahamäärä
            Console.WriteLine("Gasolin consumption for this trip is " + consumption + " liters and the cost of it is " + cost + " euros.");
        }
        public static void CountCost(double tripLength, out double consumption, out double cost)
        {
            //lasketaan matkan kulutus
            consumption = (7.5 * tripLength) / 100;
            //lasketaan matkan hinta
            cost = consumption * 1.55;
            //pyöristetään hinnan desimaalit lähimpään senttiin. 
            cost = Math.Round(cost, 2, MidpointRounding.AwayFromZero);
        }
    }
}
