/* T12-Tank
 * Tehtävänanto:
 * oteuta luokka Tank, jolla on seuraavat ominaisuudet: 
 * Name (string), Type (string), CrewNumber(int), Speed(float), SpeedMax(float)
 * sekä metodit:
 * AccerelateTo(float), SlowTo(float)
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
        private readonly float maxSpeed = 100;
        private readonly float minSpeed = 0;
        private readonly float accerelate = 25;

        // properties
        public string Name { get; set; }
        public string Type { get; set; }
        private int crew;
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
        private float currentSpeed;
        private float speed;
        public float Speed
        {
            get { return minSpeed; }
            set { speed = currentSpeed; }
        }
        public float SpeedMax
        {
            get { return maxSpeed; }
        }
        // methods
        public float AccerelateTo(float accerelate)
        {
            if (Speed >= 0 && Speed <= SpeedMax)
            {
                currentSpeed += accerelate;
                Speed = currentSpeed;
                return Speed;
            }
            else
                return Speed;
        }
        public void SlowTo()
        {

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Tank tankki = new Tank() { CrewNumber = 5 };
            tankki.AccerelateTo(25);
            tankki.AccerelateTo(25);
            tankki.AccerelateTo(25);
            tankki.AccerelateTo(25);
            tankki.AccerelateTo(25);
            tankki.AccerelateTo(25);
            Console.WriteLine(tankki.Speed);
        }
    }
}
