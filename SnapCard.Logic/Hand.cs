using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SnapCard.Logic
{
    public class Hand: IEnumerable<Card>
    {
        private readonly List<Card> _cards;

        public Hand(IEnumerable<Card> cards) => (_cards) = (cards).ToList();

        public IEnumerator<Card> GetEnumerator() => _cards.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void AddCard(Card card)
        {
            if (card == null)
                throw new ArgumentNullException($"Cannot add empty or null card to hand of cards....");
            
            _cards.Add(card);

        }
        
        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        public int Count => _cards.Count();
    }
}