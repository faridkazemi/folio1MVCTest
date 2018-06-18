using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using Database.Entity;
using Database.Repository.Interface;
using Folio1MvcTest.Mapper.Interface;
using Folio1MvcTest.Models;

namespace Folio1MvcTest.Controllers
{
    public class StudentController : ApiController
    {
        IStudentRepository studentRepository;
        IStudentMapper mapper;
        IUnitOfWork unitOfWork;
        public StudentController(IUnitOfWork uow, IStudentMapper studentMapper)
        {
            unitOfWork = uow;
            studentRepository = uow.StudentRepository;
            mapper = studentMapper;
        }
        // GET api/<controller>
        [HttpGet]
        [Route("api/student/get")]
        public StudentViewModel Get()
        {
            List<Student> result = studentRepository.Get(c => c.Id > 0, "").ToList();
            return mapper.ToViewModel(result);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/student/save")]
        public void Post(Student entity)
        {
            studentRepository.Insert(entity);
            unitOfWork.SaveAsync();
        }
    }
}
