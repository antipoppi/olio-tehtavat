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

namespace T15_Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Firman Boss & Dumbs Ltd työntekijät ovat");
            // luodaan pari työntekijää ja yksi pomo
            Employee employee = new Employee();
            employee.Name = "Kirsi Kernel";
            employee.Profession = "Programmer";
            employee.Salary = 3000F;
            Employee employee2 = new Employee() { Name = "Matti Mainio", Profession = "Developer", Salary = 3000F };
            // työntekijät listaan
            List<Employee> staff = new List<Employee>();
            staff.Add(employee); // Kirsin tiedot sisältävä olio lisätään listaan employees
            staff.Add(employee2); // Matin tiedot -::-
            // näytetään kaikki listan työntekijät
            foreach (Employee item in staff)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
