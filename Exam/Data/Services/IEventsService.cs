using Exam.Data.Base;
using Exam.Data.ViewModels;
using Exam.Models;

namespace Exam.Data.Services
{
    public interface IEventsService:IEntityBaseRepository<Event>
    {
        Task<Event> GetEventByIdAsync(int id);
        Task<NewEventDropdownsVM> GetNewEventDropdownsValues();
        Task AddNewEventAsync(NewEventVM data, IFormFile file);
        Task UpdateEventAsync(NewEventVM data);
    }
}
