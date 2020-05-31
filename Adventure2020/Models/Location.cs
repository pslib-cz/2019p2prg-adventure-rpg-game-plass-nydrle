﻿using System;
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
        public Func<GameState, GameState> Action { get; set; }
    }
}
