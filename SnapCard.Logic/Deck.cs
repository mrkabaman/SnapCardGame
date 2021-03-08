using System;
using SnapCard.Logic.Interfaces;

namespace SnapCard.Logic
{
    public class Deck : IDeck
    {
        private const int DeckSize = 52;
       
        public Card[] Cards { get;}
        
        public Deck()
        {
            
            Cards = new Card[DeckSize];
            
            InitializeDeck();
            
        }

        private void InitializeDeck()
        {
            int deckCount = 0;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards[deckCount++] = new Card(rank, suit);
                }
            }
        }
    }
}