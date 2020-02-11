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

namespace T20_Nisakas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
