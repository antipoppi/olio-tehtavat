/* T4-Palindromi
 * Tehtävänanto:
 * 
 * Tee ohjelma, joka kysyy käyttäjältä lauseen eli merkkijonon. Sovelluksen tulee
 * ilmoittaa käyttäjälle oliko annettu merkkijono palindromi.
 * 
 */

using System;

namespace T4_Palindromi
{
    class Program
    {
        static void Main(string[] args)
        {
            //kysytään käyttäjältä lause ja tallennetaan se inputiin
            Console.WriteLine("Write a sentence/word to check if it's a palindrome: ");
            string input = Console.ReadLine();
            //otetaan inputista välilyönnit pois ja laitetaan niiden tilalle tyhjää
            string inputTrim = input.Replace(" ",String.Empty);
            //käännetään merkkijono toisinpäin tekemällä trimmatusta lauseesta merkkitaulukko nimeltä inputArray
            char[] inputArray = inputTrim.ToCharArray();
            Array.Reverse(inputArray);
            string reverseInput = new String(inputArray);
            //tarkistetaan onko trimmattu input sama käännetyn trimmatun merkkijonon kanssa
            //sekä kerrotaan käyttäjälle oliko merkkijono palindromi
            if (inputTrim == reverseInput)
            {
                Console.WriteLine(input + " is a palindrome!");
            }
            else
            {
                Console.WriteLine(input + " is not a palindrome.");
            }
            //loppu
        }
    }
}
