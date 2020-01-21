using System;

namespace OODemoCar
{
    public class Car
    {
        private readonly int maxSpeed = 200;
        public string Branch { get; set; }
        private int speed; // field parameter, jäsenmuuttuja. Aina pienellä.
        public int Speed // aksessori !!minimetodi, ei poikkeuksia eikä palauta mitään.!!
        {
            get // get hakee ja palauttaa
            {
                return speed;
            }
            set // set asettaa
            {
                if (value <= maxSpeed)
                    speed = value;
                else
                    speed = maxSpeed;
            }
        }
        // metodit (!!Muuttaa asioita, palauttaa arvon ja voi heittää poikkeuksen!!)
        public int Accelerate(int moreSpeed)
        {
            // nostetaan nopeutta, mutta ei yli maxSpeedin
            if (speed + moreSpeed <= maxSpeed)
                speed = speed + moreSpeed;
            // palautus
            return speed;
        }
        public int Brake(int lessSpeed)
        {
            // jarrutetaan, mutta ei alle nollan
            if (speed - lessSpeed >= 0)
                speed = speed - lessSpeed;
            else
                speed = 0;
            // palautus
            return speed;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // ostetaan oikea menopeli
            Car ferrari = new Car();
            ferrari.Branch = "Ferrari";
            ferrari.Speed = 50;
            Console.WriteLine("Autosi kulkee " + ferrari.Speed);
            // kiihdytetään 10km/h kerralla
            for (int i = 0; i < 20; i++)
            {
                ferrari.Accelerate(10);
                Console.WriteLine("Autosi kulkee nyt " + ferrari.Speed);
            }
            // jarrutus
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine("Autosi nopeus {0}", ferrari.Brake(9));
            }
            // ferrarin palautus takaisin liikkeeseen
            //ferrari = null;
            //Console.WriteLine("Autosi kulkee " + ferrari.Speed);
        }
    }
}
