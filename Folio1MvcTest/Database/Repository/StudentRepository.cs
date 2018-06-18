using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entity;
using Database.Repository.Interface;

namespace Database.Repository
{
   public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }
    }
}
