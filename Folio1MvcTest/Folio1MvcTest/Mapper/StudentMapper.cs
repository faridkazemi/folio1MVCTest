using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
using Database.Entity;
using Folio1MvcTest.Mapper.Interface;
using Folio1MvcTest.Models;

namespace Folio1MvcTest.Mapper
{
    public class StudentMapper : IStudentMapper
    {
        IUnitOfWork uow;
        public StudentMapper(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        public Student ToEntity(StudentViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public List<Student> ToEntity(List<StudentViewModel> viewModel)
        {
            throw new NotImplementedException();
        }

        public StudentViewModel ToViewModel(Student entity)
        {
            throw new NotImplementedException();
        }

        public StudentViewModel ToViewModel(List<Student> entity)
        {
            var classes = uow.ClassRepository.Get(c => c.Id > 0, "");
            return new StudentViewModel()
            {
                ClassesList = classes.ToList(),
                StudentsList = entity
            };
        }
    }
}