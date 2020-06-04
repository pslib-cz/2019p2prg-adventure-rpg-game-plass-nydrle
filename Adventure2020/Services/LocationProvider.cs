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
            Locations.Add(Room.Start, new Location { Title = "Start", Description = "This is where our story starts.", Action = (gs) => { gs.HP = 10; gs.Energy = 10; return gs; } }); // Game starts
            Locations.Add(Room.End, new Location { Title = "Game Over", Description = "All worldly things will one day perish. You just did. Something just killed you.", Action = (gs) => { gs.HP = 0; return gs; } }); // Game Over
            Locations.Add(Room.Hall, new Location { Title = "Hall", Description = "You stand in seemingly empty hall..." });
            Locations.Add(Room.Library, new Location { Title = "Library", Description = "Library is in utterly desolate state...", FoundItem = new Item("Book", false), Action = (gs) => { gs.Energy--; return gs; } });
            Locations.Add(Room.Gallery, new Location { Title = "Gallery", Description = "You are standing on the gallery... But the stairs back to the library had broken already.", Action = (gs) => { gs.Energy--; return gs; } });
            Locations.Add(Room.Window, new Location { Title = "Window", Description = "You are looking out of the window. The window is locked...", Action = (gs) => { gs.Energy--; return gs; } });
            Locations.Add(Room.Bookshelf, new Location { Title = "Bookshelf", Description = "There is just a regular bookshelf. Oh wait, what does this little metal button do?", Action = (gs) => { gs.Energy--; return gs; } });
            Locations.Add(Room.HiddenHall, new Location { Title = "Hidden hall", Description = "You clicked the button and the bookshelf opened itself and now you entered a secret hall. It is absolutely dark here. Our hero can not see anything...", Action = (gs) => { gs.Energy--; return gs; } });
            Locations.Add(Room.HalfOfTheHall, new Location { Title = "Half of the hidden hall", Description = "Ouch! You have tripped over something! It is a flashlight, what a luck!", Action = (gs) => { gs.HP--; return gs; } });
            Locations.Add(Room.Flashlight, new Location { Title = "Grabbed FlashLight", Description = "This Flashlight will be really useful!", Action = (gs) => { gs.Inventory.Where(i => i.ItemDescription == "Flashlight").FirstOrDefault().InInvent = true; return gs; } });
            Locations.Add(Room.EndOfTheHall, new Location { Title = "Mysterious End of the dark hall.", Description = "There is something like doorknob...", Action = (gs) => { gs.Energy--; return gs; } });
            Locations.Add(Room.Book, new Location { Title = "Grabbed Book", Description = "You got the Holy Bible and put it into your inventory.", Action = (gs) => { gs.Inventory.Where(i => i.ItemDescription == "Book").FirstOrDefault().InInvent = true; return gs; } });
            Locations.Add(Room.Office, new Location { Title = "Fathers Office", Description = "You are standing in your father's office. What has just happened here? The things are broken and some of them are gone! Oh no! I can not go back to the hall! I am stucked here! The only one thing you can do is take a nap...", Action = (gs) => { gs.Energy--; return gs; } });
            Locations.Add(Room.Nap, new Location { Title = "Zzzzzzz...", Description = "A little nap will maybe help you.", Action = (gs) => { gs.HP = 10; gs.Energy = 10; return gs; } });
            Locations.Add(Room.Whiskey, new Location { Title = "Oopa!", Description = "A shot of Irish one will help you too.", Action = (gs) => { gs.HP = 10; gs.Energy = 0; return gs; } });
            Locations.Add(Room.OfficeM, new Location { Title = "Fathers Office In The Morning", Description = "What a beautiful morning! All of the doors ale locked. Oh, I have an idea!" });
            Locations.Add(Room.UseTheTable, new Location { Title = "Tha table or ram?", Description = "You agressively grabbed the table and gently banged it into the doors which leads to the kitchen.", Action = (gs) => { gs.Energy -= 7; return gs; } });
            Locations.Add(Room.UsedTable, new Location { Title = "Destroyed door", Description = "The table has destroyed the door. Good job! You should take another nap before you go..." });
            Locations.Add(Room.AfterWhiskey, new Location { Title = "An emty glass", Description = "You are too drunk to make up any plans! You should rest a while." });
            Locations.Add(Room.Nap2, new Location { Title = "Zzzzzzz...", Description = "A little nap will maybe help you.", Action = (gs) => { gs.HP = 10; gs.Energy = 10; return gs; } });
            Locations.Add(Room.Kitchen, new Location { Title = "The old kitchen", Description = "There is a Heal Potion on a desk, nothing special.", FoundItem = new Item("Heal Potion", false), Action = (gs) => { gs.Energy -= 1; return gs; } });
            Locations.Add(Room.Heal, new Location { Title = "Grabbed Heal Potion", Description = "You got the Heal Potion and put it into your inventory.", Action = (gs) => { gs.Inventory.Where(i => i.ItemDescription == "Heal Potion").FirstOrDefault().InInvent = true; return gs; } });
            Locations.Add(Room.Terrase, new Location { Title = "Terrase by the kitchen", Description = "You are standing outside the building on the terrase. Wait... Who are these guys in black? Why are they murdering our employees?", Action = (gs) => { gs.Energy += 2; return gs; } });
            Locations.Add(Room.Run, new Location { Title = "Esaped", Description = "You have succesfully escaped with some injuries. You should heal yourself. You have hidden by the corner of the shed. Here your father has a hidden Desert Eagle", Action = (gs) => { gs.Energy -= 2; gs.HP = 2; return gs; } });
            Locations.Add(Room.Shout, new Location { Title = "Conflict accepted", Description = "At the same moment you shouted at them, they shoot at you. Bad idea. Maybe next time buddy...", Action = (gs) => { gs.HP = 0; gs.Energy = 0; return gs; } });
            Locations.Add(Room.Hide, new Location { Title = "Hiden by the stairs", Description = "You are hiding behind the stairs wchich leads down to the bloody garden. One of these guys is walking directly to you, he does not see you.", Action = (gs) => { gs.Energy = 10; return gs; } });
            Locations.Add(Room.Kill1, new Location { Title = "Enemy 1 Killed", Description = "You have silently killed him with your knife. The body is hidden by you behind the stairs...", Action = (gs) => { gs.Energy--;  return gs; } });
            Locations.Add(Room.Panic, new Location { Title = "Panic starts", Description = "You started crying like a little girl. He peacefuly shoot you right into your head. Really bad idea...", Action = (gs) => { gs.Energy = 0; gs.HP = 0; return gs; } });
            Locations.Add(Room.End1, new Location { Title = "The End", Description = "You did not saved your employees and your father. The police is working on this. This is not really nice of you. Shame on you, coward." });
            Locations.Add(Room.Gate1, new Location { Title = "The Gate", Description = "Here is your last enemy. You can ignore him and go or kill him & go" });
            Locations.Add(Room.Kill2, new Location { Title = "The End", Description = "You have silently killed him with your knife. You did not saved your employees and your father. The police is working on this. This is not really nice of you. Shame on you, coward." });
            Locations.Add(Room.Gun, new Location { Title = "Grabbed Gun", Description = "Now you have a Desert Eagle!", Action = (gs) => { gs.Inventory.Where(i => i.ItemDescription == "Desert Eagle").FirstOrDefault().InInvent = true; return gs; } });
            Locations.Add(Room.Shoot, new Location { Title = "The final dramatic shootout", Description = "The fight war really hard just like in action movies. You have got so many injuries. Now you are in a hospital. You saved yout father and the police is working on this crime. Congratulations!" });
            Locations.Add(Room.TakeHeal, new Location { Title = "Doc", Description = "You are OK now.", Action = (gs) => { gs.HP = 10;gs.Energy = 10; gs.Inventory.Where(i => i.ItemDescription == "Heal Potion").FirstOrDefault().InInvent = false; return gs; } }); ;

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
            Map.Add(new Connection(Room.Office, Room.End, "Die"));
            Map.Add(new Connection(Room.Office, Room.Nap, "Take a nap"));
            Map.Add(new Connection(Room.Office, Room.Whiskey, "Take a shot of whiskey"));
            Map.Add(new Connection(Room.Nap, Room.OfficeM, "Wake up and continue"));
            Map.Add(new Connection(Room.Whiskey, Room.AfterWhiskey, "Stop drinking and continue"));
            Map.Add(new Connection(Room.OfficeM, Room.UseTheTable, "Use The table as a ram!"));
            Map.Add(new Connection(Room.AfterWhiskey, Room.Nap, "Take probably last nap"));
            Map.Add(new Connection(Room.UseTheTable, Room.UsedTable, "Lets go outta there!"));
            Map.Add(new Connection(Room.UsedTable, Room.Nap2, "Take another nap"));
            Map.Add(new Connection(Room.Nap2, Room.Kitchen, "Go to the kitchen"));
            Map.Add(new Connection(Room.Kitchen, Room.Heal, "Get the Heal"));
            Map.Add(new Connection(Room.Heal, Room.Kitchen, "Continue"));
            Map.Add(new Connection(Room.Kitchen, Room.Terrase, "Go outside"));
            Map.Add(new Connection(Room.Terrase, Room.Kitchen, "Go inside"));
            Map.Add(new Connection(Room.Terrase, Room.Shout, "Shout at them"));
            Map.Add(new Connection(Room.Shout, Room.Start, "New Game"));
            Map.Add(new Connection(Room.End, Room.Start, "New Game"));
            Map.Add(new Connection(Room.Terrase, Room.Run, "Run out of the area"));//
            Map.Add(new Connection(Room.Terrase, Room.Hide, "Hide"));
            Map.Add(new Connection(Room.Hide, Room.Kill1, "Sneaky peaky kill him."));
            Map.Add(new Connection(Room.Kill1, Room.Gate1, "Go to the gate."));
            Map.Add(new Connection(Room.Hide, Room.Panic, "Start panic"));
            Map.Add(new Connection(Room.Panic, Room.Start, "New Game"));
            Map.Add(new Connection(Room.Gate1, Room.Kill2, "Kill him & go"));
            Map.Add(new Connection(Room.Gate1, Room.Ignore, "Ignore him & go"));
            Map.Add(new Connection(Room.Ignore, Room.Start, "New Game"));
            Map.Add(new Connection(Room.Kill2, Room.Start, "New Game"));
            Map.Add(new Connection(Room.Run, Room.Gun, "Take the gun!"));
            Map.Add(new Connection(Room.Run, Room.TakeHeal, "Heal yourself"));
            Map.Add(new Connection(Room.TakeHeal, Room.Shoot, "Breath in & out... Action!"));
            Map.Add(new Connection(Room.Gun, Room.Shoot, "Kill all of them!", (gs) => { if (gs.Inventory.Where(i => i.ItemDescription == "Heal Potion" && i.InInvent == false).Count() > 0) return Room.Shoot; return Room.End; }));
            Map.Add(new Connection(Room.Gun, Room.Gate1, "To the gate"));
            Map.Add(new Connection(Room.Shoot, Room.End, "Die"));

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
