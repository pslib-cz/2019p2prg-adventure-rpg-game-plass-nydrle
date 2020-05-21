using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class LocationProvider : ILocationProvider
    {
        private Dictionary<int, Location> _locations;
        private List<Connection> _map = new List<Connection>();

        public LocationProvider()
        {
            GameState gs = new GameState();
            _locations = new Dictionary<int, Location>();
            _map = new List<Connection>();
            _locations.Add(0, new Location { Description = "This is where our story starts." }); // Game starts
            _locations.Add(1, new Location { Description = "All worldly things will one day perish. You just did." }); // Game Over
            _locations.Add(2, new Location { Description = "You stand in seemingly empty hall ..." });
            _locations.Add(3, new Location { Description = "Library is in utterly desolate state, you can take some books :) ..." });
            _locations.Add(4, new Location {Description = "You are standing on the GALLERY..."});
            _locations.Add(5, new Location {Description = "You are looking out of the window. The window is locked ..."});
            _locations.Add(6, new Location {Description = "There is just a regular bookshelf. Oh wait, what does this little metal button?"});
            _locations.Add(7, new Location {Description = "" });
            _map.Add(new Connection(0, 2, "Go to hall"));
            _map.Add(new Connection(2, 3, "Visit Library", (gs) => { if (gs.HP > 10) return true; return false; }));
            _map.Add(new Connection(3,4, "Walk up the little stairs in the library to the gallery"));
            _map.Add(new Connection(4,5,"Go left to look closely at the window")); // s oknem pak půjde něco udělat
            _map.Add(new Connection(4,6, "Go to the right to see the end of the gallery"));
            //_map.Add(new Connection(6,7, "Push the button and go to the secret room", (gs) =>{if(gs.IsItemInHand("item") == true)}
        }

        public bool ExistsLocation(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Connection> GetConnectionsFrom(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Connection> GetConnectionsTo(int id)
        {
            throw new NotImplementedException();
        }

        public ILocation GetLocation(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsNavigationLegit(int from, int to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}
