using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDeckCard.Models
{
    public interface IDeckCardRepository
    {
        IEnumerable<PlayingCard> GetAllPlayingCard();
        IEnumerable<PlayingCard> ShufflePlayingCard();
        List<PlayingCard> SortByGropName(string cardName);

    }
}
