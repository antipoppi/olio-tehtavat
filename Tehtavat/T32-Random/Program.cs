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
using System.Diagnostics;

namespace T32_Random
{
    public class Person
    {
        #region Properties
        private Random rnd = new Random();
        public string Firstname { get; private set; }
        public string Surname { get; private set; }
        #endregion

        #region Constructor
        public Person()
        {
            Firstname = GetRndFirstname();
            Surname = GetRndSurname();
        }
        #endregion

        #region Methods
        public string GetRndFirstname()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder firstName = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    firstName.Append(letters[rnd.Next(0, 26)]);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    throw new Exception($"Kirjaimen arvonta epäonnstui: " + ex.Message);
                }
            }
            return firstName.ToString();
        }
        public string GetRndSurname()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sukunimi = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    sukunimi.Append(letters[rnd.Next(0, 26)]);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    throw new Exception($"Kirjaimen arvonta epäonnstui: " + ex.Message);
                }
            }
            return sukunimi.ToString();
        }
        public override string ToString()
        {
            return $"{Firstname} {Surname}";
        }
        #endregion
    }

    class Program
    {
        #region Main Program
        static void Main(string[] args)
        {
            // lets create a stopwatch to check the time for how long the searches take for
            Stopwatch watch = new Stopwatch();

            /// start the watch
            /// create a list of 10 000 unique random persons
            /// stop the watch and save elapsed time as a long value
            /// print for how long it did to take
            watch.Start();
            List<Person> lista = CreatePersonList();
            watch.Stop();
            long createListTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Persons olioiden lisäykseen listaan käytetty aika: {createListTime}ms");

            /// restart the watch
            /// search the list with a random first name and print 1000 of the results
            /// stop the watch and save elapsed time as a long value
            /// print for how long it did to take
            Console.WriteLine("Persons olioiden etsintä listasta (satunnaisella etunimellä):");
            watch.Restart();
            SearchList(lista);
            watch.Stop();
            long searchListTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Listasta etsintään käytetty aika: {searchListTime}ms");

            /// restart the watch
            /// create a dictionary of 10 000 unique random persons and their first names as the keys
            /// stop the watch and save elapsed time as a long value
            /// print for how long it did to take
            watch.Restart();
            Dictionary<string, Person> sanakirja = CreateDictionary();
            watch.Stop();
            long createDictionaryTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Persons olioiden lisäykseen sanakirjaan käytetty aika: {createDictionaryTime}ms");

            /// restart the watch
            /// search the dictionary with a random first name and print 1000 of the results (persons)
            /// stop the watch and save elapsed time as a long value
            /// print for how long it did to take
            watch.Restart();
            SearchDictionary(sanakirja);
            watch.Stop();
            long searchDictionaryTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Sanakirjasta etsintään käytetty aika: {searchDictionaryTime}ms\n");

            //print summary
            //"Found person #{count.ToString("0000")} with {person.Firstname} firstname : {item.ToString()}"
            Console.WriteLine("----------------------LOPPUTULOS-----------------------");
            Console.WriteLine("\nListan luominen        - " + createListTime + " ms");
            Console.WriteLine("Listasta etsiminen     - " + searchListTime + " ms");
            Console.WriteLine("Sanakirjan luominen    - " + createDictionaryTime + " ms");
            Console.WriteLine("Sanakirjasta etsiminen - " + searchDictionaryTime + " ms");
        }
        #endregion

        #region Methods
        public static List<Person> CreatePersonList() // creates a list with unique first names
        {
            List<Person> lista = new List<Person>();
            do
            {
                try
                {
                    Person person = new Person();
                    var hold = lista.Find(x => x.Firstname == person.Firstname);
                    if (hold == null)
                    {
                        lista.Add(person);
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Random Person etsintä epäonnistui: " + ex.Message);
                }
            } while (lista.Count < 10000);
            return lista;
        }
        public static void SearchList(List<Person> list) // search the list with a random first name
        {
            int count = 0;
            do
            {
                // checks every person in the list with the same firstname and prints search result into the console
                // when finished, it creates a new person and search again until it has printed 1000 times.
                Person person = new Person();
                foreach (Person item in list)
                {
                    if (item.Firstname == person.Firstname)
                    {
                        try
                        {
                            count++;
                            Console.WriteLine($"Löydetty person #{count.ToString("0000")} {person.Firstname} etunimellä : {item.ToString()}");
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Person #-muotoilu epäonnistui: " + ex.Message);
                        }
                    }
                }
            } while (count < 1000);
        }
        public static Dictionary<string, Person> CreateDictionary() // creates a dictionary with a uniquq first name as a key
        {
            Dictionary<string, Person> sanakirja = new Dictionary<string, Person>();
            do
            {
                try
                {
                    Person person = new Person();
                    if (!sanakirja.ContainsKey(person.Firstname))
                    {
                        try
                        {
                            sanakirja.Add(person.Firstname, person);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("Satunnaisen person olion lisääminen sanakirjaan epäonnistui: " + ex.Message);
                        }
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Person olion etsintä epäonnistui" + ex.Message);
                }
            } while (sanakirja.Count < 10000);
            return sanakirja;
        }
        public static void SearchDictionary(Dictionary<string, Person> sanakirja) // searches dictionary keys with a random first name
        {
            int count = 0;
            do
            {

                Person person = new Person();
                try
                {
                    // searches the dictionary for a person with the same firstname (as key) and prints the searched person into the console
                    // when finished, it creates a new person and searches again until it has printed 1000 times.
                    sanakirja.TryGetValue(person.Firstname, out person);
                    if (person != null)
                    {
                        try
                        {
                            count++;
                            Console.WriteLine(($"Löydetty person #{count.ToString("0000")} {person.Firstname} etunimellä : {person.ToString()}"));
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Person #-muotoilu epäonnistui: " + ex.Message);
                        }
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Person olion etsintä sanakirjasta epäonnstui:" + ex.Message);
                }
            } while (count < 1000);
        }
        #endregion
    } 
}
