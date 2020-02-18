using System;
using System.Collections.Generic;

namespace DemoDictionary
{
    class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SocialSecurityID { get; set; }
        public override string ToString()
        {
            return $"{Firstname} {Lastname}, hetu: {SocialSecurityID}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testataan Dictionary-kokoelmaa");
            // luodaan henkilöitä sisältävä kokoelma
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            // luodaan henkilöitä
            Person person1 = new Person() { Firstname = "John", Lastname = "Doe", SocialSecurityID = "010185-111A" };
            Person person2 = new Person() { Firstname = "Netta", Lastname = "Meikäläinen", SocialSecurityID = "211286-222A" };
            Person person3 = new Person() { Firstname = "Matti", Lastname = "Veikkola", SocialSecurityID = "130587-333A" };
            // lisätään henkilöitä Dictionaryyn
            persons.Add(person1.SocialSecurityID, person1);
            persons.Add(person2.SocialSecurityID, person2);
            persons.Add(person3.SocialSecurityID, person3);
            // kokoelman läpikäyntiä
            Console.WriteLine("Kokoelmassa on {0} henkilöä", persons.Count);
            Console.WriteLine("Henkilöiden HETUt ovat: ");
            foreach (var item in persons.Keys) // avaimet määritettiin listaa luodessa (string) ja valittiin henkilöä lisättäessä (hetu)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Henkilöiden tiedot ovat: "); // values on yhtä kuin person-kaikki tiedot
            foreach (var item in persons.Values)
            {
                Console.WriteLine(item);
            }
            // haku kokoelmasta
            string hetu = "130587-333A";
            if (persons.ContainsKey(hetu))
            {
                Console.WriteLine("Löytyi henkilö {0}", persons[hetu]);
            }
            else
            {
                Console.WriteLine($"Ei ole henkilöä jonka hetu on {hetu}");
            }
        }
    }
}
