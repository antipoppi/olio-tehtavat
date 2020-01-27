/* T8-Vehicle
 * Tehtävänanto:
 * Määrittelyssä on tunnistettu, että sovelluksen tarvitsee käsitellä erilaisia ajoneuvoja,
 * joita ovat: polkupyörä, moottoripyörä, henkilöauto, kuorma-auto. Luokka suunnittelussa
 * on päätetty luoda Vehicle-luokka edustamaan ajoneuvoja. Ajoneuvoista on
 * tunnistettu seuraavat yhteiset ominaisuudet: valmistaja, malli, nopeus ja renkaiden
 * lukumäärä. Luo Vehicle-luokka seuraavien tietojen mukaisesti:
 * 
 * ominaisuudet (properties)
 * Branch:string
 * Model:string
 * Speed:int
 * Tyres:int
 * 
 * toiminnot (methods)
 * ShowInfo():string, palauttaa Vehiclen valmistaja ja mallitiedot merkkijonona
 * ToString():string, palauttaa kaikki Vehiclen ominaisuudet yhtenä merkkijonona, huom: ylikirjoita kantaluokan ToString()
 * 
 * Toteuta Vehicle-luokan ohjelmointi sekä pääohjelma, jossa luodaan vähintään kaksi
 * oliota Vehicle-luokasta. Luonnin jälkeen muuta olion ominaisuuksia ja
 * tulosta olioiden tiedot konsolille kummallakin metodilla.
 */
using System;

namespace T9_Vehicle
{
    class Vehicle
    {
        // field variables
        // properties
        public string Branch { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Tyres { get; set; }
        // constructors
        // methods
        public string ShowInfo()
        {
            return "Valmistaja: " + Branch + "\nMalli: " + Model;
        }
        public override string ToString()
        {
            return "\nValmistaja: " + Branch + "\nMalli: " + Model + "\nNopeus: " + Speed + "\nRenkaiden määrä: " + Tyres;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // luodaan henkilöauto
            Vehicle auto = new Vehicle();
            auto.Branch = "Volkswagen";
            auto.Model = "Pickup";
            auto.Speed = 80;
            auto.Tyres = 4;
            // luodaan mopo
            Vehicle pyörä = new Vehicle();
            pyörä.Branch = "Tunturi";
            pyörä.Model = "Supersport";
            pyörä.Speed = 45;
            pyörä.Tyres = 2;
            // muutetaan henkilöauton malli ja nopeus
            auto.Model = "Coupe";
            auto.Speed = 120;
            // muutetaan mopo kolmipyöräksi
            pyörä.Tyres = 3;
            pyörä.Speed = 10;
            // tulostetaan auton ja mopon valmistaja ja mallitiedot konsoliin
            Console.WriteLine(auto.ShowInfo());
            Console.WriteLine(pyörä.ShowInfo());
            // tulostetaan auton ja mopon tarkat tiedot konsoliin
            Console.WriteLine(auto.ToString());
            Console.WriteLine(pyörä.ToString()); 
        }
    }
}
