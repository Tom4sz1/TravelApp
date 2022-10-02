using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApp.Models
{
    public class Town
    {
        public string CountryId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TownId { get; set; }
        public string Name { get; set; }
        public bool AccessToSea { get; set; }
        public bool MountainousTerrain { get; set; }
        public bool WoodedArea { get; set; }
        public bool HistoricalPlace { get; set; }
        public bool PlaceWithNature { get; set; }
        public string TownCreator { get; set; }


        public Country Country { get; set; }
        public ICollection<Description> Descriptions {get; set;} 
    }
}
