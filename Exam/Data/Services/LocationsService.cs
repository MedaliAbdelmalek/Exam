using Exam.Data.Base;
using Exam.Models;

namespace Exam.Data.Services
{
    public class LocationsService : EntityBaseRepository<Location>, ILocationsService
    {
        public LocationsService(AppDbContext context) : base(context)
        {
        }
    }
}
