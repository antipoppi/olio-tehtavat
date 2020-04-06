/* T37-Ostokset
 * Tehtävänanto:
 * 
 * Toteuta ohjelma, jossa voidaan näyttää lasku ostetuista tavaroista.
 * Jokaisesta ostetusta tavarasta tulee käsitellä seuraavat tiedot: nimi, hinta ja määrä.
 * Toteutetun luokan tulee osata palauttaa tieto siitä paljonko ko. ostetut tavarat kokonaisuudessaan maksavat (hinta*määrä). 
 * Toteuta myös ToString()-metodi, joka palauttaa tuotteen nimen, hinnan ja määrät merkkijonona.
 * 
 * Toteuta luokka, joka pitää sisällään List-rakenteessa yllä määriteltyjä tuotteita. 
 * Luokan tulee pystyä kertomaan myös asiakkaan nimi, paljonko "laskulla" on yhteensä tuotteita sekä niihin kuluva rahan määrä kokonaisuudessaan.
 * 
 * Toteuta pääohjelma, jossa määrittelet laskulle tavaroita ja ostajan nimi. Toteuta pääohjelmaan privaatti metodi PrintInvoice, joka tekee siistin laskun.
 * - PrintInvoice(Invoice invoice) : string
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace T37_Ostokset
{
    public class InvoiceItem
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public double Total { get; private set; }
        public InvoiceItem()
        {
        }
        public InvoiceItem(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Total = CountTotal();
        }
        public double CountTotal()
        {
            Total = Price * Quantity;
            return Total;
        }
        public override string ToString()
        {
            try
            {
                string price = String.Format("{0:C2}", Price);
                string total = String.Format("{0:C2}", Total);
                string r = String.Format("{0,-10} {1,-10} {2,-1} {3,-9} {4,-10}", Name, price, Quantity, "pieces", total);
                return r;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Tavaran formatointi epäonnistui: " + ex.Message);
            }
            catch (FormatException ex)
            {
                throw new Exception("Tavaran formatointi epäonnistui: " + ex.Message);
            }
        }
    }
    public class Invoice
    {
        public string Customer { get; private set; }
        public List<InvoiceItem> Items { get; private set; }
        public int ItemsCount { get; private set; } // count of different InvoiceItems
        public int ItemsTogether { get; private set; } // total number of items
        public Invoice(string customer)
        {
            Customer = customer;
            Items = new List<InvoiceItem>();
        }
        public double CountTotals(List<InvoiceItem> items)
        {
            double total = 0;
            foreach (InvoiceItem item in items)
            {
                total += item.Total;
            }
            return total;
        }
        public void UpdateTotalItemInfo()
        {
            try
            {
                List<InvoiceItem> uniikit = Items.GroupBy(x => x.Name).Select(y => y.First()).ToList();
                if (uniikit != null)
                    ItemsCount = uniikit.Count;
                foreach (InvoiceItem item in Items)
                {
                    ItemsTogether += item.Quantity;
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Uniikkien tavaroiden laskeminen epäonnistui: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Uniikkien tavaroiden laskeminen epäonnistui: " + ex.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // used for to print € to console
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // create new Invoice with a customer name
            Invoice invoice = new Invoice("John Doe"); 
            // add items to the invoice
            invoice.Items.Add(new InvoiceItem("Milk", 1.35, 2));
            invoice.Items.Add(new InvoiceItem("Beer", 2.19, 2));
            invoice.Items.Add(new InvoiceItem("Butter", 3.29, 1));
            invoice.Items.Add(new InvoiceItem("Beer", 2.19, 2));
            // print the invoice
            Console.WriteLine(PrintInvoice(invoice));
        }
        private static string PrintInvoice(Invoice invoice)
        {
            // first we update invoice-objects ItemsCount and ItemsTogether properties
            invoice.UpdateTotalItemInfo();
            // after that we'll start making the bill and then return it
            try
            {
                string lasku = null;
                lasku += "Customer " + invoice.Customer + "'s invoice:";
                lasku += "\n========================================";
                foreach (InvoiceItem item in invoice.Items)
                {
                    lasku += "\n" + item.ToString();
                }
                lasku += "\n========================================";
                string countTotal = String.Format("{0:C2}", invoice.CountTotals(invoice.Items));
                lasku += String.Format("\n{0,-22}" + invoice.ItemsCount, "Unique item-names:");
                lasku += String.Format("\n{0,-21} {1,-1} {2,-8} {3}", "Total:", invoice.ItemsTogether, "pieces", countTotal);
                return lasku;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Laskun tekeminen epäonnistui: " + ex.Message);
            }
            catch (FormatException ex)
            {
                throw new Exception("Laskun tekeminen epäonnistui: " + ex.Message);
            }
        }
    }
}
