using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBookingApp.Data;
using WebBookingApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace WebBookingApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LISTĂ (Index)
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .ToListAsync();
            return View(bookings);
        }

        // 2. FORMULAR CREARE (Create - GET)
        public IActionResult Create()
        {
            // Lista de camere (pentru dropdown)
            ViewBag.Rooms = new SelectList(_context.Rooms, "Id", "Name");
            // Lista de useri (pentru dropdown)
            ViewBag.Users = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // 2. PROCESARE CREARE (Create - POST)
        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // 3. PAGINĂ DE ȘTERGERE (Delete - GET)
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // 3. PROCESARE ȘTERGERE (DeleteConfirmed - POST)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
