using Exam.Data;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class GuestsController : Controller
    {
        private readonly AppDbContext _context;
        public GuestsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data =_context.Guests.ToList();
            return View(data);
        }
    }
}
