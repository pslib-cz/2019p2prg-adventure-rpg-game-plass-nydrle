using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure2020.Models;
using Adventure2020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adventure2020
{
    public class PlaceModel : PageModel
    {
        public GameService gameService;

        public PlaceModel(GameService _gameService)
        {
            gameService = _gameService;
        }

        public Location Location { get; set; }
        public List<Connection> Directions { get; set; }
        public void OnGet(Room id)
        {
            gameService.FetchData();

            gameService.State.Location = id;

            gameService.Store();
            Location = gameService.Location;
            Directions = gameService.Directions;
            
        }

        public void OnPost()
        {
            foreach (var _item in gameService.State.Inventory)
            {
                if (_item == Location.FoundItem)
                {
                    _item.Counter++;
                }
            }
        }
    }
}