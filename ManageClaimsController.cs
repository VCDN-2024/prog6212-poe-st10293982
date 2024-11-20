//using Microsoft.AspNetCore.Mvc;
//using Prog6212Part2.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authorization;
//using System.Security.Claims;

//namespace Prog6212Part2.Controllers
//{
//    //[Authorize(Roles = "Coordinator, Manager")]
//    public class ManageClaimsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public ManageClaimsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // Display all pending claims
//        public async Task<IActionResult> Index()
//        {

//        // Retrieve pending claims (i.e., IsApproved == null)
//    var claims = await _context.LecturerClaims
//        .Where(c => c.IsApproved == null)
//        .ToListAsync();

//    return View(claims); // Ensure the corresponding view displays the claims
//    }

//        // Approve a claim
//        [HttpPost]
//        public async Task<IActionResult> ApproveClaim(int id)
//        {
//            var claim = await _context.LecturerClaims.FindAsync(id);
//            if (claim != null)
//            {
//                claim.IsApproved = true;
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        // Reject a claim
//        [HttpPost]
//        public async Task<IActionResult> RejectClaim(int id)
//        {
//            var claim = await _context.LecturerClaims.FindAsync(id);

//            if (claim != null)
//            {
//                claim.IsApproved = false;
//                await _context.SaveChangesAsync();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Prog6212Part2.Data;
using Prog6212Part2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Prog6212Part2.Controllers
{
    public class ManageClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display all pending claims
        public async Task<IActionResult> Index()
        {
            // Retrieve pending claims
            var claims = await _context.LecturerClaims
                .Where(c => c.IsApproved == null)
                .ToListAsync();

            return View(claims);
        }

        // Auto-process claims and show results
        public async Task<IActionResult> AutoProcess()
        {
            var pendingClaims = await _context.LecturerClaims
                .Where(c => c.IsApproved == null)
                .ToListAsync();

            foreach (var claim in pendingClaims)
            {
                if (claim.IsValid)
                {
                    claim.IsApproved = true;
                    claim.ReviewedBy = User.Identity.Name;
                    claim.ReviewedOn = DateTime.Now;
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Approve a claim manually
        [HttpPost]
        public async Task<IActionResult> ApproveClaim(int id)
        {
            var claim = await _context.LecturerClaims.FindAsync(id);

            if (claim != null)
            {
                claim.IsApproved = true;
                claim.ReviewedBy = User.Identity.Name;
                claim.ReviewedOn = DateTime.Now;

                _context.Update(claim);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Reject a claim manually
        [HttpPost]
        public async Task<IActionResult> RejectClaim(int id)
        {
            var claim = await _context.LecturerClaims.FindAsync(id);

            if (claim != null)
            {
                claim.IsApproved = false;
                claim.ReviewedBy = User.Identity.Name;
                claim.ReviewedOn = DateTime.Now;

                _context.Update(claim);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

