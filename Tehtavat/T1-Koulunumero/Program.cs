﻿/* T1-Koulunumero
 * Tehtävänanto:
 * 
 * Tee ohjelma, jossa annetaan oppilaalle koulunumero seuraavan taulukon mukaan
 * (pistemäärä kysytään ja ohjelma tulostaa numeron):
 * 
 *  0  -  1 = 0
 *  0  -  2 = 1
 *  4  -  5 = 2
 *  6  -  7 = 3
 *  8  -  9 = 4
 * 10  - 11 = 5
 * 
 */

using System;

namespace T1_Koulunumero
{
    class Program
    {
        static void Main(string[] args)
        {
            //muuttujat
            int point = 0;
            int grade = 0;
            string input;

            //kysytään käyttäjältä pistemäärä
            Console.WriteLine("Give points: ");
            input = Console.ReadLine();
            //muutetaan käyttäjän antama teksti (string) kokonaisluvuksi
            point = int.Parse(input); //huom ei aina välttämättä onnistu, vaan voi aiheuttaa poikkeuksen
            //pistemäärän perusteella arvosana
            if (point < 2)
            {
                grade = 0;
            }
            else if (point <4)
            {
                grade = 1;
            }
            else if (point < 6)
            {
                grade = 2;
            }
            else if (point < 8)
            {
                grade = 3;
            }
            else if (point < 10)
            {
                grade = 4;
            }
            else
            {
                grade = 5;
            }
            //näytetään käyttäjälle
            Console.WriteLine("School number is " + grade.ToString() + ".");
            //loppu
        }
    }
}
