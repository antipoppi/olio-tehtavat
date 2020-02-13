using System;
using System.Collections.Generic;
using System.Text;

namespace T20_Nisakas
{
    abstract class Nisakas
    {
        public abstract float Ika { get; set; }
        public abstract string Liiku();
    }
    class Ihminen : Nisakas
    {
        public override float Ika { get; set; }
        public string Nimi { get; set; }
        public int Pituus { get; set; }
        public double Paino { get; set; }
        public override string Liiku()
        {
            return "liikun";
        }
        public float Kasva()
        {
            return (Ika += 1);
        }
        public override string ToString()
        {
            return $"Ihminen nimeltä {Nimi} ikä={Ika} pituus={Pituus} paino={Paino}";
        }
    }
    class Aikuinen : Ihminen
    {
        public string Auto { get; set; }
        public override string Liiku()
        {
            return $"kävelee";
        }
    }
    class Vauva : Ihminen
    {
        public string Vaippa { get; set; }
        public override string Liiku()
        {
            return $"konttaa";
        }
    }
}
