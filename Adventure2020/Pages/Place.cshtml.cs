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
        private GameService GameService;

        public PlaceModel(GameService _gameService)
        {
            GameService = _gameService;
        }

        public Location Location { get; set; }
        public List<Connection> Directions { get; set; }
        public void OnGet(Room id)
        {
            GameService.FetchData();

            GameService.State.Location = id;

            GameService.Store();
            Location = GameService.Location;
            Directions = GameService.Directions;
            if (Location.GottenItem != null)
            {
                
            }
        }
    }
}