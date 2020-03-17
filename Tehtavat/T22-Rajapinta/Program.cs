/* T22-Rajapinta
 * Tehtävänanto:
 * 
 * Pohdi jokin reaalimaailman asia, jonka kautta voit toteuttaa pienimuotoisen C#-ohjelman/toteutuksen, joka käyttää rajapintaa.
 */

using System;

namespace T22_Rajapinta
{
    public interface IValokuva
    {
        string OtaKuva();
    }
    public class Puhelin
    {
        public string Malli { get; set; }
        public int Valmistusvuosi { get; set; }
        public virtual string Soita()
        {
            return "Jotain soittamista tapahtuu kännykällä";
        }
        public virtual string OtaKuva()
        {
            return "Kuva otettu nopeasti puhelimen takakameralla";
        }
    }
    public class Tabletti : Puhelin
    {
        public override string Soita()
        {
            return "Pädillä tapahtuu jotain soittamista internet-yhteyden yli";
        }
        public override string OtaKuva()
        {
            return "Selfie-kuva otettu kätevästi pädin etukameralla";
        }
    }
    public class Kamera
    {
        public string Malli { get; set; }
        public int ValmistusVuosi { get; set; }
        public string VaihdaObjektiivi()
        {
            return "Järjestelmäkameran objektiivi vaihdettu";
        }
        public string OtaKuva()
        {
            return "Täydellinen kvua otettu järjestelmäkameralla tarkan sommittelun ja asetusten hakemisen jälkeen";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // luodaan olioita
            Puhelin känny = new Puhelin() { Malli = "Samsung", Valmistusvuosi = 2019 };
            Tabletti pädi = new Tabletti() { Malli = "Huawei", Valmistusvuosi = 2017 };
            Kamera järkkäri = new Kamera() { Malli = "Nikon D500", ValmistusVuosi = 2018 };
            // leikitään olioilla
            Console.WriteLine(känny.Soita());
            Console.WriteLine(pädi.Soita());
            Console.WriteLine(järkkäri.VaihdaObjektiivi());
            // otetaan kuvia olioilla
            Console.WriteLine(känny.OtaKuva());
            Console.WriteLine(pädi.OtaKuva());
            Console.WriteLine(järkkäri.OtaKuva());

        }
    }
}
