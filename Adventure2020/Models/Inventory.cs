using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Inventory
    {
        public int MaxCapacity { get; protected set; }
        public List<Item> Items = new List<Item>();
        public Inventory(int maxCapacity)
        {
            maxCapacity = 10;
        }
        public bool AddToInventory(Item it)
        {
            if (Items.Count < MaxCapacity && Items.Contains(it))
            {
                Items.Add(it);
                return true;
            }
            return false;
        }
    }
}

