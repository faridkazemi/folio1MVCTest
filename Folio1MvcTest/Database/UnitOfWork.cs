using Database.Repository;
using Database.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace Database
{
   public class UnitOfWork:IUnitOfWork
    {
        SchoolContext context;
        ILocationRepository locationRepository;
        IClassRepository classRepository;
        ITeacherRepository teacherRepository;
        IStudentRepository studentRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            context = new SchoolContext();
        }

        public ILocationRepository LocationRepository
        {
            get
            {
                if (locationRepository == null)
                    locationRepository = new LocationRepository(this.context);
                return locationRepository;
            }
        }
        public IStudentRepository StudentRepository
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(this.context);
                return studentRepository;
            }
        }
        public IClassRepository ClassRepository
        {
            get
            {
                if (classRepository == null)
                    classRepository = new ClassRepository(this.context);
                return classRepository;
            }
        }

        public ITeacherRepository TeacherRepository
        {
            get
            {
                if (teacherRepository == null)
                    teacherRepository = new TeacherRepository(this.context);
                return teacherRepository;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
