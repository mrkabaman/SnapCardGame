using SnapCard.Logic.Interfaces;

namespace SnapCard.Logic
{
    public class CardDealer : ICardDealer
    {
        private readonly IDeck _deck;
        
        private int _dealtCards;

        public CardDealer(IDeck deck)
        {
            _deck = deck;
        }
        public Card Deal()
        {
            if (_dealtCards == _deck.Cards.Length)
                throw new ExceededDeckLengthException($"Deck has no card remaining...");
            
            Card removedCard = _deck.Cards[_dealtCards];
            
            _dealtCards++;
           
            return removedCard;
        }
        public int CardsRemaining()=> (_deck.Cards.Length - _dealtCards);
    }
}