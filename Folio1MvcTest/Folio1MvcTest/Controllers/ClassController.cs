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
    public class ClassController : ApiController
    {
        IClassRepository classRepository;
        IClassMapper mapper;
        IUnitOfWork unitOfWork;
        public ClassController(IUnitOfWork uow, IClassMapper classMapper)
        {
            unitOfWork = uow;
            classRepository = uow.ClassRepository;
            mapper = classMapper;
        }
        // GET api/<controller>
        [HttpGet]
        [Route("api/class/get")]
        public ClassViewModel Get()
        {
            List<Class> result = classRepository.Get(c => c.Id > 0, "Location,Teacher,Students").ToList();
            return mapper.ToViewModel(result);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/class/save")]
        public void Post(Class entity)
        {
            classRepository.Insert(entity);
            unitOfWork.SaveAsync();
        }

        // PUT api/<controller>/5
        [HttpPost]
        [Route("api/class/update")]
        public void Put(Class entity)
        {
            classRepository.Update(entity);
            unitOfWork.SaveAsync();
        }

        // DELETE api/<controller>/5
        [HttpGet]
        [Route("api/class/remove")]
        public void Delete(int id)
        {
            classRepository.Delete(id);
            unitOfWork.SaveAsync();
        }
    }

}