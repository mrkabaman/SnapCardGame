using System;
using SnapCard.Logic.Interfaces;

namespace SnapCard.Logic
{
    public class ShuffleCard : IShuffleCard
    {
        private readonly IDeck _deck;

        public ShuffleCard(IDeck deck)
        {
            _deck = deck;
        }
        public IDeck Shuffle()
        {
            Random random = new Random();
            
            for (int i = _deck.Cards.Length - 1; i > 0; i--)
            {
                int rand = random.Next(i + 1);
                
                Card temp = _deck.Cards[i];
                
                _deck.Cards[i] = _deck.Cards[rand];
                
                _deck.Cards[rand] = temp;
            }

            return _deck;
        }
    }
}