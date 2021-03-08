namespace SnapCard.Logic
{
    public class Card 
    {
       public Rank Rank { get; }
       public Suit Suit { get; }

       private bool _faceUp;

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public bool FaceUp() => _faceUp;

        public void FlipOver() => _faceUp = !_faceUp;

        public override string ToString()
        {
            return $"[{nameof(Rank)}: {Rank}, {nameof(Suit)}: {Suit}]";
        }
    }
}