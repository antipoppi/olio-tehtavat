using System;
using System.Collections.Generic;
using System.Linq;

namespace T34_Lambda
{
    public class Friend
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simppeli Lambda-demo");
            // luodaan kaverilista jossa neljä nimeä
            List<Friend> friendList = new List<Friend>
            {
                new Friend{Name="Jack Russel", Email="jr@none.com", Country="USA"},
                new Friend{Name="Anna Nyman", Email="annan@none.com", Country="SWE"},
                new Friend{Name="Pete Parkkonen", Email="pr@none.com", Country="FIN"},
                new Friend{Name="Teppo Testaaja", Email="tt@none.com", Country="FIN"}
            };
            // listataan kaverit näytölle
            friendList.ForEach(x => Console.WriteLine(x.Name));

            // haetaan tietyn nimisiä kavereita
            Console.WriteLine("Haetaan kavereita, anna nimen alkukirjain: ");
            string fl = Console.ReadLine(); // fl (first letter)
            var foo = friendList.FirstOrDefault(x => x.Name.StartsWith(fl));
            // huom metodi voi löytää yhden kaverin tai olla löytämättä
            if (foo != null)
                Console.WriteLine(foo.Name + " " + foo.Email);
            else
                Console.WriteLine("Ei löytynyt ketään {0} alkuista kaveria", fl);
            // haetaan kaikki suomalaiset kaverit
            friendList.Where(x => x.Country == "FIN").ToList().ForEach(x => Console.WriteLine(x.Name)); // jos ei löydy, foreach ei toteudu vaikka lista on tyhjä
        }
    }
}
