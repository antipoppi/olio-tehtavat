/* T23-NewCD
 * Tehtävänanto:
 * 
 * Aikaisemmissa demoissa tehtiin CD-luokka, joka sisälsi CD:lle yleisesti kuuluvia ominaisuuksia. 
 * CD:lla on oltava ainakin seuraavat tiedot: nimi, artisti, biisien määrä, kokonaispituus ja biisit.
 * CD:n sisällä olevat biisit ovat olioita Biisi-luokasta. Kustakin biisistä tallennetaan nimi ja pituus. 
 * CD:llä olevien  biisien määrää ei ole rajattu.
 * CD-luokan biisien määrä on vain luettavissa oleva ominaisuus, joka lasketaan CD:n biisi-olioiden lukumääränä.
 * CD-luokan kokonaispituus on vain luettavissa oleva ominaisuus, joka lasketaan CD:n biisi-olioiden pituuksien summana.
 * Ohjelmoi suunnittelemasi CD-luokka ja Biisi-luokka. Toteuta pääohjelmassa CD-olio. 
 * Tiedot CD:lle voit keksiä itse ja pääohjelma asettaa ne, niitä ei tarvitse kysyä käyttäjältä.
 * Tarkista huolellisella testauskella, että luokkasi varmasti osaa laskea biisien määrän ja kokonaispituuden oikein!
 * 
 */

using System;
using System.Collections.Generic;

namespace T23_NewCD
{
    public class CD
    {
        // field variables
        private double totalLength;
        // properties
        public string AlbumName { get; private set; }
        public string ArtistName { get; private set; }
        public int SongsAmount
        {
            get
            {
                return Songs.Count;
            }
        }
        public string TotalLength { get; private set; } // tää laskee kokonaispituuden
        public List<Song> Songs { get; private set; }
        // constructor
        public CD()
        {
            Songs = new List<Song>();
        }
        public double CountTotalLenght()
        {

        }
    }
    public class Song
    {
        public string SongName { get; set; }
        public double Length { get; set; }
        public double ConvertLengthToSec()
        {
            double minutes = (int)Length;
            double minutesInSec = (int)minutes * 60;
            double seconds = (Length - minutes) * 100;
            double total = minutesInSec + seconds;
            return total;
        }
 }

    class Program
    {
        static void Main(string[] args)
        {
            Song laulu = new Song() { Length = 2.52 };
            Console.WriteLine(laulu.ConvertLengthToSec());
        }
    }
}
