/* T33-Delegaatti
 * Tehtävänanto:
 * 
 * Tee delegaateilla ohjelma, jolla käyttäjä syöttää merkkijonon. 
 * Sen jälkeen käyttäjä voi valita yhden tai useamman toiminnon jota merkkijonolle tehdään.
 * Merkkijonolle pitää pystyä tekemään seuraavat toiminnot:
 * 
 * muuttaa merkkijonon kaikki kirjaimet isoiksi kirjaimiksi
 * muuttaa merkkijonon kaikki kirjaimet pieniksi kirjaimiksi
 * muuttaa merkkijonon Otsikko-tyyllin, eli ensimmäinen merkki isolla ja loput pienellä
 * kääntää merkkijonon toistepäin eli sanasta Teppo tulee oppeT.
 * 
 * Eli toteuta kutakin muunnosta varten oma metodi (kaikilla metodeilla täytyy olla sama signature). 
 * Luo delegaatista instanssi ja kiinnitä siihen tarvittavat metodit. Voilá.
 */


using System;

namespace T33_Delegaatti
{
    class Program
    {
        delegate void FormatText(string text);
        static void Main(string[] args)
        {
            Console.WriteLine("Syötä merkkijono: ");
            string inputText = Console.ReadLine();
            Console.WriteLine("Syötä ne numerot mitkä haluat syöttämälläsi merkkijonolle tehdä (esim. 124: ");
            Console.WriteLine("- 1.muuttaa merkkijonon kaikki kirjaimet isoiksi kirjaimiksi");
            Console.WriteLine("- 2.muuttaa merkkijonon kaikki kirjaimet pieniksi kirjaimiksi");
            Console.WriteLine("- 3.muuttaa merkkijonon Otsikko-tyyllin, eli ensimmäinen merkki isolla ja loput pienellä");
            Console.WriteLine("- 4.kääntää merkkijonon toistepäin eli sanasta Teppo tulee oppeT");
            string inputNmbs = Console.ReadLine();
            FormatText formatter = new FormatText(Start);
            if (inputNmbs.Contains("1"))
            {
                formatter += Format1;
            }
            if (inputNmbs.Contains("2"))
            {
                formatter += Format2;
            }
            if (inputNmbs.Contains("3"))
            {
                formatter += Format3;
            }
            if (inputNmbs.Contains("4"))
            {
                formatter += Format4;
            }
            formatter(inputText);   
        }
        static void Start(string input) { }
        static void Format1(string input)
        {
            string textHold = input.ToUpper();
            Console.WriteLine("Teksti isolla: " + textHold);
        }
        static void Format2(string input)
        {
            string textHold = input.ToLower();
            Console.WriteLine("Teksti pienellä: " + textHold);
        }
        static void Format3(string input)
        {
            string textHold = (char.ToUpper(input[0]) + input.Substring(1));
            Console.WriteLine("Teksti pienellä: " + textHold);
        }
        static void Format4(string inputText)
        {
            char[] charArr = inputText.ToCharArray();
            Array.Reverse(charArr);
            string revText = new string(charArr);
            Console.WriteLine("Teksti toisinpäin: " + revText);
        }
    }
}
