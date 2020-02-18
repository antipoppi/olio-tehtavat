/* T16-Vehicles
 * Tehtävänanto:
 * Toteutettavassa sovelluksessa tulisi pysyä käsittelemään erilaisia kulkuneuvoja. 
 * Kaikilla kulkuneuvoilla on löydettävissä yhteisinä ominaisuuksina: nimi, malli, vuosimalli ja väri. 
 * Erikoistapauksina pitää pystyä käsittelemään polkupyöriä ja veneitä. 
 * Polkupyörän osalta pitää pystyä erottelemaan se, että onko kyseessä vaihdepyörä vai ei sekä mahdollisen vaihteiston mallinimi. 
 * Veneiden osalta tietoina pitää ainakin olla veneen tyyppi (soutuvene, moottorivene, kajakki, ...) ja kuinka monta istuinpaikkaa veneestä löytyy.
 * 
 * Tutki tehtävän tavoitetta/kerrontaa ja toteuta tarvittavat UML-luokkakaaviot. 
 * Toteuta tämän jälkeen vaaditut luokat, luo ja käytä olioita pääohjelmasta. 
 * Tulosta vaadittujen luokkien olioiden tietoja output-ikkunaan. 
 * Tietoja ei tarvitse kysyä sovelluksen käyttäjältä, vaan voit alustaa ne suoraan pääohjelmassa.
 */

using System;
using System.Collections.Generic;

namespace T16_Vehicles
{
    class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Colour { get; set; }
        public override string ToString()
        {
            return $"\nKulkuneuvon tiedot: \nNimi: {Name} \nMalli: {Model} \nValmistusvuosi: {ProductionYear} \nVäri: {Colour}";
        }
    }
    class Bicycle : Vehicle
    {
        public bool Gear { get; set; }
        public string GearName { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nVaihteet: {Gear} \nVaihteiden nimi: {GearName}";
        }
    }
    class Boat : Vehicle
    {
        public string Type { get; set; }
        public int SeatAmount { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nTyyppi: {Type} \nIstuinpaikkojen määrä: {SeatAmount}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // luodaan kulkuneuvo-olioita
            Vehicle auto = new Vehicle() { Name = "Porche", Model = "Coupe", Colour = "Yellow", ProductionYear = 2005 };
            // luodaan vaihteeton polkupyörä
            Bicycle pyörä1 = new Bicycle() { Name = "Helkama", Model = "Tunturi", Colour = "Blue", ProductionYear = 1985, Gear = false };
            // luodaan vaihteellinen polkupyörä
            Bicycle pyörä2 = new Bicycle() { Name = "Baana", Model = "Dyyni", Colour = "White", ProductionYear = 2003, Gear = true, GearName="Shimano - 3 gears" };
            // luodaan vene jossa 3 istumapaikkaa
            Boat vene = new Boat() { Name = "Asseri", Model = "420", Colour = "Green", ProductionYear = 2010, Type = "rowing boat", SeatAmount = 3 };
            // luodaan lista johon lisätään oliot
            List<Vehicle> vehiclesList = new List<Vehicle>();
            vehiclesList.Add(auto);
            vehiclesList.Add(pyörä1);
            vehiclesList.Add(pyörä2);
            vehiclesList.Add(vene);
            // tulostetaan listan sisältö
            foreach (Vehicle item in vehiclesList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
