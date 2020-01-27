/* T10-Opiskelija
 * Tehtävänanto:
 * 
 * Suunnittele UML-editorilla Opiskelija-luokka, joka sisältää opiskelijalle
 * tyypillisiä tietoja ja toimintoja. Ohjelmoi Opiskelija-luokka sekä toteuta pääohjelma,
 * joka luo muutamia opiskelijoita ja tallentaa opiskelijat taulukkoon (esim. 5 opiskelijaa).
 * Tulosta taulukossa olevien opiskelijoiden tiedot käyttämällä toistorakennetta.
 */

using System;

namespace T10_Opiskelija
{
    class Opiskelija
    {
        // properties
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string LineOfStudy { get; set; }
        public int StartingYear { get; set; }
        public bool StudyStatus { get; set; }
        public bool EatStatus { get; set; }
        public bool SleepStatus { get; set; }
        public bool CodeStatus { get; set; }
        public bool PartyStatus { get; set; }
        public bool ExcerciseStatus { get; set; }
        // constructors
        public Opiskelija()
        {
            StudyStatus = true;
            EatStatus = false;
            SleepStatus = false;
            CodeStatus = false;
            PartyStatus = false;
            ExcerciseStatus = false;
        }
        // methods
        public bool Study()
        {
            if (StudyStatus == false)
                StudyStatus = true;
            else
                StudyStatus = false;
            return StudyStatus;
        }
        public bool Eat()
        {
            if (EatStatus == false)
                EatStatus = true;
            else
                EatStatus = false;
            return EatStatus;
        }
        public bool Sleep()
        {
            if (SleepStatus == false)
                SleepStatus = true;
            else
                SleepStatus = false;
            return SleepStatus;
        }
        public bool Code()
        {
            if (CodeStatus == false)
                CodeStatus = true;
            else
                CodeStatus = false;
            return CodeStatus;
        }
        public bool Party()
        {
            if (PartyStatus == false)
                PartyStatus = true;
            else
                PartyStatus = false;
            return PartyStatus;
        }
        public bool Excercise()
        {
            if (ExcerciseStatus == false)
                ExcerciseStatus = true;
            else
                ExcerciseStatus = false;
            return ExcerciseStatus;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // luodaan students-taulukko johon lopuksi opiskelijat lisätään
            Opiskelija[] students = new Opiskelija[5];
            // luodaan ensimmäinen opiskelija
            Opiskelija student1 = new Opiskelija();
            student1.FirstName = "Tatu";
            student1.Lastname = "Alatalo";
            student1.Age = 32;
            student1.ID = "N4927";
            student1.LineOfStudy = "ICT";
            student1.StartingYear = 2019;
            // luodaan toinen opiskelija
            Opiskelija student2 = new Opiskelija();
            student2.FirstName = "Matti";
            student2.Lastname = "Meikäläinen";
            student2.Age = 23;
            student2.ID = "K1234";
            student2.LineOfStudy = "Sosiologia";
            student2.StartingYear = 2018;
            // luodaan kolmas opiskelija
            Opiskelija student3 = new Opiskelija();
            student3.FirstName = "Maija";
            student3.Lastname = "Meikäläinen";
            student3.Age = 22;
            student3.ID = "L1234";
            student3.LineOfStudy = "Matematiikka";
            student3.StartingYear = 2017;
            // luodaan neljäs opiskelija
            Opiskelija student4 = new Opiskelija();
            student4.FirstName = "Liisa";
            student4.Lastname = "Kekkola";
            student4.Age = 26;
            student4.ID = "O4398";
            student4.LineOfStudy = "Liiketalous";
            student4.StartingYear = 2019;
            // luodaan viides opiskelija
            Opiskelija student5 = new Opiskelija();
            student5.FirstName = "Mauri";
            student5.Lastname = "Laurila";
            student5.Age = 37;
            student5.ID = "M6587";
            student5.LineOfStudy = "Filosofia";
            student5.StartingYear = 2020;
            // laitetaan opiskelija1 koodaamaan
            student1.Code();
            Console.WriteLine("Opiskelija {0} alkoi koodaamaan true/false ({1})", student1.FirstName, student1.CodeStatus);
            // lisätään opiskelijat students-taulukkoon
            students[0] = student1;
            students[1] = student2;
            students[2] = student3;
            students[3] = student4;
            students[4] = student5;
            // tulostetaan taulukon tiedot
            foreach (Opiskelija item in students)
            {
                Console.WriteLine("\nEtunimi: {0} \nSukunimi: {1} \nIkä: {2} \nOpiskelijaID: {3} \nLinja: {4} \nAloitusvuosi: {5}", item.FirstName, item.Lastname, item.Age, item.ID, item.LineOfStudy, item.StartingYear);
            }
        }
    }
}
