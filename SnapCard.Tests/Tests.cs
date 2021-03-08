using System.Linq;
using NUnit.Framework;
using SnapCard.Logic;
using SnapCard.Logic.Interfaces;

namespace SnapCard.Tests
{
    public class Tests
    {
        [Test]
        public void Test_CardCreated_RankAndSuit_Remains_Unchanged()
        {
            //Arrange/Act
            Card card = new Card(Rank.Ace, Suit.Club);
            
            //Assert
            Assert.That(card, Is.Not.Null);
            
            Assert.That(card.Rank, Is.EqualTo(Rank.Ace));
            
            Assert.That(card.Suit, Is.EqualTo(Suit.Club));
        }

        [Test]
        public void Test_Card_ToString_Override()
        {
            //Arrange/Act
            Card card = new Card(Rank.Eight, Suit.Club);

            string text = card.ToString();
            
            //Assert
            Assert.That(text, Contains.Substring($"{card.Rank}"));
            
            Assert.That(text, Contains.Substring($"{card.Suit}"));

        }

        [Test]
        public void Shuffle_And_Deal_Returns_Different_Card()
        {
            IDeck deck = new Deck();
            
            IShuffleCard shuffleCard = new ShuffleCard(deck);
            
            deck = shuffleCard.Shuffle();

            ICardDealer cardDealer = new CardDealer(deck);

            Card first = cardDealer.Deal();

            Card second = cardDealer.Deal();
            
            Assert.That(first, Is.Not.EqualTo(second));
        }

        [Test]
        public void Hand_Add_Card_Increases_Count()
        {
            //Arrange/Act
            Card card = new Card(Rank.Nine, Suit.Club);

            Hand hand = new Hand(new[] {card});
            
            Assert.That(hand.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Hand_Remove_Card_Decreases_Count()
        {
            //Arrange/Act
            Card fiveClub = new Card(Rank.Five, Suit.Club);
            Card fourHeart = new Card(Rank.Four, Suit.Heart);
            Card threeSpade = new Card(Rank.Three, Suit.Spade);

            Hand hand = new Hand(new[] {fiveClub,fourHeart,threeSpade});
            
            hand.RemoveCard(fourHeart);
          
            Assert.That(hand.Count, Is.EqualTo(2));
        }
        
        [Test]
        public void Hand_Remove_Card_Removes_Card_From_Hand()
        {
            //Arrange/Act
            Card fiveClub = new Card(Rank.Five, Suit.Club);
            Card fourHeart = new Card(Rank.Four, Suit.Heart);
            Card threeSpade = new Card(Rank.Three, Suit.Spade);

            Hand hand = new Hand(new[] {fiveClub,fourHeart,threeSpade});
            
            hand.RemoveCard(fourHeart);

            Card? fourHeartInHand = hand.FirstOrDefault(a => a.Rank == Rank.Four && a.Suit == Suit.Heart);
           
            Assert.That(fourHeartInHand, Is.Null);
        }

        [Test] public void Test_Deal_Decreases_Deck_Size()
        {
            IDeck deck = new Deck();

            IShuffleCard shuffleCard = new ShuffleCard(deck);
            
            deck = shuffleCard.Shuffle();
            
            ICardDealer cardDealer = new CardDealer(deck);
            
            Card first = cardDealer.Deal();
            
            Assert.That(cardDealer.CardsRemaining(), Is.EqualTo(51));
        }

        [Test]
        public void Deal_All_Cards()
        {
            IDeck deck = new Deck();
            
            IShuffleCard shuffleCard = new ShuffleCard(deck);
            
            deck = shuffleCard.Shuffle();
            
            ICardDealer cardDealer = new CardDealer(deck);

            int cardsLeft = deck.Cards.Length;

            while (cardsLeft > 0)
            {
                Card card = cardDealer.Deal();
                
                cardsLeft--;
                
                Assert.That(cardsLeft, Is.EqualTo(cardDealer.CardsRemaining()));
              
            }

        }
    }
}