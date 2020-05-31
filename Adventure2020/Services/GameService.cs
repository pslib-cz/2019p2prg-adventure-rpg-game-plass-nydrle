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
        public GameState State { get; set; }
        public Location Location { get { return LocationProvider.GetCurrentLocation(State.Location); } }

        //public Connection Connection { get { return} }
        public List<Connection> Directions { get { return LocationProvider.GetConnectionsFrom(State.Location); } }

        public GameService(ISessionStorage<GameState> _sessionStorage, ILocationProvider _locationProvider)
        {
            SessionStorage = _sessionStorage;
            LocationProvider = _locationProvider;
            State = new GameState { HP = 10, Mana = 10,Previous = START_ROOM, Location = START_ROOM, Inventory = new List<Item> { { new Item("Knife", true) }, { new Item("Key", false) }, { new Item("Book", false) }, { new Item("Flashlight", false) }, { new Item("Heal Potion", false) } } };
        }

        public void Start()
        {
            
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
