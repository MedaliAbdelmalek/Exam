using Exam.Data.Base;
using Exam.Models;

namespace Exam.Data.Services
{
    public class OrganizersService: EntityBaseRepository<Organizer>, IOrganizersService
    {
        public OrganizersService(AppDbContext context) : base(context)
        {
        }
    }
}
