using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Item
    {
        public string ItemDes { get; set; }
        public Item(string des)
        {
            ItemDes = des;
        }
    }
}

