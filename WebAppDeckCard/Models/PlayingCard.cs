using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDeckCard.Models
{
    public class PlayingCard
    {
        public string FullSuitName { get; set; }
        public Char Suit { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }
        public int RankPosition { get; set; }
        public string Image { get; set; }
    }
    public class CardSuits
    {
        public char CardChar { get; set; }
        public string CardName { get; set; }
    }
}
