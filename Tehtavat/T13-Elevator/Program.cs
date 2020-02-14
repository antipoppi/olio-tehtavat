/* T13-Elevator
 * Tehtävänanto:
 * Tehtävänäsi on ohjelmoida Dynamon hissin kerroksen ohjaukseen liittyvä säädin.
 * Toteutetun ohjelman tulee pystyä kysymään käyttäjältä haluttu kerros ja siirtämään
 * hissi haluttuun kerrokseen (tässä tapauksessa ohjelma kertoo käyttäjälle missä kerroksessa hissi on).
 * Dynamon hissi voi olla vain kerroksissa 1-5; Käytä Hissi-luokassa joko  get- ja set-aksessoreita tai sopivia metodeja suojamaan olion tila.
 * Huom: Muista, että nyrkkisääntö on se että aksessorit get ja set eivät heitä poikkeuksia, eivätkä ne palauta mitään. 
 * Jos haluat että pääohjelma on tietoinen siitä, että halutun ominaisuuden muutos ei onnistu tai sitä ei voi tehdä, käytä silloin metodeja.
 */

using System;

namespace T13_Elevator
{
    class Elevator
    {
        // field variables
        private readonly int maxfloor = 5;
        private readonly int minFloor = 1;
        private int floor = 1;
        // properties
        public int MaxFloor
        {
            get { return maxfloor; }
        }
        public int MinFloor
        {
            get { return minFloor; }
        }
        public int FloorNmbr
        {
            get { return floor; }
        }

        // methods
        public string PrintFloorStatus()
        {
            return $"Elevator is in floor number {FloorNmbr}";
        }
        public static string InformTooBigNumber()
        {
            return $"The floor number is too big!";
        }
        public static string InformTooSmallNumber()
        {
            return $"The floor number is too small!";
        }
        public string SetFloor(int inputFloor)
        {
            if (inputFloor >= minFloor && inputFloor <= maxfloor)
            {
                floor = inputFloor;
                return PrintFloorStatus();
            }
            else if (inputFloor > maxfloor)
                return InformTooBigNumber();
            else
                return InformTooSmallNumber();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Elevator hissi = new Elevator();
            Console.WriteLine(hissi.PrintFloorStatus());
            while (true)
            {
                Console.Write("Give a new floor number (1-5) > ");
                string inputString = Console.ReadLine();
                int.TryParse(inputString, out int inputFloor);
                Console.WriteLine(hissi.SetFloor(inputFloor));
            }
        }
    }
}
