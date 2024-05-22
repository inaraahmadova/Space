using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceWeb.DataAccesLayer;
using SpaceWeb.Models;
using SpaceWeb.ViewModels;

namespace SpaceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController(SpaceContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Offers> offer= await _context.Offers.ToListAsync();
            return View(offer);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSpaceVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            };
            await _context.Offers.AddAsync(new Offers
            {
                Title = vm.Title,
                Profession = vm.Profession,
                ImageUrl = vm.ImageUrl
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Offers offers=await _context.Offers.FirstOrDefaultAsync(x=>x.Id == id);
            if (offers == null) return NotFound();
            return View(offers);
        }
        [HttpPost]

        public async Task<IActionResult> Update(int? id,CreateSpaceVM vm)
        {
            if(id == null || id < 1) return BadRequest();
            Offers existed = await _context.Offers.FirstOrDefaultAsync(x => x.Id == id);
            if (existed == null) return NotFound();
            existed.Title = vm.Title;
            existed.ImageUrl = vm.ImageUrl;
            existed.Profession = vm.Profession;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Offers offers = await _context.Offers.FirstOrDefaultAsync(x => x.Id == id);
            if (offers == null) return NotFound();
            _context.Remove(offers);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
