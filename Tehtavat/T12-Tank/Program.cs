/* T12-Tank
 * Tehtävänanto:
 * toteuta luokka Tank, jolla on seuraavat ominaisuudet: 
 * Name (string), Type (string), CrewNumber(int), Speed(float), SpeedMax(float)
 * sekä metodit:
 * AccelerateTo(float), SlowTo(float)
 *
 * Ominaisuudet Name ja Type ovat luettavissa sekä muutettavissa ilman rajoituksia.
 * 
 * Toteuta muut ominaisuudet niin, että niillä on luokan sisäinen taustamuuttuja, jota luokka käyttää.
 * Ominaisuus CrewNumber on luettavissa ja asetettavissa, ja sen alkuarvo on 4. 
 * Sitä asetettaessa tarkistetaan, että annettu  ominaisuus on sallitulla välillä: minimi on kaksi ja maksimi kuusi.
 * SpeedMax-ominaisuus on pelkästään luettavissa, ja sen arvo on asetettu oletuksena pysyvästi arvoon 100. 
 * Speed-ominaisuuden lähtöarvo on nolla ja sitä ei voi asettaa suoraan, mutta sen arvon voi lukea. 
 * Speed-ominaisuuden arvoa voi muuttaa ainoastaan metodien AccerelateTo(float) ja SlowTo(float) kautta kuitenkin niin, 
 * että Speed ei voi olla nollaa pienempi eikä Speedmax-arvoa suurempi; minimi on nolla ja maksimi 100. 
 * Jos metodeille annettu arvo ei ole sallitulla välillä, niin metodi ei muuta Speed-arvoa.
 */

using System;

namespace T12_Tank
{
    class Tank
    {
        // field variables
        private readonly int defaultCrewNumber = 4;
        private int crew;
        private readonly float maxSpeed = 100;
        private readonly float minSpeed = 0;
        private float currentSpeed;

        // properties
        public string Name { get; set; }
        public string Type { get; set; }
        public int CrewNumber // crewnumber can only be between 2 and 6, default is 4
        {
            get { return crew; }
            set
            {
                if (value >= 2 && value <= 6)
                {
                    crew = value;
                }
                else
                {
                    // not between 2 and 6 - set to 4
                    crew = defaultCrewNumber;
                }
            }
        }
        public float Speed
        {
            get { return currentSpeed; }
        }
        public float SpeedMax
        {
            get { return maxSpeed; }
        }

        // constructors
        public Tank() // in default, there should always be 4 crew members in the tank
        {
            CrewNumber = defaultCrewNumber;
        }

        // methods
        public float AccelerateTo(float accelerate)
        {
            if ((accelerate > minSpeed) && (accelerate <= SpeedMax)) // accelerate should be between min and max speed
            {
                currentSpeed = accelerate;
                return Speed;
            }
            else // else no change in speed
                return Speed;
        }
        public float SlowTo(float slowdown)
        {
            if (slowdown < Speed && slowdown > minSpeed) // slowdown should be between current and minimum speed
            {
                currentSpeed = slowdown;
                return Speed;
            }
            else // if not, no change in speed
                return Speed;
        }
        public override string ToString()
        {
            return $"This {Name} is a {Type}-type of tank and it has {CrewNumber} crew members aboard. Its current speed is {Speed} of {SpeedMax}." ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tank tankki = new Tank() { Type = "Heavy", Name = "Tankki", CrewNumber = 5 };
            // printing info of the tank
            Console.WriteLine(tankki.ToString());
            // accelerating speed to 75
            tankki.AccelerateTo(75);
            Console.WriteLine("Tanks current speed is: " + tankki.Speed);
            // trying to accelerating speed to 125
            tankki.AccelerateTo(125);
            Console.WriteLine("Tanks current speed is: " + tankki.Speed); // should still be 75
            // slow it down to 33.
            tankki.SlowTo(33);
            Console.WriteLine("Tanks current speed is: " + tankki.Speed); // should be 33
            // trying to stop the tank by giving a negative value (reverse is not valid in this tank)
            tankki.SlowTo(-5);
            Console.WriteLine(tankki.ToString());
            // changing number of crewmembers to 7, should be 4 after because max is 6
            tankki.CrewNumber = 7;
            Console.WriteLine(tankki.ToString());
        }
    }
}
