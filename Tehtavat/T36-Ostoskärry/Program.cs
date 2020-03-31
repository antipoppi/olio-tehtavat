/* T36-Ostoskärry
 * Tehtävänanto:
 * 
 * Toteuta sovellus, jolla voit hallita ostoskärryn sisältöä. 
 * Ostettavalta tuotteelta riittää käsitellä nimi ja hinta.
 * Toteuta Product-luokka ja lisää pääohjelmassa esimerkiksi List-tietorakenteeseen muutamia Product-luokan oliota. 
 * Tulosta lopuksi kokoelman sisältö.
 * 
 * Testaa yksikkötestauksen avulla, että ostoskärry ilmoittaa oikean määrän tuotteita. 
 * Tee ja suorita yksikkötestit 0,1,2 ja 5 tuotetta varten.
 */
using System;
using System.Collections.Generic;

namespace T36_Ostoskärry
{
    public class ShoppingCart
    {
        public List<Product> Cart { get; set; }
        public ShoppingCart()
        {
            Cart = new List<Product>();
        }
        public string PrintAll()
        {
            string r = null;
            r += "Your products in shopping cart:";
            foreach (Product item in Cart)
            {
                r += "\n- product : " + item.ToString();
            }
            r += $"\nThere are {Cart.Count} products in shopping cart.";
            return r;
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // create shopping cart
            ShoppingCart ostoskori = new ShoppingCart();
            // add items to it
            ostoskori.Cart.Add(new Product("Maitopurkki", 1.15));
            ostoskori.Cart.Add(new Product("Jauheliha", 3.45));
            ostoskori.Cart.Add(new Product("Voi", 1.75));
            ostoskori.Cart.Add(new Product("Banaani", 1.45));
            ostoskori.Cart.Add(new Product("Kurkku", 0.87));
            ostoskori.Cart.Add(new Product("Tomaatti", 1.34));
            // print all products
            Console.WriteLine(ostoskori.PrintAll());
        }
    }
}
