using System;
using System.Collections.Generic;

namespace TravelApp.Models
{
    public class Country
    {
        public string ContinentId { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
        public bool AccessToTheSea { get; set; }
        public bool MountainousTerrain { get; set; }
        public bool WoodedArea { get; set; }
        public string Description { get; set; }

        public Continent Continent { get; set; }
        public ICollection<Town> Towns { get; set; }
    }
}
