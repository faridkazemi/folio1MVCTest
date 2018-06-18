using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folio1MvcTest.Models
{
    public class ClassViewModel
    {
        public List<Class> ClassesList { get; set; }
        public List<Location> LocationsList { get; set; }
        public List<Teacher> TeachersList { get; set; }
    }
}