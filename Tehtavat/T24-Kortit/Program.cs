/* T24-Kortit
 * Tehtävänanto:
 * 
 * Toteuta luokat: Kortti/Card ja Korttipakka/CardDeck. Toteuta ohjelma, joka luo kaikki
 * korttipelin kortit olioina (maat: hertta, ruutu, risti ja pata; arvot: A,K,Q,J, 10,9...2, kortteja siis 52.)
 * valitsemaasi tietorakenteeseen ja tulostaa tietorakenteen sisällön.
 * 
 * Jatkoa edelliseen. Kuinka voisit toteuttaa korttipakan sekoittamisen?
 * Toteuta Korttipakka-luokalle Sekoita/Shuffle-metodi, joka sekoittaa pakan kortit satunnaiseen järjestykseen. 
 * Kutsu metodin toimintaa pääohjelmasta
 */
using System;
using System.Collections.Generic;

namespace T24_Kortit
{
    class Card
    {
        public string Suit { get; set; }
        public string Rate { get; set; }
        public override string ToString()
        {
            return $"{Suit} {Rate}";
        }
    }
    class CardDeck
    {
        // field variable
        private static Random rng = new Random();
        // properties
        public List<Card> Cards { get; private set; }
        // constructor
        public CardDeck()
        {
            Cards = new List<Card>();
        }
        // methods
        public void Shuffle()
        {
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
        public string ShowDeck()
        {
            string allCards = "";
            foreach (Card item in Cards)
            {
                allCards += item.ToString() + "\n";
            }
            return allCards;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // create a deck of cards
            CardDeck pakka = new CardDeck();
            string j; // stores the A, J, Q and K
            // create Clubs
            for (int i = 1; i < 14; i++)
            {
                if (i == 11)
                {
                    j = "J";
                    pakka.Cards.Add(new Card { Suit = "Clubs", Rate = j });
                }
                else if (i == 12)
                {
                    j = "Q";
                    pakka.Cards.Add(new Card { Suit = "Clubs", Rate = j });
                }
                else if (i == 13)
                {
                    j = "K";
                    pakka.Cards.Add(new Card { Suit = "Clubs", Rate = j });
                }
                else if (i == 14)
                {
                    j = "A";
                    pakka.Cards.Add(new Card { Suit = "Clubs", Rate = j });
                }
                else
                {
                    pakka.Cards.Add(new Card { Suit = "Clubs", Rate = i.ToString() });
                }
            }
            // create Diamonds
            for (int i = 1; i < 14; i++)
            {
                if (i == 11)
                {
                    j = "J";
                    pakka.Cards.Add(new Card { Suit = "Diamonds", Rate = j });
                }
                else if (i == 12)
                {
                    j = "Q";
                    pakka.Cards.Add(new Card { Suit = "Diamonds", Rate = j });
                }
                else if (i == 13)
                {
                    j = "K";
                    pakka.Cards.Add(new Card { Suit = "Diamonds", Rate = j });
                }
                else if (i == 14)
                {
                    j = "A";
                    pakka.Cards.Add(new Card { Suit = "Diamonds", Rate = j });
                }
                else
                {
                    pakka.Cards.Add(new Card { Suit = "Diamonds", Rate = i.ToString() });
                }
            }
            // create Hearts
            for (int i = 1; i < 14; i++)
            {
                if (i == 11)
                {
                    j = "J";
                    pakka.Cards.Add(new Card { Suit = "Hearts", Rate = j });
                }
                else if (i == 12)
                {
                    j = "Q";
                    pakka.Cards.Add(new Card { Suit = "Hearts", Rate = j });
                }
                else if (i == 13)
                {
                    j = "K";
                    pakka.Cards.Add(new Card { Suit = "Hearts", Rate = j });
                }
                else if (i == 14)
                {
                    j = "A";
                    pakka.Cards.Add(new Card { Suit = "Hearts", Rate = j });
                }
                else
                {
                    pakka.Cards.Add(new Card { Suit = "Hearts", Rate = i.ToString() });
                }
            }
            // create Spades
            for (int i = 1; i < 14; i++)
            {
                if (i == 11)
                {
                    j = "J";
                    pakka.Cards.Add(new Card { Suit = "Spades", Rate = j });
                }
                else if (i == 12)
                {
                    j = "Q";
                    pakka.Cards.Add(new Card { Suit = "Spades", Rate = j });
                }
                else if (i == 13)
                {
                    j = "K";
                    pakka.Cards.Add(new Card { Suit = "Spades", Rate = j });
                }
                else if (i == 14)
                {
                    j = "A";
                    pakka.Cards.Add(new Card { Suit = "Spades", Rate = j });
                }
                else
                {
                    pakka.Cards.Add(new Card { Suit = "Spades", Rate = i.ToString() });
                }
            }
            // Show all the cards
            Console.WriteLine(pakka.ShowDeck());
            // shuffle the deck
            pakka.Shuffle();
            Console.WriteLine("Shuffling the deck..." + "\n");
            // show shuffled cards
            Console.WriteLine(pakka.ShowDeck());
        }
    }
}
