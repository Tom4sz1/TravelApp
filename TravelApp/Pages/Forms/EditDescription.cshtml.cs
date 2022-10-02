using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Pages.Forms
{
    [Authorize]
    public class EditDescriptionModel : PageModel
    {
        public CountryContext _context;

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty(SupportsGet =true)]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        public string Desc { get; set; }
        public string cos;

        public Description description;
        public Town town;
        Random rnd = new Random();

        public EditDescriptionModel(CountryContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {

            town = await _context.Towns.FirstOrDefaultAsync(t => t.TownId == Id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            description = new Description
            {
                DescriptionId = Id + "d" + rnd.Next(1000),
                TownID = Id,
                Descripe = Desc,
                Autor = User.Identity.Name,
                Data = DateTime.Now.ToString("dddd, dd MMMM yyyy")

            };

            await _context.Descriptions.AddAsync(description);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Towns/Towns", new {Name = Name, Id = town.CountryId});
        }
    }
}