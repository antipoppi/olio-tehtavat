/*T38-Noppa
 * Tehtävänanto:
 * 
 * Toteuta Noppa-luokka siten, että noppaa voidaan heittää. 
 * Nopan tulee palauttaa satunnainen luku jokaisella heittokerralla. 
 * Toteuta pääohjelmassa nopan heittäminen. Kokeile ensin heittää noppaa kerran ja tulosta nopan luku. 
 * Toteuta tämän jälkeen ohjelma siten, että kysyt käyttäjältä heittojen määrän. 
 * Heitä noppaa ja tulosta heittojen lukujen keskiarvo.
 * Tulosta lopuksi kaikkien heitettyjen lukujen esiintymismäärät.
 */

using System;
using System.Collections.Generic;

namespace T38_Noppa
{
    public class Dice
    {
        private readonly int[] sides = new int[6] { 1, 2, 3, 4, 5, 6 };
        private int[] Sides { get { return sides; } }
        public int ThrowDice()
        {
            int side;
            Random r = new Random();
            try
            {
                side = (int)Sides.GetValue(r.Next(0, Sides.Length));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Noppaa ei voitu heittää: " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("Noppaa ei voitu heittää: " + ex.Message);
            }
            return side;
        }
    }
        class Program
    {
        #region Main
        static void Main(string[] args)
        {
            // create a dice and throw it once
            Dice noppa = new Dice();
            Console.WriteLine("Yhden noppaheiton tulos on " + noppa.ThrowDice());
            // ask user how many times to throw and start throwing
            Dictionary<double, double> results = null;
            Console.Write("Syötä montako kertaa haluat heittää noppaa: ");
            try
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out int amount) == true)
                    results = ThrowAmount(noppa, amount);
                else
                    Console.WriteLine("Syötetty ei voitu muuttaa");
            }
            catch (OutOfMemoryException ex)
            {
                throw new OutOfMemoryException("Syötettä ei voinut lukea: " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException("Syötettä ei voinut lukea: " + ex.Message);
            }
            // print results
            PrintResults(results);
        }
        #endregion

        #region Main Methods
        private static Dictionary<double,double> ThrowAmount(Dice dice, int amount)
        {
            Dictionary<double, double> results = new Dictionary<double, double>();
            try
            {
                results.Add(0, 0);
                results.Add(1, 0);
                results.Add(2, 0);
                results.Add(3, 0);
                results.Add(4, 0);
                results.Add(5, 0);
                results.Add(6, 0);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Tulosten tilastointi ei onnistu: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Tulosten tilastointi ei onnistu: " + ex.Message);
            }
            double divider = 0;
            for (int i = 0; i < amount; i++)
            {
                divider++;
                double result = dice.ThrowDice();
                results[0] += result;
                results[result]++;
            }
            results[0] = results[0] / amount;
            return results;
        }
        private static void PrintResults(Dictionary<double,double> results)
        {
            try
            {
                Console.WriteLine("- Heittojen keskiarvo on " + results[0].ToString("0.##"));
            }
            catch (FormatException ex)
            {
                throw new FormatException("Keskiarvon tulostaminen epäonnistui: " + ex.Message);
            }
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine($"- {i} määrä heitoista on {results[i]}");
            }
        }
        #endregion
    }
}
