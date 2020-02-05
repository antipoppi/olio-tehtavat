/* T11-CD
 * Tehtävänanto:
 * 
 * Suunnittele UML-editorilla CD-luokka, joka sisältää ominaisuuksina tyypillisiä CD-levyyn kuuluvia tietoja.
 * Pohdi myös mitä eri toiminnallisuuksia CD:llä voisi olla. Toteuta ainakin toiminnallisuus,
 * joka palauttaa kaikkien ominaisuuksien arvot yhtenä merkkijonona (sen avulla pääohjelmassa voisi
 * tulostaa kaikki CD:n tiedot). Toteuta luokalle myös ominaisuus Songs. 
 * Songs voi olla joko taulukko (Array) tai lista (List) levyn kappaleista; ne voivat tässä tehtävässä olla stringejä.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace T11_CD
{
    class CD
    {
        // field variables
        private int copyprotection;
        
        // properties
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public float Price { get; set; }
        public List<string> Songs { get; set; }
        public int CopyProtectionId
        {
            get { return copyprotection; }
            set { CopyProtectionId = value; }
        }
        // contructors
        public CD()
        {
            copyprotection = DateTime.Now.Millisecond;
        }
        // methods
        public override string ToString()
        {
            return $"CD: \n- Artist: " + Artist + " \n- Name: " + Name + " \n- Genre: " + Genre + " \n- Price: " 
                + Price + "€\nSongs:\n" + string.Join("\n", Songs) + "\n- CopyProtection ID: " + CopyProtectionId + "\n";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // this allows showing € in the console
            // creating cd1
            CD cd1 = new CD() { Artist = "Metallica", Name = "Ride the Lightning", Genre = "Metal", Price = 19.9F };
            List<string> songList = new List<string>();
            songList.Add("--- Name: Fight Fire with Fire (4:45)");
            songList.Add("--- Name: Ride the Lightning (6:36)");
            songList.Add("--- Name: For Whom the Bell Tolls (5:09)");
            songList.Add("--- Name: Fade to Black (6:57)");
            songList.Add("--- Name: Trapped Under Ice (4:04)");
            songList.Add("--- Name: Escape (4:23)");
            songList.Add("--- Name: Creeping Death (6:36)");
            songList.Add("--- Name: The Call of Ktulu (8:53)");
            cd1.Songs = songList;
            Console.WriteLine(cd1.ToString());
            // creating cd2
            CD cd2 = new CD() { Artist = "Natalia Lafourcade", Name = "Hasta la Raíz", Genre = "Latin pop", Price = 17.9F };
            List<string> songList2 = new List<string>();
            songList2.Add("--- Name: Hasta la Raíz (3:41)");
            songList2.Add("--- Name: Mi Lugar Favorito (4:57)");
            songList2.Add("--- Name: Antes de Huir (3:52)");
            songList2.Add("--- Name: Ya No Te Puedo Querer (4:47)");
            songList2.Add("--- Name: Para Qué Sufrir (3:46)");
            songList2.Add("--- Name: Nunca es suficiente (3:57)");
            songList2.Add("--- Name: Palomas Blancas (4:47)");
            songList2.Add("--- Name: Te Quiero Ver (3:27)");
            cd2.Songs = songList2;
            Console.WriteLine(cd2.ToString());
        }
    }
}
