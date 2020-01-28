// T3-Kulutus olioratkaisuna

using System;

namespace OODemoKulutus
{
    class Car
    {
        public string Model { get; set; }
        public float Consumption { get; set; }
    }
    class Distance
    {
        public float Kilometers { get; set; } 
        public Car UsedCar { get; set; }
        public float CountCost(float fuelprice) // tätä käyttääkseen täytyy luoda Distance-luokan olio-instanssi
        {
            // lasketaan matkan kustannukset
            return (Kilometers * UsedCar.Consumption * fuelprice) / 100F;
        }
    }
    class CarUtils
    {
        public static float CountCost(float distance, float consumption, float fuelprice) // huomaa että staattinen metodi, voidaan kutsua mutta ei luoda olio-instanssia
        {
            return (distance * consumption * fuelprice) / 100F;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // staattisen metodin kutsuminen
            Console.WriteLine("250km matka kulutus 7,5l/100km 1,5€/ltr maksaa {0}", CarUtils.CountCost(250, 7.5F, 1.5F));
            // oliomainen ratkaisu
            Car car = new Car() { Model = "Saab", Consumption = 7.5F };
            Distance distance = new Distance();
            distance.Kilometers = 250F;
            distance.UsedCar = car;
            Console.WriteLine("Sama olioilla {0}", distance.CountCost(1.5F));
        }
    }
}
