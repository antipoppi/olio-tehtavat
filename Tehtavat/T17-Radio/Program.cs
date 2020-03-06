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
        public int Volume { get; set; }
        public double ChannelFreq { get; set; }
    }
    class PortableRadio : Radio
    {
        // properties

        // constructors
        public PortableRadio()
        {
            PowerStatus = false;
        }
        // methods
        public void TogglePower()
        {
            if (PowerStatus == false)
            {
                PowerStatus = true;
            }
            else
            {
                PowerStatus = false;
                Volume = 0;
                ChannelFreq = 0;
            }
        }
        public void SetVolume(int vol)
        {
            if (vol >= 0 && vol <= 9 && PowerStatus == true)
                Volume = vol;

            else if (vol < 0 && PowerStatus == true)
                Volume = 0;

            else if (vol > 9 && PowerStatus == true)
                Volume = 9;
        }
        public void SetChannel(double chan)
        {
            if (chan >= 2000 && chan <= 26000 && PowerStatus == true)
                ChannelFreq = chan;

            else if (chan < 2000 && PowerStatus == true)
                ChannelFreq = 2000;

            else if (chan > 26000 && PowerStatus == true)
                ChannelFreq = 26000;
        }
        public string PrintPower()
        {
            if (PowerStatus == false)
                return $"Radio on pois päältä";
            else
                return $"Radio on päällä";
        }
        public override string ToString()
        {
            return $"{PrintPower()}. Äänenvoimakkuus on {Volume}. Kanavataajuus on {ChannelFreq}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // luodaan radio
            PortableRadio kannettavaRadio = new PortableRadio();
            // tulostetaan tiedot konsoliin
            Console.WriteLine(kannettavaRadio.ToString());
            // yritetään muuttaa äänenvoimakkuus arvoon 5 ja säätää kanava taajuudelle 22000
            kannettavaRadio.SetVolume(5);
            kannettavaRadio.SetChannel(22000);
            // tulostuksessa pitäisi lukea äänenvoimakkuuden sekä kanavataajuuden olevan arvossa nolla
            Console.WriteLine(kannettavaRadio.ToString());
            // laitetaan radio päälle
            kannettavaRadio.TogglePower();
            // tulostetaan tiedot konsoliin
            Console.WriteLine(kannettavaRadio.ToString());
            // muutetaan äänenvoimakkuus arvoon 5 ja säädetään kanava taajuudelle 22000
            kannettavaRadio.SetVolume(5);
            kannettavaRadio.SetChannel(22000);
            // tulostuksessa pitäisi lukea äänenvoimakkuuden olevan arvossa 5 ja kanavataajuus olevan 22000
            Console.WriteLine(kannettavaRadio.ToString());
            // muutetaan äänenvoimakkuus arvoon -5 ja säädetään kanava taajuudelle 30000
            kannettavaRadio.SetVolume(-5);
            kannettavaRadio.SetChannel(30000);
            // tulostuksessa pitäisi lukea äänenvoimakkuuden olevan arvossa 0 ja kanavataajuus olevan 26000
            Console.WriteLine(kannettavaRadio.ToString());
            // suljetaan radio ja tulostetaan tiedot konsoliin (äänenvoimakkuus 0 ja kanavataajuus 0)
            kannettavaRadio.TogglePower();
            Console.WriteLine(kannettavaRadio.ToString());
        }
    }
}
