using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database.Entity;
using Folio1MvcTest.Models;

namespace Folio1MvcTest.Mapper.Interface
{
    public interface IStudentMapper: IGenericMapper<Student, StudentViewModel>
    {
    }
}