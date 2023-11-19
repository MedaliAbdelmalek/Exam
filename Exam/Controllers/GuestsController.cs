using Exam.Data.Services;
using Exam.Data.Static;
using Exam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class GuestsController : Controller
    {
        private readonly IGuestsService _service;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public GuestsController(IGuestsService service, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Guests/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Guest guest, IFormFile ProfilePictureURL)
        {
            ModelState.Remove("ProfilePictureURL");
            ModelState.Remove("Guests_Events");
            if (!ModelState.IsValid || ProfilePictureURL == null)
            {
                return View(guest);
            }
            guest.ProfilePictureURL =  ProfilePictureURL.FileName;
            await _service.AddAsync(guest);
            saveFile(ProfilePictureURL, guest.FullName);



            return RedirectToAction(nameof(Index));
        }

        //Get: Guests/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var guestDetails = await _service.GetByIdAsync(id);

            if (guestDetails == null) return View("NotFound");
            return View(guestDetails);
        }

        //Get: Guests/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var guestDetails = await _service.GetByIdAsync(id);
            if (guestDetails == null) return View("NotFound");
            return View(guestDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Guest guest, IFormFile ProfilePictureURL)
        {
            ModelState.Remove("ProfilePictureURL");
            ModelState.Remove("Guests_Events");
            if (!ModelState.IsValid)
            {
                return View(guest);
            }
            guest.ProfilePictureURL =  ProfilePictureURL.FileName;
            await _service.UpdateAsync(id, guest);
            this.saveFile(ProfilePictureURL,guest.FullName);
            return RedirectToAction(nameof(Index));
        }

        //Get: Guests/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var guestDetails = await _service.GetByIdAsync(id);
            if (guestDetails == null) return View("NotFound");
            return View(guestDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestDetails = await _service.GetByIdAsync(id);
            if (guestDetails == null) return View("NotFound");

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
