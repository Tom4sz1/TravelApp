using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Data;
using System.ComponentModel.DataAnnotations;
using TravelApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TravelApp.Pages.Forms
{
    [Authorize]
    public class FormCountryModel : PageModel
    {
        public CountryContext _context;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }




        [BindProperty]
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only characters are allowed")]
        public string Name { get; set; }
        [BindProperty]
        public string Des { get; set; }
        [BindProperty]
        public bool AccessToSea { get; set; }
        [BindProperty]
        public bool MountainousTerrain { get; set; }
        [BindProperty]
        public bool WoodedArea { get; set; }
        [BindProperty]
        public bool HistoricalPlace { get; set; }
        [BindProperty]
        public bool PlaceWithNature { get; set; }

        public Description desc;
        public Town town;
        public Town t;
        Random rnd = new Random();

        public Country country;
        public string ContinentId { get; set; }
        

        public FormCountryModel(CountryContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {

            country = await _context.Countries.FirstAsync(c => c.CountryId == Id);
            

            if (!ModelState.IsValid)
            {
                return Page();
            }

            town = new Town
            {
                CountryId = Id,
                TownId = Id + rnd.Next(1000),
                Name = Name,
                AccessToSea = AccessToSea,
                MountainousTerrain = MountainousTerrain,
                WoodedArea = WoodedArea,
                HistoricalPlace = HistoricalPlace,
                PlaceWithNature = PlaceWithNature,
                TownCreator = User.Identity.Name
            };

            desc = new Description
            {
                DescriptionId = Id + "d" + rnd.Next(1000),
                TownID = town.TownId,
                Descripe = Des,
                Autor = User.Identity.Name,
                Data = DateTime.Now.ToString("dddd, dd MMMM yyyy")        
            };

            t = await _context.Towns.FirstOrDefaultAsync(t => t.Name.ToLower() == town.Name.ToLower() && t.CountryId == town.CountryId);

            if (t == null)
            {
                await _context.Towns.AddAsync(town);
                await _context.Descriptions.AddAsync(desc);
                await _context.SaveChangesAsync();
            }
            else
            {
                ViewData["Message"] = "Town already exist! ";
                return Page();
            }
            return RedirectToPage("/Countries/Countries", new { Id = country.CountryId, Name = country.Name });
        }
       
        
    }
}