/* T21-Kassa
 * Tehtävänanto:
 * 
 * Toteuta pienimuotoinen Kassa-ohjelma, jolla voi suorittaa sekä Käteismaksuja että Korttimaksuja.
 * Luo luokat PaidWithCash ja PaidWithCard. Kumpikin luokkaa toteuttaa ITransaction-rajapinnan vaatimat metodit, kumpikin omalla tavallaan. 
 * Interfacessa määritelty palauttaa suomenkielisen viestin miten maksu suoritettiin. 
 * Viesti myös näyttää maksun määrän Euroina. 
 * Metodi GetAmount palauttaa maksetun määrän lukuna.
 * PaidWithCash-luokalle toteuta metodi public float ShowCash(), joka kertoo paljonko rahaa kassasa on,
 * eli se tallentaa itselleen kaikki kassaan laitetut rahat.
 * 
 * Tee Testi-ohjelma, jossa suoritat kaksi maksua kummallakin tavalla, siis käteisellä ja kortilla.
 * Tee Testi-ohjelmaan myös toteutus siitä että se osaa kertoa päivän myynnin yhteensä.
 */

using System;
using System.Collections.Generic;

namespace T21_Kassa
{
    public interface ITransaction
    {
        // interface members 
        string ShowTransaction();
        float GetAmount();
    }
    public class PaidWithCash : ITransaction
    {
        public float Billnumber { get; set; }
        public float Transaction { get; set; }
        public float CashValue { get; set; }
        public float TotalSales { get; set; }
        public List<float> Cash { get; set; }
        public PaidWithCash()
        {
            Cash = new List<float>();
        }
        public string ShowTransaction()
        {
            try
            {
                Billnumber++;
                string date = DateTime.Now.ToString();
                string transaction = Transaction.ToString("C");
                return $"Maksettiin käteisellä: Käteisnumero {Billnumber}. Aika: {date}. Määrä {transaction}";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return "Ei voi hakea päivämäärää: " + ex.Message;
            }
            catch (FormatException ex)
            {
                return "Ei voida hakea paikallista valuutta-merkkiä: " + ex.Message;
            }
            
        }
        public float GetAmount()
        {
            Cash.Add(Transaction);
            return Transaction;
        }
        public float ShowCash()
        {
            float holderF = 0F;
            foreach (float item in Cash)
            {
                holderF += item;
            }
            TotalSales += holderF;
            return holderF;
        }
    }
    public class PaidWithCard : ITransaction
    {
        public int CardNmb { get; set; }
        public float BankValue { get; set; }
        public float Transaction { get; set; }
        public float TotalSales { get; set; }
        public List<float> Bank { get; set; }
        public PaidWithCard()
        {
            Bank = new List<float>();
        }
        public string ShowTransaction()
        {
            try
            {
                CardNmb++;
                string firstNmb = CardNmb.ToString("D4");
                CardNmb++;
                string secondNmb = CardNmb.ToString("D4");
                string cardNmb = firstNmb + "-" + secondNmb;
                string date = DateTime.Now.ToString();
                string transaction = Transaction.ToString("C");
                TotalSales += Transaction;
                return $"Maksettiin kortilla: Korttinumero {cardNmb}. Aika: {date}. Määrä {transaction}";
            }
            catch (FormatException ex)
            {
                return "Ei voi muuttaa kortin osaa: " + ex.Message;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return "Ei voi hakea päivämäärää: " + ex.Message;
            }
        }
        public float GetAmount()
        {
            Bank.Add(Transaction);
            return Transaction;
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   // luodaan kortti-olio jolla maksetaan korttiostoksia
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                PaidWithCard kortti = new PaidWithCard();
                Console.Write("Syötä paljonko maksetaan kortilla: ");
                kortti.Transaction = float.Parse(Console.ReadLine());
                kortti.GetAmount(); // metodi hakee summan paljonko on maksettu
                Console.WriteLine(kortti.ShowTransaction()); // metodi palauttaa stringinä ostotapahtuman tiedot
                Console.Write("Syötä paljonko maksetaan kortilla: ");
                kortti.Transaction = float.Parse(Console.ReadLine());
                kortti.GetAmount();
                Console.WriteLine(kortti.ShowTransaction());

                // luodaan käteinen-olio jolla maksetaan käteisostoksia
                PaidWithCash käteinen = new PaidWithCash();
                Console.Write("Syötä paljonko maksetaan käteisellä: ");
                käteinen.Transaction = float.Parse(Console.ReadLine());
                käteinen.GetAmount(); // metodi hakee summan paljonko on maksettu
                Console.WriteLine(käteinen.ShowTransaction()); // metodi palauttaa stringinä ostotapahtuman tiedot
                Console.Write("Syötä paljonko maksetaan käteisellä: ");
                käteinen.Transaction = float.Parse(Console.ReadLine());
                käteinen.GetAmount();
                Console.WriteLine(käteinen.ShowTransaction());
                // ShowCash() näyttää paljonko kassassa on rahaa
                Console.WriteLine("Käteistä kassassa yhteensä: " + käteinen.ShowCash().ToString("C")); 
                // tulostetaan päivän kokonaismyynti
                Console.WriteLine(TotalSales(käteinen, kortti));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Väärä syöte: " + ex.Message); 
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Väärä syöte: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Väärä syöte: " + ex.Message);
            }
        }
        public static string TotalSales(PaidWithCash käteinen, PaidWithCard kortti)
        {
            try
            {
                string totalSales = (käteinen.TotalSales + kortti.TotalSales).ToString("C");
                string date = DateTime.Today.ToString("dddd dd MMMM yyyy");
                return $"Päivän {date} kaikki myynti yhteensä: {totalSales}";
            }
            catch (FormatException ex)
            {
                return "Päivän myynnin koostaminen epäonnistui: " + ex.Message;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return "Päivämäärän muuttaminen ei onnistunut: " + ex.Message;
            }
        }
    }
}
