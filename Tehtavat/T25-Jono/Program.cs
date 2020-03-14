using System;
using System.Collections.Generic;

namespace T25_Jono
{
    class Asiakkaat
    {
        public string Name { get; set; }
    }
    class Kassajono
    {
        // properties
        public Queue<Asiakkaat> Jono { get; private set; }
        public int Pituus
        {
            get
            {
                return Jono.Count;
            }
        }
        // constructors
        public Kassajono()
        {
            Jono = new Queue<Asiakkaat>();
        }
        // methods
        public void MeneJonoon(Asiakkaat asiakas)
        {
            Jono.Enqueue(asiakas);
        }
        public void PoistuJonosta(Asiakkaat asiakas)
        {
            Jono.Dequeue();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
