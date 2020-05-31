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
        public List<Item> FoundItems { get; set; }
        public GameService gameService;
        public SessionStorage<GameService> _ss;
        public ILocationProvider LocPro;
        public PlaceModel(GameService _gameService, ILocationProvider _loc)
        {
            gameService = _gameService;
            LocPro = _loc;
        }

        public Location Location { get; set; }
        //public Connection Connection { get; set; }
        public string Des { get; set; }
        public List<Connection> Directions { get; set; } = new List<Connection>();
        public ActionResult OnGet(Room id)
        {

            gameService.FetchData();

            gameService.State.Previous = gameService.State.Location;

            //gameService.State.Connection = LocPro.GetConnectionsFrom

            //Des = LocPro.GetDescription(LocPro.GetConnectionsFrom(id).FirstOrDefault(),LocPro.GetConnectionsTo(id));

            gameService.State.Location = id;
            
            Location = gameService.Location;
            if(Location.Action != null)
            {
                gameService.State = Location.Action(gameService.State);
            }
            gameService.Store();
            if (!LocPro.IsNavigationLegitimate(gameService.State.Previous, gameService.State.Location, gameService.State))
            {
                
                return RedirectToPage("/Place", new { id = Room.End});
            }
            foreach (var dir in gameService.Directions)
            {
                if(dir.Condition != null)
                {
                    if (dir.Condition(gameService.State) == dir.To)
                    {
                        Directions.Add(dir);
                    }
                }
                
            }
            Directions = gameService.Directions;
    
            return Page();
            
        }
        public void OnPost()
        {

        }
    }
}