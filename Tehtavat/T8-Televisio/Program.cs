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
        // properties
        public string Name { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public bool PowerStatus { get; set; }
        public int SelectedChannel { get; set; }
        public int CurrentVolume { get; set; }
        public bool TeletxtStatus { get; set; }
        public int TeletextChnl { get; set; }
        // constructors
        // methods
        public bool TurnTVOn()
        {
            PowerStatus = true;
            Console.WriteLine("TV is turned on");
            return PowerStatus;
        }
        public bool TurnTVOff()
        {
            PowerStatus = false;
            Console.WriteLine("TV is turned off");
            return PowerStatus;
        }
        public int NextChannel()
        {
            SelectedChannel = SelectedChannel + 1;
            Console.WriteLine("Next channel is {0}", SelectedChannel);
            return SelectedChannel;
        }
        public int PreviousChannel()
        {
            SelectedChannel = SelectedChannel - 1;
            Console.WriteLine("Previous channel is {0}", SelectedChannel);
            return SelectedChannel;
        }
        public int SetChannel(int channelNmb)
        {
            SelectedChannel = channelNmb;
            Console.WriteLine("Channel is now number {0}", SelectedChannel);
            return SelectedChannel;
        }
        public int VolumeUp()
        {
            CurrentVolume += 5;
            Console.WriteLine("Volume is now {0}", CurrentVolume);
            return CurrentVolume;
        }
        public int VolumeDown()
        {
            CurrentVolume -= 5;
            Console.WriteLine("Volume is now {0}", CurrentVolume);
            return CurrentVolume;
        }
        public int VolumeMute()
        {
            CurrentVolume = 0;
            Console.WriteLine("Volume is now muted");
            return CurrentVolume;
        }
        public bool TeletextOn()
        {
            TeletxtStatus = true;
            Console.WriteLine("Teletext is on");
            return TeletxtStatus;
        }
        public bool TeletextOff()
        {
            TeletxtStatus = false;
            Console.WriteLine("Teletext is off");
            return TeletxtStatus;
        }
        public int SetTeletextChannel(int teltxtNmb)
        {
            TeletextChnl = teltxtNmb;
            Console.WriteLine("Teletext channel is showing page {0}", TeletextChnl);
            return TeletextChnl;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
