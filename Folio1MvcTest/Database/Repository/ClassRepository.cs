using Database.Entity;
using Database.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(SchoolContext context) : base(context)
        {
        }
    }
}
