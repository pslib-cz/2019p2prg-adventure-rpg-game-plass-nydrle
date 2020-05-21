using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Services
{
    public class GameService
    {
        private readonly ISessionStorage<GameState> SessionStorage;
        private readonly ILocationProvider LocationProvider;
        private const string KEY = "AmazingAdventure";
        private const Room START_ROOM = Room.Start;
        public GameState State { get; private set; }
        public Location Location { get { return LocationProvider.GetCurrentLocation(State.Location); } }
        public List<Connection> Directions { get { return LocationProvider.GetConnectionsFrom(State.Location); } }

        public GameService(ISessionStorage<GameState> _sessionStorage, ILocationProvider _locationProvider)
        {
            SessionStorage = _sessionStorage;
            LocationProvider = _locationProvider;
            State = new GameState();
        }

        public void Start()
        {
            State = new GameState { HP = 10, Location = START_ROOM, Inventory = new List<Item> { { new Item("Knife", true, 1) }, { new Item("Key", false, 0) }, { new Item("Book", false, 0) }, { new Item("Flashlight", false, 0) }, { new Item("Heal Potion", false, 0)} } };
            Store();
        }

        public void FetchData()
        {
            State = SessionStorage.LoadOrCreate(KEY);
        }

        public void Store()
        {
            SessionStorage.Save(KEY, State);
        }
    }
}
