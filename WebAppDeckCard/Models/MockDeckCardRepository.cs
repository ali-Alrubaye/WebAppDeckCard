using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDeckCard.Models
{
    public class MockDeckCardRepository : IDeckCardRepository
    {
        private readonly Random Rng = new Random();
        private List<CardSuits> cardSuits;
        private List<PlayingCard> playingCards;
        private List<string> cardsValue;
        public MockDeckCardRepository()
        {
            cardSuits = new List<CardSuits>()
            {
                new CardSuits(){ CardChar = 'H', CardName = "Hearts"},
                new CardSuits(){ CardChar = 'C', CardName = "Clubs"},
                new CardSuits(){ CardChar = 'D', CardName = "Diamonds"},
                new CardSuits(){ CardChar = 'S', CardName = "Spades"}
            };
            playingCards = new List<PlayingCard>()
            {
                new PlayingCard(){ Rank = "2", Value = 2, RankPosition = 1  },
                new PlayingCard(){ Rank = "3", Value = 3, RankPosition = 2  },
                new PlayingCard(){ Rank = "4", Value = 4, RankPosition = 3  },
                new PlayingCard(){ Rank = "5", Value = 5, RankPosition = 4  },
                new PlayingCard(){ Rank = "6", Value = 6, RankPosition = 5  },
                new PlayingCard(){ Rank = "7", Value = 7, RankPosition = 6  },
                new PlayingCard(){ Rank = "8", Value = 8, RankPosition = 7  },
                new PlayingCard(){ Rank = "9", Value = 9, RankPosition = 8  },
                new PlayingCard(){ Rank = "10", Value = 10, RankPosition = 9  },
                new PlayingCard(){ Rank = "J", Value = 10, RankPosition = 10  },
                new PlayingCard(){ Rank = "Q", Value = 10, RankPosition = 11  },
                new PlayingCard(){ Rank = "K", Value = 10, RankPosition = 12  },
                new PlayingCard(){ Rank = "A", Value = 10, RankPosition = 13  },
            };

            cardsValue = new List<string>() {
        "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "AS", "JS", "QS", "KS",
        "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "AC", "JC", "QC", "KC",
        "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "AH", "JH", "QH", "KH",
        "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "AD", "JD", "QD", "KD"};
        }

        public IEnumerable<PlayingCard> GetAllPlayingCard()
        {
            var returAllCards = InitCardList();

            return returAllCards;
        }

        public IEnumerable<PlayingCard> ShufflePlayingCard()
        {
            var shuffleCardList = InitCardList();
            var n = shuffleCardList.Count;
            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                var value = shuffleCardList[k];
                shuffleCardList[k] = shuffleCardList[n];
                shuffleCardList[n] = value;
            }
            return shuffleCardList;
        }

        public List<PlayingCard> InitCardList()
        {
            var InitList = new List<PlayingCard>();
            foreach (var suit in cardSuits)
            {
                foreach (var value in playingCards)
                {
                    var card = new PlayingCard
                    {
                        Suit = suit.CardChar,
                        FullSuitName = suit.CardName,
                        Rank = value.Rank,
                        Value = value.Value,
                        RankPosition = value.RankPosition,
                        Image =  value.Rank +suit.CardChar + ".png"
                    };
                    InitList.Add(card);
                }
            }
            return InitList;
        }
     
        public List<PlayingCard> SortByGropName(string cardName)
        {
            var returAllCards = InitCardList();

            var gropCard = returAllCards.Select(x => new PlayingCard {
             FullSuitName = x.FullSuitName,
             Rank = x.Rank,
             Suit = x.Suit,
             Value = x.Value,
             RankPosition = x.RankPosition,
             Image = x.Image}).Where(x => x.FullSuitName == cardName).ToList();
            return gropCard;
        }
    }
}
