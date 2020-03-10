using System;
using System.Collections.Generic;

namespace DemoRajapinta
{
    public interface ICanMakeNote
    {
        string MakeNote(string txt);
    }
    public interface ICanShowVideo
    {
        void ShowVideo(string url);
    }
    // kantaluokka
    public class Device
    {
        public string Manufacture { get; set; }
    }
    // luokat, jotka toteuttavat rajapinnan
    public class Tablet : Device, ICanMakeNote, ICanShowVideo
    {
        public string CPU { get; set; } // voi olla omia ominaisuuksia perittyjen lisäksi, sama metodeilla
        // methods
        public void ShowVideo(string ulr)
        {
            // TODO
        }
        public string MakeNote(string textToSave)
        {
            return "Your text is saved to harddisk successfully";
        }
    }
    public class Paper : ICanMakeNote
    {
        public string Size { get; set; }
        public string MakeNote(string txt)
        {
            return $"Your text {txt} has been written beautifully in to the paper with black ink";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testataan rajapintaa");
            Tablet iPadi = new Tablet();
            Console.WriteLine("Anna muistiinpano");
            string txt = Console.ReadLine();
            Console.WriteLine(iPadi.MakeNote(txt));
            Paper paperi = new Paper();
            Console.WriteLine(paperi.MakeNote(txt));
            // esimerkki 1 tyyppiyhteensopivuudesta
            List<ICanMakeNote> canMakeNotes = new List<ICanMakeNote>();
            canMakeNotes.Add(iPadi);
            canMakeNotes.Add(paperi);
            Console.WriteLine("Anna muistiinpano");
            txt = Console.ReadLine();
            foreach (var item in canMakeNotes)
            {
                // Console.WriteLine(item.MakeNote(txt)); // .MakeNote() löytyy, koska se on määritetty yhdistäväksi tekijäksi listassa
                TeeMuistiinpano(item, txt);
            }
            // esimerkki 2 tyyppiyhteensopivuudesta

        }
        static void TeeMuistiinpano(ICanMakeNote väline, string teksti)
        {
            Console.WriteLine(väline.MakeNote(teksti));
        }
    }
}
