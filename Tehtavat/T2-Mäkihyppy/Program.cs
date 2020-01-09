using System;
using System.Collections.Generic;

namespace T2_Mäkihyppy
{
    class Program
    {
        static void Main(string[] args)
        {
            //muuttujat
            string input;
            int judgePoints = 0;
            int pointHolder = 0;
            int totalPoints = 0;
            List<int> pointList = new List<int>();
            //kysytään käyttäjältä tuomaripiste, lisätään se listaan ja toistetaan viidesti
            for (int i=0; i<5; i++)
            {
                Console.Write("Give judge #" + (i+1) + " points: ");
                input = Console.ReadLine();
                int.TryParse(input,out judgePoints);
                pointList.Add(judgePoints);
            }
            //järjestetään lista pisteiden mukaan pienimmästä suurimpaan
            pointList.Sort();
            //vähennetään pienin ja isoin piste listasta
            pointList.RemoveAt(4);
            pointList.RemoveAt(0);
            //lasketaan taulukon sisältöjen summa
            for (int i=0; i<pointList.Count; i++)
            {
                pointHolder = pointList[i];
                totalPoints = pointHolder + totalPoints;
            }
            //tulostetaan konsoliin mäkihypyn kokonaispisteet
            Console.WriteLine("Total points are " + totalPoints + " points.");
            //loppu
        }
    }
}
