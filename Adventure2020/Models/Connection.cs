using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventure2020.Models
{
    public class Connection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="from">Id of location we want to leave.</param>
        /// <param name="to">Id of location we want to enter.</param>
        /// <param name="description">Room description.</param>
        /// <param name="condition">Additional condition required for succesfull movement.</param>
        public Connection(int from, int to, string description, Func<GameState, bool> condition = null)
        {
            From = from;
            To = to;
            Description = description;
            Condition = condition;
        }

        public int From { get; set; }
        public int To { get; set; }
        public string Description { get; set; }
        public Func<GameState, bool> Condition { get; set; }
    }
}
