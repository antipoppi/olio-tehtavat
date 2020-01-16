/* T7-Pesukone
 * Tehtävänanto:
 * 
 * Tehtävänäsi on ohjelmoida pyykinpesukoneen toiminta. Samoin kuin edellinen tehtävä:
 * mitä ominaisuuksia ja toimintoja tekisit Pesukone-luokkaan?
 * 
 * Suunnittele ja piirrä Pesukone-luokan ominaisuudet ja toiminnot UML-luokkakaaviona. Liitä kuva projektin repoon.
 * 
 * Toteuta Pesukone-luokan ohjelmointi sekä pääohjelma, jolla luot olion Pesukone-luokasta.
 * Säädä pesukone-oliota erilaisilla arvoilla, jätä Console.WriteLine()-tulostuslauseet ohjelmaasi,
 * jotta pesukone-olion käyttäminen jää näkyville. Toteuta Pesukone-luokkaan muutamia erilaisia
 * konstruktoreita ja alusta niitä käyttämällä oliota pääohjelmasta käsin.
 */

using System;

namespace T7_Pesukone
{
    class WashingMachine
    {
        // field variables
        public int[] washTemperature = { 10, 30, 60, 90 };
        public int[] SpinSpeed = { 500, 800 };
        // enums
        public enum WashPrograms
        {
            None,
            Cotton,
            Coloured,
            QuickWash,
            Synthetics,
            Wool,
            Delicate
        }
        // properties
        public bool PowerStatus { get; set; }
        public WashPrograms SelectedProgram { get; set; }

        public int SelectedWashingTemperature { get; set; }
        public int SelectedSpinSpeed { get; set; }
        // constructors
        public WashingMachine()
        {
            PowerStatus = false;
            SelectedWashingTemperature = washTemperature[1]; // 30
            SelectedSpinSpeed = SpinSpeed[0]; // 500
            SelectedProgram = WashPrograms.None;
        }
        // methods
        public bool TurnPowerOn()
        {
            PowerStatus = true;
            Console.WriteLine("Washing maschine is turned on");
            return PowerStatus;
        }
        public bool TurnPowerOff()
        {
            PowerStatus = false;
            Console.WriteLine("Washing maschine is turned off");
            return PowerStatus;
        }
        public WashPrograms SetProgramme(WashPrograms programId)
        {
            SelectedProgram = (WashPrograms)programId; 
            Console.WriteLine("Washing program has been set to {0}", SelectedProgram);
            return SelectedProgram;
        }
        public int SetTemperature(int i)
        {
            SelectedWashingTemperature = washTemperature[i];
            Console.WriteLine("Washing temperature has been set to {0}", SelectedWashingTemperature);
            return SelectedWashingTemperature;
        }
        public int SetSpinSpeed(int i)
        {
            SelectedSpinSpeed = SpinSpeed[i];
            Console.WriteLine("Spinning speed has been set to {0}", SelectedSpinSpeed);
            return SelectedSpinSpeed;
        }
        public void PrintInfo()
        {
            Console.WriteLine("\nCurrent settings:\n- Program: {0}", SelectedProgram);
            Console.WriteLine("- Washing temperature: {0} Celsius", SelectedWashingTemperature);
            Console.WriteLine("- Spinning speed: {0}rpm\n", SelectedSpinSpeed);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // luodaan whirlpool niminen washingmachine olio-instanssi
            WashingMachine whirlpool = new WashingMachine();
            // käynnistetään pesukone
            whirlpool.TurnPowerOn();
            // säädetään pesukoneen asetuksia
            whirlpool.SetProgramme((WashingMachine.WashPrograms)1);
            whirlpool.SetProgramme(WashingMachine.WashPrograms.Wool);
            whirlpool.SetTemperature(2);
            whirlpool.SetSpinSpeed(1);
            // tulostetaan whirlpoolin tämän hetkiset asetukset konsoliin
            whirlpool.PrintInfo();
            // suljetaan pesukone
            whirlpool.TurnPowerOff();
            // loppu
        }
    }
}
