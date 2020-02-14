/* T14-Amplifier
 * Tehtävänanto:
 * 
 * Tehtävänäsi on ohjelmoida yksinkertaisen vahvistimen toiminta, jolla voidaan kontrolloida äänenvoimakkuutta välillä 0-100. 
 * Toteuta Vahvistin-luokka ja tee pääohjelma, jolla luot olion Vahvistin-luokasta. 
 * Säädä ja kokeile vahvistinta eri äänenvoimakkuuksilla. 
 * Käytä Vahvistin-luokassa joko metodeja arvojen asettamiseen tai get- ja set-aksessoreita.
 * Get-aksessori palauttaa äänenvoimakkuuden ja set-aksessori asettaa äänenvoimakkuuden arvon rajoittaen kuitenkin sen sallitulle välille.
 */

using System;

namespace T14_Amplifier
{
    class Amplifier
    {
        // field variables
        private int maxVolume = 100;
        private int minVolume = 0;
        private int defaultVolume = 0;
        private int volume;
        // properties
        public int MinVol
        {
            get { return minVolume; }
        }
        public int MaxVol 
        { 
            get { return maxVolume; }
        }
        public int CurrentVol
        {
            get { return volume; }
        }
        // constructors
        public Amplifier()
        {
            volume = defaultVolume;
        }
        // methods
        public string SetVolume(int value)
        {
            if (value >= 0 && value <= 100)
            {
                volume = value;
                return $"Volume has been set to {CurrentVol.ToString()}";
            }
            else if (value < 0)
            {
                volume = minVolume;
                return $"Too low volume - Amplifier volume is set to minimum - {MinVol}";
            }
            else if (value > 100)
            {
                volume = maxVolume;
                return $"Too big volume - Amplifier volume is set to maximum - {MaxVol}";
            }
            else
                return CurrentVol.ToString(); // if everything above fails, return just current volume
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Amplifier kaiutin = new Amplifier();
            while (true)
            {
                Console.Write("Give a new volume value (0-100) > ");
                string input = Console.ReadLine();
                int.TryParse(input, out int inputVolume);
                Console.WriteLine(kaiutin.SetVolume(inputVolume));
            }
        }
    }
}
