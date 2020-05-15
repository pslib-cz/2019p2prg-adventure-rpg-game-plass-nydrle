using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Item
    {
        public string ItemDes { get; set; }
        public bool IsInHand { get; set; }
        public int Counter { get; set; }
        public Item(string des, bool inH, int count)
        {
            ItemDes = des;
            IsInHand = inH;
            Counter = count;
        }
    }
}

