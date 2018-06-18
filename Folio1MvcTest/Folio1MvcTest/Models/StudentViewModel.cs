using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database.Entity;

namespace Folio1MvcTest.Models
{
    public class StudentViewModel
    {
        public List<Student> StudentsList { get; set; }
        public List<Class> ClassesList { get; set; }
    }
}