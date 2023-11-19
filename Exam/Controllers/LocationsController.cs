using Exam.Data;
using Exam.Data.Services;
using Exam.Data.Static;
using Exam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class LocationsController : Controller
    {
        private readonly ILocationsService _service;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public LocationsController(ILocationsService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _hostingEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allLocations = await _service.GetAllAsync();
            return View(allLocations);
        }


        //Get: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Location location, IFormFile Logo)
        {
            ModelState.Remove("Logo");
            ModelState.Remove("Events");

            if (!ModelState.IsValid) return View(location);
            location.Logo = location.Name + "_" + Logo.FileName;
            await _service.AddAsync(location);
            saveFile(Logo, location.Name);
            return RedirectToAction(nameof(Index));
        }

        //Get: Locations/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        //Get: Locations/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Location location, IFormFile Logo)
        {
            ModelState.Remove("Events");
            ModelState.Remove("Logo");
            if (!ModelState.IsValid) return View(location);
            if (Logo != null)
            {
                location.Logo = location.Name + "_" + Logo.FileName;
                saveFile(Logo, location.Name);

            }
            await _service.UpdateAsync(id, location);


            return RedirectToAction(nameof(Index));
        }

        //Get: Locations/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private void saveFile(IFormFile file, String name)
        {
            var fileName = name + "_" + Path.GetFileName(file.FileName);

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
