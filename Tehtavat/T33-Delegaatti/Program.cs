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
        // delegate
        delegate void FormatText(string text);
        static void Main(string[] args)
        {
            try
            {
                // ask for a string input and read it
                Console.WriteLine("Syötä merkkijono: ");
                string inputText = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        // asks what user want to do with the input string and reads the selection(s)
                        Console.WriteLine("\nValitse haluamasi käsittely, voit antaa useamman käsittelyn kerralla yhtenä merkkijonona (esim '123'): ");
                        Console.WriteLine("- 1: isoiksi kirjaimiksi");
                        Console.WriteLine("- 2: pieniksi kirjaimiksi");
                        Console.WriteLine("- 3: otsikoksi");
                        Console.WriteLine("- 4: palindromiksi");
                        Console.WriteLine("- 0: Lopettaa ohjelman\n");
                        Console.Write("Valinta: ");
                        string inputNmbs = Console.ReadLine();
                        Console.WriteLine();
                        FormatText formatter = new FormatText(StartDelegate); // create a delegate instance
                        if (inputNmbs.Contains("1")) // sets delegate to include method Format1
                        {
                            formatter += Format1;
                        }
                        if (inputNmbs.Contains("2")) // sets delegate to include method Format2
                        {
                            formatter += Format2;
                        }
                        if (inputNmbs.Contains("3")) // sets delegate to include method Format3
                        {
                            formatter += Format3;
                        }
                        if (inputNmbs.Contains("4")) // sets delegate to include method Format4
                        {
                            formatter += Format4;
                        }
                        if (inputNmbs.Contains("0")) // ends program
                        {
                            Console.WriteLine("Ohjelma lopettiin onnistuneesti.");
                            break;
                        }
                        formatter(inputText);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine("Parametrissa ongelma: " + ex.Message);
                    }
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("Muisti loppu: " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Syötteessä ongelma: " + ex.Message);
            }
        }
        // methods
        static void StartDelegate(string input) { }
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
            Console.WriteLine("Teksti otsikkona: " + textHold);
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
