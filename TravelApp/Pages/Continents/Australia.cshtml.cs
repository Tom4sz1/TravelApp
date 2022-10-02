using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Pages.Continents
{
    public class AustraliaModel : PageModel
    {
        public CountryContext _context;

        public string ContinentID;

        public List<Country> Countries;
        [BindProperty(SupportsGet = true)]
        public Country country1 { get; set; }
        public string CurrentFilter { get; set; }

        public AustraliaModel(CountryContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string searchString)
        {
            ContinentID = "AU";

            CurrentFilter = searchString;

            IQueryable<Country> countryS = from s in _context.Countries
                                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                countryS = countryS.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) && s.ContinentId == ContinentID);
                Countries = await countryS.AsNoTracking().ToListAsync();
            }
            else
            {
                Countries = await countryS.Where(m => m.ContinentId == ContinentID).ToListAsync();
            }
        }
    }
}