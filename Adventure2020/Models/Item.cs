using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Item
    {
        [BindProperty]
        public string ItemDescription { get; set; }
        [BindProperty]
        public bool InInvent { get; set; }
        [BindProperty]
        public int Counter { get; set; }
        public Item(string _description, bool InInvent)
        {
            ItemDescription = _description;
            this.InInvent = InInvent;
        }
    }
}

