
using Exam.Data.Services;
using Exam.Data.Static;
using Exam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Exam.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EventsController : Controller
    {
        private readonly IEventsService _service;

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);
            return View(allEvents);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allEvents.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allEvents.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allEvents);
        }

        //GET: Events/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var eventDetail = await _service.GetEventByIdAsync(id);
            return View(eventDetail);
        }

        //GET: Events/Create
        public async Task<IActionResult> Create()
        {
            var eventDropdownsData = await _service.GetNewEventDropdownsValues();

            ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
            ViewBag.Organizers = new SelectList(eventDropdownsData.Organizers, "Id", "FullName");
            ViewBag.Guests = new SelectList(eventDropdownsData.Guests, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEventVM newEvent, IFormFile ImageURL)
        {
            ModelState.Remove("ImageURL");

            if (!ModelState.IsValid || ImageURL == null)
            {
                var eventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
                ViewBag.Organizers = new SelectList(eventDropdownsData.Organizers, "Id", "FullName");
                ViewBag.Guests = new SelectList(eventDropdownsData.Guests, "Id", "FullName");

                return View(newEvent);
            }

            await _service.AddNewEventAsync(newEvent, ImageURL);
            return RedirectToAction(nameof(Index));
        }



        //GET: Events/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");

            var response = new NewEventVM()
            {
                Id = eventDetails.Id,
                Name = eventDetails.Name,
                Description = eventDetails.Description,
                Price = eventDetails.Price,
                StartDate = eventDetails.StartDate,
                EndDate = eventDetails.EndDate,
                ImageURL = eventDetails.ImageURL,
                EventCategory = eventDetails.EventCategory,
                LocationId = eventDetails.LocationId,
                OrganizerId = eventDetails.OrganizerId,
                GuestIds = eventDetails.Guests_Events.Select(n => n.GuestId).ToList(),
            };

            var eventDropdownsData = await _service.GetNewEventDropdownsValues();
            ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
            ViewBag.Organizers = new SelectList(eventDropdownsData.Organizers, "Id", "FullName");
            ViewBag.Guests = new SelectList(eventDropdownsData.Guests, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEventVM newEvent)
        {
            if (id != newEvent.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var eventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(eventDropdownsData.Locations, "Id", "Name");
                ViewBag.Organizers = new SelectList(eventDropdownsData.Organizers, "Id", "FullName");
                ViewBag.Guests = new SelectList(eventDropdownsData.Guests, "Id", "FullName");

                return View(newEvent);
            }

            await _service.UpdateEventAsync(newEvent);
            return RedirectToAction(nameof(Index));
        }
    }
}