using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Location : ILocation
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Item FoundItem { get; set; }
    }

    public bool FindItem() // not working at the moment
    {
        if (!GameState.Contains(FoundItem))
        {
            GameState.Items.Add(FoundItem);
            return true;
        }

        return false;
    }
}
