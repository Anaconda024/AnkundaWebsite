using AnkundaWebsite2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AnkundaWebsite2.Contracts;
using AnkundaWebsite2.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AnkundaWebsite2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unit;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, IUnitOfWork unit, ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ViewInteracts()
        {
            var interacts = await _unit.Interacts.FindAll();
            var model = _mapper.Map<List<Interact>, List<InteractVM>>(interacts.ToList());
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InteractVM model)
        {
            var session = _mapper.Map<Interact>(model);
            await _unit.Interacts.Create(session);
            await _unit.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var isExists = await _unit.Interacts.isExist(q => q.Id == id);
            if (isExists == false)
            {
                return NotFound();
            }

            var interact = await _unit.Interacts
                .Find(q => q.Id == id);
            var model = _mapper.Map<Interact>(interact);

            return View(model);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)

        {
            try
            {
                var interact = _unit.Interacts.Find(q => q.Id == id).Result;
                if (interact == null)
                {
                    return NotFound();
                }
                _unit.Interacts.Delete(interact);
                await _unit.Save();
                return RedirectToAction(nameof(ViewInteracts));
            }

            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return RedirectToAction(nameof(ViewInteracts));
            }
        }
    }

}
