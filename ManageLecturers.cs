using Microsoft.AspNetCore.Mvc;
using Prog6212Part2.Data;
using Prog6212Part2.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Prog6212Part2.Controllers
{
    public class ManageLecturersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageLecturersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all lecturers
        public async Task<IActionResult> Index()
        {
            var lecturers = await _context.Lecturers.ToListAsync();
            return View(lecturers);
        }

        // Edit lecturer details
        public async Task<IActionResult> Edit(string id)
        {
            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer == null) return NotFound();

            return View(lecturer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Lecturer lecturer)
        {
            if (!ModelState.IsValid) return View(lecturer);

            _context.Lecturers.Update(lecturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Delete a lecturer
        public async Task<IActionResult> Delete(string id)
        {
            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer == null) return NotFound();

            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
