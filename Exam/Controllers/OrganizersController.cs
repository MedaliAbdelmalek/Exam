using Exam.Data;
using Exam.Data.Services;
using Exam.Data.Static;
using Exam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class OrganizersController : Controller
    {
        private readonly IOrganizersService _service;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public OrganizersController(IOrganizersService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _hostingEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allOrganizers = await _service.GetAllAsync();
            return View(allOrganizers);
        }

        //GET: organizers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        //GET: organizers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Organizer organizer, IFormFile ProfilePictureURL)
        {
            ModelState.Remove("ProfilePictureURL");
            ModelState.Remove("Events");
            if (!ModelState.IsValid || ProfilePictureURL == null) return View(organizer);

            organizer.ProfilePictureURL =  ProfilePictureURL.FileName;
            await _service.AddAsync(organizer);
            this.saveFile(ProfilePictureURL, organizer.FullName);
            return RedirectToAction(nameof(Index));
        }

        //GET: organizers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")]Organizer organizer, IFormFile ProfilePictureURL)
        {
            ModelState.Remove("ProfilePictureURL");
            ModelState.Remove("Events");
            if (!ModelState.IsValid) return View(organizer);

            if (id == organizer.Id)
            {
                if (ProfilePictureURL != null)
                {
                    organizer.ProfilePictureURL =  ProfilePictureURL.FileName;
                    this.saveFile(ProfilePictureURL, organizer.FullName);
                }
                await _service.UpdateAsync(id, organizer);
                return RedirectToAction(nameof(Index));
            }
            return View(organizer);
        }

        //GET: organizers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");
            return View(organizerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizerDetails = await _service.GetByIdAsync(id);
            if (organizerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private void saveFile(IFormFile file, String name)
        {
            var fileName =  Path.GetFileName(file.FileName);

            // Specify the directory where you want to move the file
            var uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "EventUploads");

            // Combine the directory and file name to get the full path
            var filePath = Path.Combine(uploadDir, fileName);

            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            // Move the file to the specified directory
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
