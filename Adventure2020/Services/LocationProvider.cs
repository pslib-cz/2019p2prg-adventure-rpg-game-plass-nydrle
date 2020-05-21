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
            Locations.Add(Room.End, new Location { Title = "Game Over", Description = "All worldly things will one day perish. You just did." }); // Game Over
            Locations.Add(Room.Hall, new Location { Title = "Hall", Description = "You stand in seemingly empty hall..." });
            Locations.Add(Room.Library, new Location { Title = "Library", Description = "Library is in utterly desolate state..." });
            Locations.Add(Room.Gallery, new Location { Title = "Gallery", Description = "You are standing on the gallery... But the stairs back to the library had broken already." });
            Locations.Add(Room.Window, new Location { Title = "Window", Description = "You are looking out of the window. The window is locked..." });
            Locations.Add(Room.Bookshelf, new Location { Title = "Bookshelf", Description = "There is just a regular bookshelf. Oh wait, what does this little metal button do?" });
            Locations.Add(Room.HiddenHall, new Location { Title = "Hidden hall", Description = "You clicked the button and the bookshelf opened itself and now you entered a secret hall." });
            Locations.Add(Room.Key, new Location { Title = "Key", Description = "You got the key and put it into your inventory." });

            Map.Add(new Connection(Room.Start, Room.Hall, "Go to hall"));
            Map.Add(new Connection(Room.Hall, Room.Library, "Visit Library", (gs) => { if (gs.HP > 10) return true; return false; }));
            Map.Add(new Connection(Room.Library, Room.Hall, "Return to hall"));
            Map.Add(new Connection(Room.Library, Room.Gallery, "Walk up the little stairs in the library to the gallery"));
            Map.Add(new Connection(Room.Gallery, Room.Window, "Go left to look closely at the window"));
            Map.Add(new Connection(Room.Gallery, Room.Bookshelf, "Go right near the bookshelf"));
            Map.Add(new Connection(Room.Window, Room.Gallery, "Turn back"));
            Map.Add(new Connection(Room.Bookshelf, Room.Gallery, "Turn back"));
            Map.Add(new Connection(Room.Bookshelf, Room.HiddenHall, "Push the button"));
            Map.Add(new Connection(Room.HiddenHall, Room.Key, "Get the key from the ground"));
            Map.Add(new Connection(Room.Key, Room.HiddenHall, "Continue"));

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

        public bool IsNavigationLegitimate(Room from, Room to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
