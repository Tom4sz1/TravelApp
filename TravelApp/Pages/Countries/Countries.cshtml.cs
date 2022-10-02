using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Pages.Countries
{
    public class CountriesModel : PageModel
    {
        public CountryContext _context;
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public List<Town> Towns;
        public Country Country;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public CountriesModel(CountryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = "No Country";
            } 

            Towns = await _context.Towns.Where(t => t.CountryId == Id).ToListAsync();
            Country = await _context.Countries.FirstOrDefaultAsync(c => c.CountryId == Id);

            return Page();
        }
    }
}