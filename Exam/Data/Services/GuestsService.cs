

using Exam.Data.Base;
using Exam.Models;

namespace Exam.Data.Services
{
    public class GuestsService : EntityBaseRepository<Guest>, IGuestsService
    {
        public GuestsService(AppDbContext context) : base(context) { }
    }
}
