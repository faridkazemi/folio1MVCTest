using Database;
using Database.Entity;
using Database.Repository.Interface;
using Folio1MvcTest.Mapper.Interface;
using Folio1MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Folio1MvcTest.Controllers
{
    public class LocationController : ApiController
    {
        ILocationRepository locationRepository;
        ILocationMapper mapper;
        public LocationController(IUnitOfWork uow, ILocationMapper locationMapper)
        {

            locationRepository = uow.LocationRepository;
            mapper = locationMapper;
        }
        // GET api/<controller>
        [HttpGet]
        [Route("api/location/get")]
        public LocationViewModel Get()
        {
            List<Location> result = locationRepository.Get(c => c.Id > 0, "").ToList();
            return mapper.ToViewModel(result);
        }
    }
}
