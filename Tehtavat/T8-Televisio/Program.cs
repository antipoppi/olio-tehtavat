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
        private readonly int maxChannel =  999;
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
        public bool TeletxtStatus { get; set; }
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
            TeletxtStatus = false;
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
                CurrentChannel = maxChannel;
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
            if (TeletxtStatus == false)
                TeletxtStatus = true;
            else
                TeletxtStatus = false;
            return TeletxtStatus;
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
            televisio.TogglePower();
            Console.WriteLine("Television virtastatus on {0}. (true on päällä, false pois päältä)", televisio.PowerStatus);
            Console.WriteLine("Tämänhetkinen äänenvoimakkuustaso on {0} ja kanava on {1}.", televisio.CurrentVolume, televisio.CurrentChannel);
            televisio.NextChannel();
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            televisio.VolumeDown();
            Console.WriteLine("Tämän hetkinen äänenvoimakkuus on {0}", televisio.CurrentVolume);
            televisio.SetChannel(999);
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            televisio.NextChannel(); // TÄÄ EI TOIMI
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            televisio.MuteVolume();
            Console.WriteLine("Tämän hetkinen äänenvoimakkuus on {0}", televisio.CurrentVolume);
            televisio.ToggleTeletext();
            Console.WriteLine("Tekstitv status on {0}. (true päällä, false pois päältä", televisio.TeletxtStatus);
            televisio.SetTeletextChannel(666);
            Console.WriteLine("Tekstitv sivu on {0}", televisio.CurrentTeletextChannel);
            televisio.ToggleTeletext();
            Console.WriteLine("Tekstitv status on {0}. (true päällä, false pois päältä", televisio.TeletxtStatus);
            televisio.SetChannel(0);
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            televisio.PreviousChannel();
            Console.WriteLine("Tämän hetkinen kanava on {0}", televisio.CurrentChannel);
            televisio.TogglePower();
            Console.WriteLine("Television virtastatus on {0}. (true on päällä, false pois päältä)", televisio.PowerStatus);
        }
    }
}
