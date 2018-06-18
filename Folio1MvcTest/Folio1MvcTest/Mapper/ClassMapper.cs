using Database;
using Database.Entity;
using Folio1MvcTest.Mapper.Interface;
using Folio1MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folio1MvcTest.Mapper
{
    public class ClassMapper : IClassMapper
    {
        IUnitOfWork uow;
        public ClassMapper(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        public Class ToEntity(ClassViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public List<Class> ToEntity(List<ClassViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public ClassViewModel ToViewModel(Class entity)
        {
            throw new NotImplementedException();
        }

        public ClassViewModel ToViewModel(List<Class> entity)
        {
            List<Location> locations = uow.LocationRepository.Get(l => l.Id > 0, "").ToList();
            List<Teacher> Teachers = uow.TeacherRepository.Get(l => l.Id > 0, "").ToList();

            return new ClassViewModel()
            {
                ClassesList = entity,
                LocationsList = locations,
                TeachersList = Teachers
            };
        }
    }
        
    }
