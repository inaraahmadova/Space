
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceWeb.DataAccesLayer;
using System.Diagnostics;

namespace SpaceWeb.Controllers
{
    public class HomeController (SpaceContext _context): Controller
    {
       
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Offers.ToListAsync());
        }

    }
}
