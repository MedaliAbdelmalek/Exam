using Exam.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class LocationsController : Controller
    {
        private readonly AppDbContext _context;
        public LocationsController(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {
            var allLocations = await _context.Locations.ToListAsync();
            return View(allLocations);
        }
    }
}
