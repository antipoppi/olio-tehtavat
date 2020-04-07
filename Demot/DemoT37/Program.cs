using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoT37
{
    public class InvoiceItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get { return Quantity * Price; } }
        public override string ToString()
        {
            return $"{Name}\t{Price.ToString("C")} {Quantity} kpl {Total.ToString("C")}";
        }
    }
    public class Invoice
    {
        public string CustomerName { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public int ItemsCount { get { return Items.Count; } }
        public int ItemsTogether
        {
            get
            {
                return Items.Sum(item => item.Quantity);
            }
        }
        // konstruktori
        public Invoice()
        {
            Items = new List<InvoiceItem>();
        }
        public double CountTotal()
        {
            double total = 0;
            foreach (InvoiceItem item in Items)
            {
                total += item.Total;
            }
            return total;
        }
    }
    class TestInvoice
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laskun kirjoittaja");
            Invoice jaskanLasku = new Invoice() { CustomerName = "Jaska" };
            InvoiceItem item1 = new InvoiceItem() { Name = "Banaani", Price = 0.49, Quantity = 2 };
            InvoiceItem item2 = new InvoiceItem() { Name = "Leipä", Price = 2.49, Quantity = 1 };
            InvoiceItem item3 = new InvoiceItem() { Name = "Limu", Price = 0.79, Quantity = 6 };
            // tuotteet Jaskan laskulle
            jaskanLasku.Items.Add(item1);
            jaskanLasku.Items.Add(item2);
            jaskanLasku.Items.Add(item3);
            // kutsutaan kuitin tulostusta
            PrintPrettyInvoice(jaskanLasku);

        }
        private static void PrintPrettyInvoice(Invoice invoice)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Asiakas {invoice.CustomerName} lasku XXX:");
            foreach (var item in invoice.Items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Tuotteita {invoice.ItemsTogether} Yhteensä {invoice.CountTotal().ToString("C")}");
        }
    }
}
