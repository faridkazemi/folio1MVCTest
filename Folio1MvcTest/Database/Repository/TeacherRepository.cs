using Database.Entity;
using Database.Repository.Interface;

namespace Database.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolContext context) : base(context)
        {
        }
    }
}
