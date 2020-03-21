/* T35-Laskutoimituksia
 * Tehtävänanto:
 * 
 * Toteuta ArrayCalcs-niminen luokka ja sen sisälle seuraavat staattiset-metodit: Sum, Average, Min ja Max.
 * Metodit ottavat parametriksi double[]-taulukon ja laskevat nimensä mukaisen laskutoimintuksen taulukon alkioille ja palauttavat tuloksen kutsuvalle ohjelmalle.
 * Toteuta pääohjelma ja esimerkiksi seuraavaa dataa sisältävä taulukko: double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
 * Kutsu pääohjelmasta ArrayCalcs-luokan staattisia laskutoimituksia tekeviä metodeja annetun taulukon arvoilla ja tulosta tulokset näyttölaitteelle.
 * 
 * Toteuta solutioniin uusi yksikkötestaukseen liittyvä projekti ja testaa ArrayCalcs-luokan kaikki metodit.
 * Kuinka ArrayCalcs-luokan metodit toimivat, jos välität parametrina tyhjän double[]-taulukon: double[] array = { };
 */

using System;
using System.Linq;

namespace T35_Laskutoimituksia
{
    public class ArrayCalcs
    {
        #region Methods
        public static double Sum(double[] array)
        {
            return array.Sum();
        }
        public static double Average(double[] array)
        {
            //return array.Average();
            return Math.Round(array.Average(), 1); // rounds decimal up to 1 decimal
        }
        public static double Min(double[] array)
        {
            return array.Min();
        }
        public static double Max(double[] array)
        {
            return array.Max();
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[] taulukko = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            Console.WriteLine(ArrayCalcs.Sum(taulukko));
            Console.WriteLine(ArrayCalcs.Average(taulukko));
            Console.WriteLine(ArrayCalcs.Min(taulukko));
            Console.WriteLine(ArrayCalcs.Max(taulukko));
        }
    }
}
