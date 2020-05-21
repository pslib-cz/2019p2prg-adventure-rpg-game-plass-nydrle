using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class GameState
    {
        public int HP { get; }
        public int maxCapacity { get; protected set; }
        public List<Item> items = new List<Item>();
        public List<Item> hand = new List<Item>();
        
    }
}
