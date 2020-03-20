/* T34-Lambda
 * Tehtävänanto:
 * 
 * Toteuta pienimuotoinen MyMailBook-ohjelma, jolla voit hakea ja tallentaa tuttujesi sähköposti
 * (yksinkertaisuuden vuoksi oletetaan tässä että kullakin tutulla on vain yksi sähköpostiosoite).
 * Luo luokka Friend, jolla on ominaisuudet Name ja Email. 
 * Tee kokoelmaluokka MailBook, joka alustettaessa hakee tekstitiedostosta tutut.csv ja heidän sp-osoitteensa ja tallentaa
 * ne Friend-olioihin. 
 * Kokoelmaluokalla MailBook on readonly ominaisuus on Friends, joka palauttaa listan Friend-olioita.
 * Toteuta pääohjelmaan ja/tai em. MailBook-luokkaan seuraavat toiminnot:
 * 
 * Ohjelman käynnistyessä lukee tiedostosta tutut ja näyttää montako nimeä sai luettua ja näyttää kaikki ystävät näytöllä
 * Haku, jolle annetaan ystävän nimi tai sen alkuosa. Haku hakee lambda-funktiolla kaikki ystävät, joitten nimestä löytyy etsitty merkkijono. 
 * Huomaa että haku saattaa tuottaa yhden tai useamman tuloksen.
 * Uuden ystävän lisääminen, ystävän tiedot täytyy myös tallentaa em. tekstitiedostoon, huom: toteuta sopiva poikkeusten käsittely
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace T34_Lambda
{
    public class Friend
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public Friend()
        {
        }
        public Friend(string name, string email, string country)
        {
            Name = name;
            Email = email;
            Country = country;
        }
        public override string ToString()
        {
            return $"{Name} {Email} {Country}";
        }
    }
    public class Mailbook
    {
        public List<Friend> Friends { get; }
        public Mailbook()
        {
            Friends = new List<Friend>(GetFriendlist());
        }
        private List<Friend> GetFriendlist()
        {
            try
            {
                string separator = ";";
                string filename = Directory.GetCurrentDirectory() + @"\tutut.csv";
                string[] lines = File.ReadAllLines(filename);
                List<Friend> holder = new List<Friend>();
                foreach (string line in lines)
                {
                    // split the textline into 3 strings
                    string[] words = line.Split(separator.ToCharArray());
                    holder.Add(new Friend(words[0], words[1], words[2]));
                }
                return holder;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception("Ei voi lukea tiedostoa: " + ex.Message);
            }
            catch (FileNotFoundException)
            {
                CreateFriendList();
                List<Friend> holder = GetFriendlist();
                return holder;
            }
        }
        private void CreateFriendList()
        {
            StreamWriter outputFile = new StreamWriter("tutut.csv");
            outputFile.WriteLine("Aku Ankka;aa@none.com;USA\n" +
                                 "Pelle Peloton;pepe@none.com;USA\n" +
                                 "Matt Nickerson;matt@none.com;USA\n" +
                                 "Jack Russel;jr@none.com;USA)\n" +
                                 "Nikke Nackerstrom;niknac@none.com;SWE\n" +
                                 "Anna Nyman;annan@none.com;SWE\n" +
                                 "Pete Parkkonen;pr@none.com;FIN\n" +
                                 "Teppo Testaaja;tt@none.com;FIN\n" +
                                 "Kirsi Kernel;kr@none.com;FIN\n" +
                                 "Joe Doe;jd@none.com;RUS\n" +
                                 "Sven Duhfa;sd@none.com;NOR\n" +
                                 "Aku Hirviniemi;ah@none.com;FIN");
            try
            {
                outputFile.Close();
            }
            catch (EncoderFallbackException ex)
            {
                throw new Exception($"Tiedoston sulkeminen ei onnistu: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mailbook myMailBook = new Mailbook();
            myMailBook.Friends.ForEach(x => Console.WriteLine(x.ToString()));

            // haetaan tietyn nimisiä kavereita
            //Console.WriteLine("Haetaan kavereita, anna nimen alkukirjain: ");
            //string fl = Console.ReadLine(); // fl (first letter)
            var foo = myMailBook.Friends.FirstOrDefault(x => x.Name.StartsWith("wololoo"));
            if (foo != null)
                Console.WriteLine(foo.Name + " " + foo.Email);
            else
                Console.WriteLine("Ei löytynyt ketään alkuista kaveria");
            // huom metodi voi löytää yhden kaverin tai olla löytämättä
            //if (foo != null)
            //    Console.WriteLine(foo.Name + " " + foo.Email);
            //else
            //    Console.WriteLine("Ei löytynyt ketään {0} alkuista kaveria", fl);
            // haetaan kaikki suomalaiset kaverit
            //friendList.Where(x => x.Country == "FIN").ToList().ForEach(x => Console.WriteLine(x.Name)); // jos ei löydy, foreach ei toteudu vaikka lista on tyhjä
        }
    }
}
