/*T6-Kiuas
 * Tehtävänanto:
 * 
 * Tehtävänäsi on ohjelmoida sähkökiukaan toiminta. Kiuas pitää pystyä laittamaan päälle
 * ja pois, sekä sen lämpötilaa että sen antamaa kosteutta pitää pystyä säätämään (arvoja ei ole rajattu).
 * 
 * Toteuta Kiuas-luokan ohjelmointi sekä pääohjelma, jolla luot olion Kiuas-luokasta.
 * Säädä kiuas-oliota erilaisilla arvoilla, jätä Console.WriteLine()-tulostuslauseet ohjelmaasi,
 * jotta kiuas-olion käyttäminen jää näkyville. Liitä luokkakaavion kuva projektin repoon sekä ohjelman suorite.
 * Tämä näissä kaikissa tehtävissä.
 */

using System;

namespace T6_Kiuas
{
    class Kiuas
    {
        //properties
        public string Name { get; set; }
        public bool StoveStatus { get; set; }
        public int Humidity { get; set; }
        public double Temperature { get; set; }
        //constructors
        public Kiuas()
        {
            StoveStatus = false;
            Humidity = 0;
            Temperature = 0;
        }
        //methods
        public bool TurnStoveOn()
        {
            StoveStatus = true;
            Console.WriteLine("Kiuas has been turned on");
            return StoveStatus;
        }
        public bool TurnStoveOff()
        {
            StoveStatus = false;
            Console.WriteLine("Kiuas has beeen turned off");
            return StoveStatus;
        }
        public int SetHumidity(int humidity)
        {
            Humidity = humidity;
            Console.WriteLine("Humidity has been set to {0}%.", humidity);
            return humidity;
        }
        public double SetTemperature(double temperature)
        {
            Temperature = temperature;
            Console.WriteLine("Temperature has been set to {0}%.", temperature);
            return temperature;
        }
        public void PrintInfo()
        {
            if (StoveStatus == false)
            {
                Console.WriteLine("Kiuas is turned off");
            }
            else Console.WriteLine("Kiuas {0} is turned on");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //create Kiuas object instance
            Kiuas kiuas = new Kiuas();
            //kiuas name
            kiuas.Name = "Harvia";
            //check kiuas status
            kiuas.PrintInfo();
            //turn kiuas on
            kiuas.TurnStoveOn();
            kiuas.SetHumidity(90);
            kiuas.SetTemperature(80.5);
            kiuas.SetHumidity(80);
            kiuas.SetTemperature(84.5);
            kiuas.TurnStoveOff();
        }
    }
}
