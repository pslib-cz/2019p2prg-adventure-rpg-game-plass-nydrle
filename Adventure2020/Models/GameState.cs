using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class GameState
    {
        [BindProperty]
        public int HP { get; set; }
        [BindProperty]
        public Room Location { get; set; }
        [BindProperty]
        public int MaxInventoryCapacity { get; set; }

        public List<Item> Items = new List<Item>();

        public Item Hand;
        public string Name { get; set; }
    }
}
