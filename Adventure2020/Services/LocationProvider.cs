using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class LocationProvider : ILocationProvider
    {
        public Dictionary<int, Location> Locations;
        public List<Connection> Map; // list of connections

        public LocationProvider()
        {
            GameState gs = new GameState();
            Locations = new Dictionary<int, Location>();
            Map = new List<Connection>();
            Locations.Add(0, new Location { Description = "This is where our story starts." }); // Game starts
            Locations.Add(1, new Location { Description = "All worldly things will one day perish. You just did." }); // Game Over
            Locations.Add(2, new Location { Description = "You stand in seemingly empty hall ..." });
            Locations.Add(3, new Location { Description = "Library is in utterly desolate state, you can take some books :) ..." });
            Locations.Add(4, new Location { Description = "You are standing on the GALLERY..."});
            Locations.Add(5, new Location { Description = "You are looking out of the window. The window is locked ..."});
            Locations.Add(6, new Location { Description = "There is just a regular bookshelf. Oh wait, what does this little metal button?"});
            Locations.Add(7, new Location { Description = "" });

            Map.Add(new Connection(0, 2, "Go to hall"));
            Map.Add(new Connection(2, 3, "Visit Library", (gs) => { if (gs.HP > 10) return true; return false; }));
            Map.Add(new Connection(3, 4, "Walk up the little stairs in the library to the gallery"));
            Map.Add(new Connection(4, 5, "Go left to look closely at the window")); // s oknem pak půjde něco udělat
            Map.Add(new Connection(4, 6, "Go to the right to see the end of the gallery"));
            //_map.Add(new Connection(6,7, "Push the button and go to the secret room", (gs) =>{if(gs.IsItemInHand("item") == true)}
        }

        public bool ExistsLocation(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Connection> GetConnectionsFrom(int id)
        {
            var _connections = new List<Connection>();
            foreach(var i in Map)
            {
                if (id == i.From)
                {
                    _connections.Add(i);
                }
            }
            return _connections;
        }

        public IList<Connection> GetConnectionsTo(int id)
        {
            var _connections = new List<Connection>();
            foreach (var i in Map)
            {
                if (id == i.To)
                {
                    _connections.Add(i);
                }
            }
            return _connections;
        }

        public ILocation GetLocation(int id)
        {
            return Locations[id];
        }

        public bool IsNavigationLegit(int from, int to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
