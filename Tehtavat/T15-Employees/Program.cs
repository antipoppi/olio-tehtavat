/* T15-Employees
 * Tehtävänanto:
 * 
 * Ohjelmassa tulee pystyä käsittelemään työntekijöiden tietoja (Employee). 
 * Työntekijöiden osalta seuraavia tietoa pitää pystyä käsittelemään: työntekijän nimi (Name), työntekijän ammatti (Profession) ja palkka (Salary). 
 * Samassa ohjelmassa pitää pystyä käsittelemään myös johtajien tietoja (Boss), heillä on edellisten lisäksi myös auto (Car) ja palkkabonus (Bonus).
 * Tutki tehtävän tavoitetta/kerrontaa ja toteuta tarvittavat UML-luokkakaaviot. Toteuta tämän jälkeen vaaditut luokat, luo ja käytä olioita pääohjelmasta. 
 * Tulosta vaadittujen luokkien olioiden tietoja output-ikkunaan. Tietoja ei tarvitse kysyä sovelluksen käyttäjältä, vaan voit alustaa ne suoraan pääohjelmassa.
 * 
 */

using System;
using System.Collections.Generic; // for List<T>
using System.Text; // for € in console

namespace T15_Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // asettaa konsolin ulostulo-enkoodaukseksi UTF8, tällä saa €-merkin tulostettua oikein konsoliin
            Console.WriteLine("Firman Boss & Dumbs Ltd työntekijät ovat");
            // luodaan pari työntekijää ja yksi pomo
            Employee employee = new Employee();
            employee.Name = "Kirsi Kernel";
            employee.Profession = "Programmer";
            employee.Salary = 3000F;
            Employee employee2 = new Employee() { Name = "Matti Mainio", Profession = "Developer", Salary = 3000F };
            // työntekijät listaan
            List<Employee> staffList = new List<Employee>();
            staffList.Add(employee); // Kirsin tiedot sisältävä olio lisätään listaan employees
            staffList.Add(employee2); // Matin tiedot -::-
            // pomot
            Boss boss = new Boss();
            boss.Name = "John Doe";
            boss.Profession = "Manager";
            boss.Salary = 5000F;
            boss.Bonus = 1000F;
            boss.Car = "Audi";
            staffList.Add(boss); // perityn luokan olioita voi laittaa listaan, jonka tyyppinä on kantaluokka (Employee)
            // näytetään kaikki listan työntekijät ja lasketaan palkkojen kokonaissumma
            float totalSalaryCost = 0;
            foreach (Employee item in staffList)
            {
                Console.WriteLine(item.ToString());
                totalSalaryCost += item.Salary;
                // jos Boss-olio niin huomioidaan myös Bonus
                if (item is Boss) // is = boolean (tosi/epätosi) arvo
                {
                    Boss b = (Boss)item;
                    totalSalaryCost += b.Bonus;
                }
            }
            Console.WriteLine("Työntekijöiden yhteenlaskettu palkkasumma on {0}€", totalSalaryCost);
        }
    }
}
