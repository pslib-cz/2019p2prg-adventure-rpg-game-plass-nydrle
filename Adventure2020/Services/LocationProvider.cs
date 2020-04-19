using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class LocationProvider : ILocationProvider
    {
        private Dictionary<int, ILocation> _locations;
        private List<Connection> _map;

        public LocationProvider()
        {
            _locations = new Dictionary<int, ILocation>();
            _map = new List<Connection>();
            _locations.Add(0, new Location { Description = "This is where our story starts." }); // Game starts
            _locations.Add(1, new Location { Description = "All worldly things will one day perish. You just did." }); // Game Over
            _locations.Add(2, new Location { Description = "You stand in seemingly empty hall ..." });
            _locations.Add(3, new Location { Description = "Library is in utterly desolate state ..." });
            _map.Add(new Connection(0, 2, "Go to hall"));
            _map.Add(new Connection(2, 3, "Visit Library", (gs) => { if (gs.HP > 10) return true; return false; }));
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
