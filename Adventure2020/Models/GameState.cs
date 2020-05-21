﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class GameState
    {
        public int HP { get; set; }
        public Room Location { get; set; }
        public int MaxInventoryCapacity { get; set; }

        public List<Item> Items = new List<Item>();

        public Item Hand;
    }
}
