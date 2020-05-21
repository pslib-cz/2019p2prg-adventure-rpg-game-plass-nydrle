using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Inventory
    {
        public int maxCapacity { get; protected set; }
        public List<Item> items = new List<Item>();
        public Inventory(int maxCapacity)
        {
            maxCapacity = 10;
        }
        public bool AddToInv(Item it)
        {
            if(items.Count < maxCapacity)
            {
                items.Add(it);
                return true;
            }
            return false;
        }
    }
}

