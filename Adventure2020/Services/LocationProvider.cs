using Adventure2020.Models;
using Adventure2020.Models.Exceptions;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class LocationProvider : ILocationProvider
    {
        private Dictionary<Room, ILocation> Locations;
        private List<Connection> Map;

        public LocationProvider()
        {
            Locations = new Dictionary<Room, ILocation>();
            Map = new List<Connection>();
            Locations.Add(Room.Start, new Location { Title = "Start", Description = "This is where our story starts." }); // Game starts
            Locations.Add(Room.End, new Location { Title = "Game Over", Description = "All worldly things will one day perish. You just did. Something just killed you.", Action = (gs) => { gs.HP = 0; return gs; }  }); // Game Over
            Locations.Add(Room.Hall, new Location { Title = "Hall", Description = "You stand in seemingly empty hall..." });
            Locations.Add(Room.Library, new Location { Title = "Library", Description = "Library is in utterly desolate state...", FoundItem = new Item("Book", false) });
            Locations.Add(Room.Gallery, new Location { Title = "Gallery", Description = "You are standing on the gallery... But the stairs back to the library had broken already." });
            Locations.Add(Room.Window, new Location { Title = "Window", Description = "You are looking out of the window. The window is locked..." });
            Locations.Add(Room.Bookshelf, new Location { Title = "Bookshelf", Description = "There is just a regular bookshelf. Oh wait, what does this little metal button do?" });
            Locations.Add(Room.HiddenHall, new Location { Title = "Hidden hall", Description = "You clicked the button and the bookshelf opened itself and now you entered a secret hall. It is absolutely dark here. Our hero can not see anything..." });
            Locations.Add(Room.HalfOfTheHall, new Location { Title = "Half of the hidden hall", Description = "Ouch! You have tripped over something! It is a flashlight, what a luck!", Action = (gs) => {  gs.HP--; return gs; } });
            Locations.Add(Room.Flashlight, new Location { Title = "Grabbed FlashLight", Description = "This Flashlight will be really useful!", Action = (gs) => { gs.Inventory.Where(i => i.ItemDescription == "Flashlight").FirstOrDefault().InInvent = true; return gs; } });
            Locations.Add(Room.EndOfTheHall, new Location { Title = "Mysterious End of the dark hall.", Description = "There is something like doorknob..."});
            Locations.Add(Room.Book, new Location { Title = "Grabbed Book", Description = "You got the Holy Bible and put it into your inventory.", Action = (gs) => { gs.Inventory.Where(i => i.ItemDescription == "Book").FirstOrDefault().InInvent = true; return gs; } });
            Locations.Add(Room.Office, new Location { Title = "Fathers Office", Description = "You are standing in your father's office. What has just happened here? The things are broken and some of them are gone! Oh no! I can not go back to the hall! I am stucked here!"});

            Map.Add(new Connection(Room.Start, Room.Hall, "Go to hall"));
            Map.Add(new Connection(Room.Hall, Room.Library, "Visit Library" ));
            Map.Add(new Connection(Room.Library, Room.Hall, "Return to hall"));
            Map.Add(new Connection(Room.Library, Room.Gallery, "Walk up the little stairs in the library to the gallery"));
            Map.Add(new Connection(Room.Gallery, Room.Window, "Go left to look closely at the window"));
            Map.Add(new Connection(Room.Gallery, Room.Bookshelf, "Go right near the bookshelf"));
            Map.Add(new Connection(Room.Window, Room.Gallery, "Turn back"));
            Map.Add(new Connection(Room.Bookshelf, Room.Gallery, "Turn back"));
            Map.Add(new Connection(Room.Bookshelf, Room.HiddenHall, "Push the button", (gs) => { if (gs.Inventory.Where(i => i.ItemDescription == "Book" && i.InInvent == true).Count() > 0 ) return Room.HiddenHall; return Room.Start;}));
            Map.Add(new Connection(Room.HiddenHall, Room.HalfOfTheHall, "Go through the dark hall"));
            Map.Add(new Connection(Room.HalfOfTheHall, Room.Flashlight, "Get the flashlight from the ground"));
            Map.Add(new Connection(Room.Flashlight, Room.HalfOfTheHall, "Continue"));
            Map.Add(new Connection(Room.Library, Room.Book, "Grab the book"));
            Map.Add(new Connection(Room.Book, Room.Library, "Keep Going!"));
            Map.Add(new Connection(Room.HiddenHall, Room.End, "Die"));
            Map.Add(new Connection(Room.HalfOfTheHall, Room.EndOfTheHall, "Go to the end of the hall."));
            Map.Add(new Connection(Room.EndOfTheHall, Room.Office, "Open the door on the end of the secret hall.", (gs) => { if (gs.Inventory.Where(i => i.ItemDescription == "Flashlight" && i.InInvent == true).Count() > 0) return Room.Office; return Room.EndOfTheHall; }));
            Map.Add(new Connection(Room.EndOfTheHall, Room.End, "Die"));
        }

        public bool ExistsLocation(Room id)
        {
            return Locations.ContainsKey(id);
        }

        public List<Connection> GetConnectionsFrom(Room id)
        {
            if (ExistsLocation(id))
            {
                return Map.Where(m => m.From == id).ToList();
            }
            throw new InvalidLocation();
        }

        public List<Connection> GetConnectionsTo(Room id)
        {
            if (ExistsLocation(id))
            {
                return Map.Where(m => m.To == id).ToList();
            }
            throw new InvalidLocation();
        }

        public Location GetCurrentLocation(Room id)
        {
            if (ExistsLocation(id))
            {
                return (Location)Locations[id];
            }
            throw new InvalidLocation();
        }

        public bool IsNavigationLegitimate(Room from, Room to, GameState gs)
        {
            var back = Map.Where(m => (m.To == to) && (m.From == from)).FirstOrDefault();
            if(back != null)
            {
                if (back.Condition != null)
                {
                    return back.Condition(gs) == to;
                }
                return true;
            }

            
            return false;
            //Map.Where(m => (m.To == to) && (m.From == from)).ToList().Count > 0;
        }
        public string GetDescription(Room from, Room to)
        {
            return Map.Where(m => (m.To == to) && (m.From == from)).FirstOrDefault().Description;
        }
    }
}
