/* T5-Nimet
 * Tehtävänanto:
 * 
 * Tee ohjelma, joka kysyy käyttäjältä henkilöiden nimiä, nimien syöttäminen lopetaan
 * antamalla tyhjä syöte. Tämän jälkeen ohjelma kertoo montako nimeä annettiin ja
 * näyttää ne aakkosjärjestyksessä.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace T5_Nimet
{
    class Program
    {
        static void Main(string[] args)
        {
            //muuttujat
            string input;
            string name;
            List<string> nameList = new List<string>();
            int nameCount = 0;
            //kysytään käyttäjältä nimi, lisätään nimi listaan ja toistetaan kunnes käyttäjä syöttää tyhjää.
            Console.WriteLine("Please, give names of students. Empty input [Enter] will stop the input.");
            while (true)
            {
                Console.Write("Give a name: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                name = NameToUpper(input); //kutsutaan metodia joka muuttaa nimen etukirjaimen isoksi kirjaimeksi
                nameList.Add(name);
            }
            //järjestetään lista aakkosittain ja tulostetaan nimilukumäärä sekä nimet käyttäjälle
            nameList.Sort();
            nameCount = nameList.Count;
            Console.WriteLine(nameCount + " names are given: ");
            foreach(string value in nameList)
            {
                Console.WriteLine(value);
            }
            //loppu
        }

        //NameToUpper metodi nuuttaa nimen ensimmäisen kirjaimen isoksi kirjaimeksi (käyttää System.Linq namespacea)
        public static string NameToUpper(string input)
        {
            //First() valitsee ensimmäisen merkin, ToString() muuttaa sen stringiksi ja ToUpper() sen isoksi kirjaimeksi, 
            //sitten siihen lisätään loput nimestä kohdasta 1 eteenpäin.
            string nameToUpper = input.First().ToString().ToUpper() + input.Substring(1); 
            string name = nameToUpper;
            return name;
        }
    }
}
