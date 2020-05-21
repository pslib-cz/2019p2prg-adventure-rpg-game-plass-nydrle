using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    interface ILocationProvider
    {
        bool ExistsLocation(int id);

        ILocation GetLocation(int id);

        IList<Connection> GetConnectionsFrom(int id);

        IList<Connection> GetConnectionsTo(int id);

        bool IsNavigationLegit(int from, int to, GameState state);
    }
}
