namespace SnapCard.Logic.Interfaces
{
    public interface ICardDealer
    {
        Card Deal();

        int CardsRemaining();
    }
}