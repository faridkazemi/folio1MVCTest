using Database.Entity;
using Folio1MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folio1MvcTest.Mapper.Interface
{
    public class ILocationMapper : IGenericMapper<Location, LocationViewModel>
    {
        public Location ToEntity(LocationViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public List<Location> ToEntity(List<LocationViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public LocationViewModel ToViewModel(Location entity)
        {
            throw new NotImplementedException();

        }

        public LocationViewModel ToViewModel(List<Location> entity)
        {
            return new LocationViewModel()
            {
                LocationsList = entity
            };
        }
    }
}