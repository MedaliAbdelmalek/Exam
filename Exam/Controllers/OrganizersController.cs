using Exam.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly AppDbContext _context;
        public OrganizersController(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {
            var allOrganizers =await _context.Organizers.ToListAsync();
            return View(allOrganizers);
        }
    }
}
