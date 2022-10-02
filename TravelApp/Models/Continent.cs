using System;
using System.Collections.Generic;

namespace TravelApp.Models
{
    public class Continent
    {
        public string ContinentId { get; set; }
        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
