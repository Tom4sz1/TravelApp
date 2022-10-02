using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Pages.Shared.Middware;

namespace TravelApp.Pages.Towns
{
    public class TownsModel : PageModel
    {
        public CountryContext _context;
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet =true)]
        public string id { get; set; }
        
        public List<Description> Descriptions1; 
        public Town Town;
        public Country Country;
        public Continent Continents;
        public string ContinentID;
        public string ContinentName;
        public string RouterString;

        RouteContinent Route = new RouteContinent();

        public TownsModel(CountryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if(Name == null)
            {
                return NotFound();
            }

            Country = await _context.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
            Town = await _context.Towns.FirstOrDefaultAsync(t => t.Name == Name);
            Continents = await _context.Continents.FirstOrDefaultAsync(co => co.ContinentId == ContinentID);
            Descriptions1 = await _context.Descriptions.Where(des => des.TownID == Town.TownId).ToListAsync();
            RouterString = Route.RouteLink(Country.ContinentId);


            if (Town == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}