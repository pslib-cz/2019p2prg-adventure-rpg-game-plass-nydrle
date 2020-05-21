using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Item
    {
        public string ItemDescription { get; set; }
        public bool IsInHand { get; set; }
        public int Counter { get; set; }
        public Item(string _description, bool _inHand, int _count)
        {
            ItemDescription = _description;
            IsInHand = _inHand;
            Counter = _count;
        }
    }
}

