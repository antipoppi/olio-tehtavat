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
        // properties
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public int SongsAmount
        {
            get
            {
                return Songs.Count;
            }
        }
        public string TotalLength { get; private set; }
        public List<Song> Songs { get; private set; }
        // constructor
        public CD()
        {
            Songs = new List<Song>();
        }
        public void CountTotalLenght()
        {
            double songTotalLengthSec = 0;
            foreach (var item in Songs)
            {
                double songMinutes = (int)item.Length;
                double minutesInSec = (int)songMinutes * 60;
                double songSeconds = (int)((item.Length - songMinutes) * 100);
                double total = minutesInSec + songSeconds;
                songTotalLengthSec += total;
            }
            int albumMin = (int)songTotalLengthSec / 60;
            int albumSec = (int)(songTotalLengthSec % 60);
            TotalLength = $"**{albumMin}min {albumSec}sec**";
        }
    }
    public class Song
    {
        public string SongName { get; set; }
        public double Length { get; set; }
 }

    class Program
    {
        static void Main(string[] args)
        {
            // luodaan CD ja biisi -oliot
            CD newCD = new CD() { ArtistName = "Natalia Lafourcade", AlbumName = "Hasta la Raíz" };
            Song song = new Song() { SongName= "Hasta la Raíz", Length = 3.41 };
            Song song2 = new Song() { SongName = "Mi Lugar Favorito", Length = 4.57 };
            Song song3 = new Song() { SongName = "Antes de Huir", Length = 3.52 };
            Song song4 = new Song() { SongName = "Ya No Te Puedo Querer", Length = 4.47 };
            Song song5 = new Song() { SongName = "Para Qué Sufrir", Length = 3.46 };
            Song song6 = new Song() { SongName = "Nunca es suficiente", Length = 3.57 };
            Song song7 = new Song() { SongName = "Palomas Blancas", Length = 4.47 };
            Song song8 = new Song() { SongName = "Te Quiero Ver", Length = 3.27 };
            // lisätään biisi-oliot CD-levyn listaan
            newCD.Songs.Add(song);
            newCD.Songs.Add(song2);
            newCD.Songs.Add(song3);
            newCD.Songs.Add(song4);
            newCD.Songs.Add(song5);
            newCD.Songs.Add(song6);
            newCD.Songs.Add(song7);
            newCD.Songs.Add(song8);
            // lasketaan levyn kokonaispituus
            newCD.CountTotalLenght();
            // tulostetaan levyn tiedot konsoliin
            PrintCDinfo(newCD);
        }
        public static void PrintCDinfo(CD uusiCD)
        {
            Console.WriteLine("LEVYN TIEDOT");
            Console.WriteLine($"- Artistin nimi: {uusiCD.AlbumName}");
            Console.WriteLine($"- Levyn nimi: {uusiCD.AlbumName}");
            Console.WriteLine($"- Levyn kokonaispituus: {uusiCD.TotalLength}");
            Console.WriteLine($"- {uusiCD.SongsAmount} kappaletta:");
            foreach (var item in uusiCD.Songs)
            {
                Console.WriteLine($"  - {item.SongName}, {item.Length}");
            }
            

        }
    }
}
