/* T8-Televisio
 * Tehtävänanto:
 * 
 * Tehtävänäsi on ohjelmoida television toiminta. Samoin kuin edellinen tehtävä:
 * mitä ominaisuuksia ja toimintoja tekisit Televisio-luokkaan?
 * Suunnittele ja piirrä Televisio-luokan ominaisuudet ja toiminnot UML-luokkakaaviona.
 * Toteuta Televisio-luokan ohjelmointi sekä pääohjelma, jolla luot olion Televisio-luokasta.
 * Säädä luomaasi Televsio-oliota erilaisilla arvoilla, jätä Console.WriteLine()-tulostuslauseet ohjelmaasi,
 * jotta televisio-olion käyttäminen jää näkyville.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T8_Televisio
{
    class TV
    {
        // field variables
        private readonly int maxChannel = 999;
        private readonly int minChannel = 0;
        private readonly int maxVolume = 100;
        private readonly int minVolume = 0;
        // properties
        public string Name { get; }
        public string Model { get; }
        public int ProductionYear { get; }
        public bool PowerStatus { get; set; }
        public int CurrentChannel { get; set; }
        public int CurrentVolume { get; set; }
        public bool TeletextStatus { get; set; }
        public int CurrentTeletextChannel { get; set; }
        // constructors
        public TV()
        {
            Name = "Samsung";
            Model = "UE55M5005";
            ProductionYear = DateTime.Now.Year;
            PowerStatus = false;
            CurrentChannel = 1;
            CurrentVolume = 50;
            TeletextStatus = false;
        }
        // methods
        public bool TogglePower()
        {
            if (PowerStatus == false)
                PowerStatus = true;
            else
                PowerStatus = false;
            return PowerStatus;
        }
        public int NextChannel()
        {
            if (CurrentChannel + 1 <= maxChannel)
            {
                CurrentChannel = CurrentChannel + 1;
                return CurrentChannel;
            }
            else
            {
                CurrentChannel = minChannel;
                return CurrentChannel;
            }
        }
        public int PreviousChannel()
        {
            if (CurrentChannel - 1 >= minChannel)
            {
                CurrentChannel = CurrentChannel - 1;
                return CurrentChannel;
            }
            else
            {
                CurrentChannel = maxChannel;
                return CurrentChannel;
            }
        }
        public int SetChannel(int channelNmb)
        {
            CurrentChannel = channelNmb;
            return CurrentChannel;
        }
        public int VolumeUp()
        {
            if (CurrentVolume + 5 <= maxVolume)
            {
                CurrentVolume = CurrentVolume + 5;
                return CurrentVolume;
            }
            else
            {
                CurrentVolume = maxVolume;
                return CurrentVolume;
            }
        }
        public int VolumeDown()
        {
            if (CurrentVolume - 5 >= minVolume)
            {
                CurrentVolume = CurrentVolume - 5;
                return CurrentVolume;
            }
            else
            {
                CurrentVolume = minVolume;
                return CurrentVolume;
            }
        }
        public int MuteVolume()
        {
            CurrentVolume = minVolume;
            return CurrentVolume;
        }
        public bool ToggleTeletext()
        {
            if (TeletextStatus == false)
                TeletextStatus = true;
            else
                TeletextStatus = false;
            return TeletextStatus;
        }
        public int SetTeletextChannel(int teltxtNmb)
        {
            CurrentTeletextChannel = teltxtNmb;
            return CurrentTeletextChannel;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TV televisio = new TV();
            // laitetaan televisio päälle (oletuksena pois päältä)
            televisio.TogglePower();
            Console.WriteLine("Television virtastatus on {0}. (true on päällä, false pois päältä)", televisio.PowerStatus);
            Console.WriteLine("Tämänhetkinen äänenvoimakkuustaso on {0} ja kanava on {1}.", televisio.CurrentVolume, televisio.CurrentChannel);
            // "käännetään" seuraavalle kanavalle
            televisio.NextChannel();
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            // lasketaan äänenvoimakkuutta yksi painallus
            televisio.VolumeDown();
            Console.WriteLine("Tämän hetkinen äänenvoimakkuus on {0}", televisio.CurrentVolume);
            // asetetaan kanava 999
            televisio.SetChannel(999);
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            // "käännetään" seuraavalle kanavalle
            televisio.NextChannel();
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            // mutetetaan äänenvoimakkuus
            televisio.MuteVolume();
            Console.WriteLine("Tämän hetkinen äänenvoimakkuus on {0}", televisio.CurrentVolume);
            // laitetaan teksti-tv päälle (oletuksena pois päältä)
            televisio.ToggleTeletext();
            Console.WriteLine("Tekstitv status on {0}. (true päällä, false pois päältä", televisio.TeletextStatus);
            // asetetaan teksti-tv kanavalle 666.
            televisio.SetTeletextChannel(666);
            Console.WriteLine("Tekstitv sivu on {0}", televisio.CurrentTeletextChannel);
            // suljetaan teksti-tv
            televisio.ToggleTeletext();
            Console.WriteLine("Tekstitv status on {0}. (true päällä, false pois päältä", televisio.TeletextStatus);
            // asetetaan kanavalle 0
            televisio.SetChannel(0);
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            // käännetään edelliselle kanavalle
            televisio.PreviousChannel();
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            // suljetaan televisio
            televisio.TogglePower();
            Console.WriteLine("Television virtastatus on {0}. (true on päällä, false pois päältä)", televisio.PowerStatus);
        }
    }
}
