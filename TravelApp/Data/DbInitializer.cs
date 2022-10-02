using System;
using System.Linq;
using TravelApp.Models;

namespace TravelApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CountryContext context)
        {
            //Look for any Continents
            if (context.Continents.Any())
            {
                return;
            }

            var continents = new Continent[]
            {
                new Continent
                {
                    ContinentId = "NA",
                    Name = "North America"
                },
                new Continent
                {
                    ContinentId = "EU",
                    Name = "Europe"
                },
                new Continent
                {
                    ContinentId = "AF",
                    Name = "Africa"
                },
                new Continent
                {
                    ContinentId = "SA",
                    Name = "South America"
                },
                new Continent
                {
                    ContinentId = "AU",
                    Name = "Australia and Oceania"
                },
                new Continent
                {
                    ContinentId = "AS",
                    Name = "Asia"
                }
            };

            context.Continents.AddRange(continents);
            context.SaveChanges();

            //Look for any Country
            if (context.Countries.Any())
            {
                return;  //DB has been seeded
            }

            var countries = new Country[]
            {
                new Country
                {
                    ContinentId = "EU",
                    CountryId = "PL",
                    Name = "Poland",
                    AccessToTheSea = true,
                    MountainousTerrain = true,
                    WoodedArea = true,
                    Description = "Country in center of Europe"
                },
                new Country
                {
                    ContinentId = "NA",
                    CountryId = "USA",
                    Name = "United State of America",
                    AccessToTheSea = true,
                    MountainousTerrain = true,
                    WoodedArea = true,
                    Description = "Country in center of North America"
                }
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            if (context.Towns.Any())
            {
                return;
            }

            var towns = new Town[]
            {
                new Town
                {
                    CountryId = "PL",
                    TownId = "KRK",
                    Name = "Krakow",
                    AccessToSea = false,
                    MountainousTerrain = false,
                    WoodedArea = false,
                    HistoricalPlace = true,
                    PlaceWithNature = false
                }
            };

            context.Towns.AddRange(towns);
            context.SaveChanges();

            if (context.Descriptions.Any())
            {
                return;  //DB has been seeded
            }
            var description = new Description[]
            {
                new Description
                {
                    TownID = "KRK",
                    DescriptionId = "1DES",
                    Descripe="",
                    Data= DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    Autor = "Tom"
                }
            };
        }
    }
}
