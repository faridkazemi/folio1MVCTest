using Database.Entity;
using Database.Repository.Interface;

namespace Database.Repository
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(SchoolContext context) : base(context)
        {
        }
    }
}
