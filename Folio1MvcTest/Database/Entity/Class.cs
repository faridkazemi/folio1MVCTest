using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entity
{
   public class Class
    {
        [Key]
        public int Id { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public Location Location { get; set; }

    }
}
