using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using MyMVCapp.Data;
using Microsoft.EntityFrameworkCore;
using MyMVCapp.Models;

namespace MvcMovie.Controllers;

public class TicketsController : Controller
{
        private readonly MyMVCappContext _context;

        public TicketsController(MyMVCappContext context)
        {
            _context = context;
        }

        // GET: Spectacle
        public async Task<IActionResult> Index()
        {
              return _context.Spectacle != null ? 
                          View(await _context.Spectacle.ToListAsync()) :
                          Problem("Entity set 'MyMVCappContext.Spectacle'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spectacle == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacle
                .FirstOrDefaultAsync(m => m.SpectacleID == id);
            if (spectacle == null)
            {
                return NotFound();
            }

            ViewBag.var1 = await _context.Spectacle.ToListAsync();

            return View(spectacle);
        }
//     public IActionResult Index()
// {
//     return View();
// }

}