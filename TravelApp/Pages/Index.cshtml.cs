using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Pages.Shared.Middware;

namespace TravelApp.Pages
{

    public class IndexModel : PageModel
    {
        [BindProperty]
        public string ContinentId { get; set; }
        public SelectList Continents { get; set; }

        RouteContinent Route = new RouteContinent();

        CountryContext _context;

        public IndexModel(CountryContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            
        }


       

    }
}
