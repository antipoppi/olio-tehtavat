/* T32-Random
 * Tehtävänanto:
 * 
 * Toteuta C#:lla ohjelma, jossa List-tietorakenteeseen lisätään satunnaisesti luotuja Person-luokan oliota 10.000 kappaletta.
 * Person-luokan olion etunimessä on käytettävä satunnaisesti kirjaimia väliltä A-Z ja etunimen pituus on 4 merkkiä. 
 * Sukunimi samoin, mutta pituus on 10 merkkiä.
 * Ohjelman tulee tulostaa henkilöiden lisäykseen kulunut aika millisekunteina.
 * Etsi tämän jälkeen tietorakenteesta 1000 satunnaista henkilöä rekisteristä etunimen perusteella. 
 * Tulosta löydettyjen henkilöiden tiedot sekä hakuun yhteensä kulunut aika millisekuntteina.
 * 
 * Kokeile samaa Dictionary-rakenteelle, käytä avaimena etunimeä. Muista sisällyttää
 * rakenteeseen 10.000 alkiota ja aloittaa satunnainen haku vasta sen jälkeen.
 * Muista, että Dictonary kokoelmassa ei voi olla kahta samaa avainta.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace T32_Random
{
    public class Person
    {
        private Random rnd = new Random();
        public string Firstname { get; private set; }
        public string Surname { get; private set; }
        public Person()
        {
            Firstname = RndFirstname();
            Surname = RndSurname();
        }
        public string RndFirstname()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder firstName = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                firstName.Append(letters[rnd.Next(0, 26)]);
            }
            return firstName.ToString();
        }
        public string RndSurname()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sukunimi = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sukunimi.Append(letters[rnd.Next(0, 26)]);
            }
            return sukunimi.ToString();
        }
        public override string ToString()
        {
            return $"{Firstname} {Surname}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<Person> lista = CreatePersonList();
            watch.Stop();
            Console.WriteLine($"Persons olioiden lisäykseen käytetty aika: {watch.ElapsedMilliseconds}ms");

            Console.WriteLine("Finding persons in collection (by firstname):");
            watch.Restart();
            SearchList(lista);
            watch.Stop();
            Console.WriteLine($"Total finding time: {watch.ElapsedMilliseconds}ms");
        }
        public static List<Person> CreatePersonList()
        {
            List<Person> lista = new List<Person>();
            do
            {
                Person person = new Person();
                var hold = lista.Find(x => x.Firstname == person.Firstname && x.Surname == person.Surname);
                if (hold == null)
                {
                    lista.Add(person);
                }
            }while (lista.Count < 10000);
            return lista;
        }
        public static void SearchList(List<Person> list)
        {
            int count = 0;
            do
            {
                Person person = new Person();
                foreach (Person item in list)
                {
                    if (item.Firstname == person.Firstname)
                    {
                        count++;
                        Console.WriteLine($"Found person {count} with {person.Firstname} firstname : {item.ToString()}");
                    }
                }
            } while (count < 1000);
        }
    }
}
