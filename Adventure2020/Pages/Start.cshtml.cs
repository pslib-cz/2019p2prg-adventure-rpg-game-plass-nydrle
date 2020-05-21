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
    public class StartModel : PageModel
    {
        private GameService GameService;
        public Location Location { get; set; }
        public List<Connection> Directions { get; set; }

        public StartModel(GameService _gs)
        {
            GameService = _gs;
        }

        public void OnGet()
        {
            GameService.Start();
            Location = GameService.Location;
            Directions = GameService.Directions;
        }
    }
}