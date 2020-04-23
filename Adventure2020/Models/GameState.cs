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
        public bool AddToInv(Item it)
        {
            if(items.Count < maxCapacity)
            {
                items.Add(it);
                return true;
            }
            return false;
        }
        public void SelectItem(Item item) // Select item from inventory to the hand.
        {
            if(hand.Count == 0){
                items.Add(helpItem);
                hand.Add(item);
            }
            else
            {                
            Item helpItem = hand[0];
            hand.Clear();
            items.Add(helpItem);
            hand.Add(item);
            return true;
            }
        }
        public bool IsItemInHand(Item item)
        {
            if (item == hand[0])
            {
            return true;
            }
            return false;
        }
    }
}
