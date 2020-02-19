/* T17-Radio
 * Tehtävänanto:
 * Tehtävässä tulee toteuttaa C#-ohjelma radion perustoimintojen testaamiseen.
 * Kannettavassa radiossa on vain kolme säädintä: päälle/pois-kytkin, äänen voimakkuuden säädin (arvot 0, 1, 2,..., 9)
 * ja kuunneltavan kanavan taajuusvalinta (2000.0 - 26000.0). Laadi luokka kannettavan radion toteutukseksi.
 * Äänen voimakkuutta ja kanavaa ei voi asettaa ennen kuin radio on kytketty päälle.
 * Käytä tekemääsi luokkaa pääohjelmasta käsin, eli testaile radion toimivuutta erilaisilla voimakkuuden ja taajuuden arvoilla.
 * Jätä asetus- ja tulostuslauseet näkyville pääohjelmaan, jotta radio-olion käyttö voidaan todentaa.
 *  */

using System;

namespace T17_Radio
{
    class Radio
    {
        // properties
        public bool PowerStatus { get; set; }
        // constructors
        public Radio()
        {
            PowerStatus = false;
        }
        // methods
        public string TogglePower()
        {
            if (PowerStatus == false)
            {
                PowerStatus = true;
                return $"Radio on nyt päällä";
            }
            else
            {
                PowerStatus = false;
                return $"Radio on pois päältä";
            }
        }
        public override string ToString()
        {
            return $"{TogglePower()}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Radio kannettavaRadio = new Radio();
            Console.WriteLine(kannettavaRadio.ToString());
        }
    }
}
