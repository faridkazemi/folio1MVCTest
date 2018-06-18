using System.ComponentModel.DataAnnotations;

namespace Database.Entity
{
   public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        public string FirstName { get; set; }
        [StringLength(15)]
        public string LastName { get; set; }

        [Range(4,99)]
        public int Age { get; set; }
        public decimal GPA { get; set; }


    }
}
