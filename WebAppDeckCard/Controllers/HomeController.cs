using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppDeckCard.Models;

namespace WebAppDeckCard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeckCardRepository _deckCardRepository;

        public HomeController(IDeckCardRepository deckCardRepository)
        {
            _deckCardRepository = deckCardRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllDeck()
        {
            var getAllCards = _deckCardRepository.GetAllPlayingCard();
            return Json(getAllCards);
        }
        public IActionResult ShufflePlayingCard()
        {
            var getAllCards = _deckCardRepository.ShufflePlayingCard();
            return Json(getAllCards);
        } 
        
        public IActionResult SortByGropName(string cardName)
        {
            var data = _deckCardRepository.SortByGropName(cardName);
            return Json(data);
        }
    }
}