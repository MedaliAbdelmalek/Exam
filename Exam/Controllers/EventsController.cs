using Exam.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        public EventsController(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {
            var allEvents = await _context.Events.Include(n => n.Location).ToListAsync();
            return View(allEvents);
        }
    }
}
