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
        #region Properties
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        #endregion

        #region Constructors
        public Friend()
        {
        }
        public Friend(string name, string email, string country)
        {
            Name = name;
            Email = email;
            Country = country;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name} {Email} {Country}";
        }
        #endregion
    }
    public class Mailbook
    {
        #region Properties
        public List<Friend> Friends { get; }
        #endregion

        #region Constructors
        public Mailbook()
        {
            Friends = new List<Friend>(GetFriendlist());
        }
        #endregion

        #region Methods
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
        public void SaveFriend(Friend friend)
        {
            // save new friend to the Friends-list
            Friends.Add(friend);
            // save new friend also to the "tutut.csv"-file
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\tutut.csv";
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine($"{friend.Name};{friend.Email};{friend.Country}");
                try
                {
                    sw.Close();
                }
                catch (EncoderFallbackException ex)
                {
                    throw new Exception($"Tiedoston sulkeminen ei onnistu: {ex.Message}");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception("Ei voi lukea tiedostoa: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Ei voi lisätä kaveria: " + ex.Message);
            }
            catch (PathTooLongException ex)
            {
                throw new Exception("Tiedostopolku liian pitkä: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception("Kansiota ei löydy: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                throw new Exception("Ei voi lisätä kaveria: " + ex.Message);
            }
        }
        public string FindFriend(string firstLetters)
        {
            try
            {
                var foo = Friends.FindAll(x => x.Name.StartsWith(firstLetters));
                if (foo != null)
                {
                    string foundFriends = " - " + string.Join("\n - ", foo.Select(x => x.ToString()));
                    return $"\nLöydettiin kaveri/kavereita kirjaimilla '{firstLetters}': \n{foundFriends}";
                }
                else
                    return $"Ei löytynyt ketään {firstLetters} alkuista kaveria";
            }
            catch (ArgumentNullException ex)
            {
                return "Kaverin etsiminen epäonnistui: " + ex.Message;
            }
            catch (OutOfMemoryException ex)
            {
                return "Kaverin etsiminen epäonnistui: " + ex.Message;
            }
        }
        public string FindFriendCountry(string country)
        {
            try
            {
                var foo = Friends.Where(x => x.Country == country).ToList();
                if (foo != null)
                {
                    string foundFriends = " - " + string.Join("\n - ", foo.Select(x => x.ToString()));
                    return $"\nLöydettiin kaveri/kavereita maatunnuksella {country}: \n{foundFriends}";
                }
                else
                    return $"Ei löytynyt ketään kaveria maatunnuksella {country}";
            }
            catch (ArgumentNullException ex)
            {
                return "Kaverin etsiminen epäonnistui: " + ex.Message;
            }
            catch (OutOfMemoryException ex)
            {
                return "Kaverin etsiminen epäonnistui: " + ex.Message;
            }
        }
        #endregion
    }
    class Program
    {
        #region Main program
        static void Main(string[] args)
        {
            Mailbook myMailBook = new Mailbook();
            PrintAllFriends(myMailBook);
            // lisätään uusi kaveri listaan/tiedostoon
            myMailBook.SaveFriend(new Friend("Matti Meikäläinen", "mm@none.com", "FIN"));
            PrintAllFriends(myMailBook);
            // haetaan tietyn nimisiä kavereita kysymällä haettavan kaverin alkukirjaimia ja tulostetaan löydetyt konsoliin
            AskFirstLetters(myMailBook);
            // haetaan kaikki kaverit tietystä maasta ja tulostetaan ne konsoliin
            Console.WriteLine(myMailBook.FindFriendCountry("USA"));
        }
        #endregion

        #region Main methods
        public static void PrintAllFriends(Mailbook mailbook)
        {
            try
            {
                mailbook.Friends.ForEach(x => Console.WriteLine(x.ToString()));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Ei voinut tulostaa haettuja kavereita: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Ei voinut tulostaa haettuja kavereita: " + ex.Message);
            }
        }
        public static void AskFirstLetters(Mailbook mailbook)
        {
            try
            {
                Console.Write("\nSyötä haettavan kaverin alkukirjaimet: ");
                string firstLetters = Console.ReadLine();
                Console.WriteLine(mailbook.FindFriend(firstLetters));
            }
            catch (IOException ex)
            {
                Console.WriteLine("Ei voinut lukea syötettä: " + ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("Ei voinut lukea syötettä: " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Ei voinut lukea syötettä: " + ex.Message);
            }
        }
        #endregion
    }
}
