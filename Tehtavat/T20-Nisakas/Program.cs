/* T20-Nisäkäs
 * Tehtävänanto:
 * 
 * Tehtävässä tulee toteuttaa muutamia luokkia, joiden avulla testataan abstraktien metodien toimivuutta.
 *Luo abstrakti luokka Nisakas, jolla on Ika-ominaisuus sekä Liiku-metodi, jonka toteutus on jätetty toteuttamatta (abstrakti metodi).
 * Peri Nisakas-luokasta Ihminen-luokka, jolla on ominaisuuksina ihmiseen yleisesti liittyviä ominaisuuksia (paino, pituus, nimi). 
 * Lisää Ihminen-luokkaan metodit: Liiku ja Kasva, joista ensimmäinen tulostaa ruutuun "liikun" ja jälkimmäinen lisää ihmisen ikää yhdellä vuodella. 
 * Huomioi, että Liiku-metodi ja Ikä-ominaisuus on Nisakas-luokassa
 * Peri Ihminen-luokasta Vauva- ja Aikuinen-luokat. Ylikirjoita Vauva-luokassa yliluokan Liiku-metodi tulostamaan "konttaa". 
 * Ylikirjoita Aikuinen-luokassa myös sama metodi ja laita se tulostamaan "kävelee". 
 * Lisää aikuiselle ominaisuus auto (String). Lisää vauvalle ominaisuus vaippa (String).
 * Toteuta pääohjelmassa muutamia ihmisiä, aikuisia ja vauvoja. Tulostele olioiden tietoja konsolille.
 * 
 */
using System;
using System.Collections.Generic;

namespace T20_Nisakas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Testataan abstrakteja luokkia:");
            // luodaan olio-instanssi ihminen-luokasta
            Ihminen ihminen = new Ihminen();
            ihminen.Ika = 32;
            ihminen.Nimi = "Tatu";
            ihminen.Paino = 72;
            ihminen.Pituus = 172;
            Console.WriteLine(ihminen.Liiku());
            Console.WriteLine(ihminen.ToString());
            // aikuinen
            Aikuinen aikamies = new Aikuinen() { Nimi = "Arska", Ika = 30, Paino = 92, Pituus = 192, Auto = "Audi" };
            Console.WriteLine(aikamies.ToString());
            // Console.WriteLine(aikamies.Liiku());
            // vauva
            Vauva pikkuvauva = new Vauva() { Nimi = "Pirpana", Ika = 0, Paino = 5.2, Pituus = 68, Vaippa = "Pampers" };
            // Console.WriteLine(pikkuvauva.ToString());
            // Console.WriteLine(pikkuvauva.Liiku());
            // kaikki oliot yhteen ja samaan listaan
            List<Ihminen> poppoo = new List<Ihminen>();
            poppoo.Add(ihminen);
            poppoo.Add(aikamies);
            poppoo.Add(pikkuvauva);
            // pistetään poppoo liikkeelle
            foreach (var item in poppoo)
            {
                Console.WriteLine($"Olen {item.Nimi} ja {item.Liiku()}");
                // tarvittaessa voidaan selvittää olion tyyppi
                if (item is Aikuinen)
                {
                    // kastataan (cast) eli muunnetaan item tyypiksi aikuinen
                    Aikuinen apu = (Aikuinen)item;
                    Console.WriteLine($"ja välillä ajan autollani {apu.Auto}");
                }
                else if (item is Vauva)
                {
                    Vauva apu = (Vauva)item;
                    Console.WriteLine($"ja minulla on vaippana {apu.Vaippa}");
                }
            }
        }
    }
}
