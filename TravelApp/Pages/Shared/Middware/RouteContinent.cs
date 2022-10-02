using System;
namespace TravelApp.Pages.Shared.Middware
{
    public class RouteContinent
    {
        public RouteContinent()
        {
        }

        public string RouteLink(string ContinentId)
        {
            switch (ContinentId)
            {
                case "NA":
                    return "/Continents/NorthAmerica";
                case "SA":
                    return "/Continents/SouthAmerica";
                case "EU":
                    return "/Continents/Europe";
                case "AU":
                    return "/Continents/Australia";
                case "AS":
                    return "/Continents/Asia";
                case "AF":
                    return "/Continents/Africa";
                default:
                    return "/Index";
            }
        }

        
    }
}
