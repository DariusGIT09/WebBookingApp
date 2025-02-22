using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBookingApp.Data;
using WebBookingApp.Models;
using System.Threading.Tasks;

namespace WebBookingApp.Controllers
{
    public class AvailableDayController : Controller
    {
        private readonly AppDbContext _context;

        public AvailableDayController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LISTARE (Index)
        public async Task<IActionResult> Index()
        {
            var availableDays = await _context.AvailableDays
                .Include(a => a.Room)
                .ToListAsync();
            return View(availableDays);
        }

        // 2. FORMULAR CREARE (Create - GET)
        public IActionResult Create()
        {
            // Transmitem lista de camere ca SelectList
            ViewBag.Rooms = new SelectList(_context.Rooms, "Id", "Name");
            return View();
        }

        // 2. PROCESARE CREARE (Create - POST)
        [HttpPost]
        public async Task<IActionResult> Create(AvailableDay model)
        {
            // Adăugăm noul obiect în baza de date
            _context.AvailableDays.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // 3. PAGINĂ DE ȘTERGERE (Delete - GET)
        public async Task<IActionResult> Delete(int id)
        {
            var day = await _context.AvailableDays
                .Include(a => a.Room)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (day == null)
                return NotFound();

            return View(day);
        }

        // 3. PROCESARE ȘTERGERE (Delete - POST)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var day = await _context.AvailableDays.FindAsync(id);
            if (day == null)
                return NotFound();

            _context.AvailableDays.Remove(day);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
