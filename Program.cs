using System;
using System.Linq;
using System.Collections.Generic;

namespace Shuffle_and_draw5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make deck
            Card[] deck = Card.GetCards();

            Console.WriteLine("Standard Deck:" );
            Console.WriteLine();

            //Test Print out deck
            for (int i = 0; i < deck.Length; ++i)
            {
                Console.WriteLine($"{deck[i].Rank} of {deck[i].Suit}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Shuffled Deck:");
            Console.WriteLine();
            //Shuffle Deck
            deck = Card.ShuffledDeck(deck);
            Card[] shuffled = Card.ShuffledDeck(deck);
            for (int i = 0; i < deck.Length; ++i)
            {
                Console.WriteLine($"{shuffled[i].Rank} of {shuffled[i].Suit}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Five Card Hand from top of shuffled deck:");
            Console.WriteLine();
            //Draw 5 Cards
            Card[] hand = Card.GetHand(shuffled);
            for(int i = 0; i < hand.Length; ++i)
            {
                Console.WriteLine($"{hand[i].Rank} of {hand[i].Suit}");
            }

        }
       
    }
    //Cards Obj
    public class Card
    {
        public string Suit;
        public string Rank;     
        //generate 52 card deck
        public static Card[] GetCards()
        {
            Card[] deckOfCards = new Card[52];
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

            int cardIndex = 0;
            
            for (int i = 0; i < suits.Length; ++i)
            {
                for (int j = 0; j < ranks.Length; ++j)
                {
                    Card card = new Card();
                    card.Rank = ranks[j];
                    card.Suit = suits[i];
                    deckOfCards[cardIndex] = card;
                    ++cardIndex;
                }
            }
            return deckOfCards;
        }
        /// <summary>
        /// Takes an array of cards and returns a shuffled array.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static Card[] ShuffledDeck(Card[] cards)
        {
            List<Card> deckOfCards = new List<Card>(cards);
            Card[] shuffledCards = new Card[cards.Length];
            Random random = new Random();

            // Loops until the non-shuffled deck is empty randomly selecting a card to insert into the shuffledCards array
            for (int i = 0; deckOfCards.Count() != 0; i++)
            {
                int index = random.Next(deckOfCards.Count());

                shuffledCards[i] = deckOfCards[(index)];
                deckOfCards.Remove(deckOfCards[index]);
                
           }
            return shuffledCards;
        }
        /// <summary>
        /// Returns 5 cards from the top of a shuffled deck, this is not pertinent.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static Card[] GetHand(Card[] cards)
        {
            List<Card> DrawnDeck = new List<Card>(cards);
            Card[] cardsInHand = new Card[5];
            for(int i = 0; i < cardsInHand.Length; ++i)
            {
                cardsInHand[i] = DrawnDeck[i];
                DrawnDeck.Remove(DrawnDeck[i]);
            }
            return cardsInHand;
        }
    }
   
}
    
