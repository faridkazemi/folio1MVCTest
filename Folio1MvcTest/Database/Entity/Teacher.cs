using System.ComponentModel.DataAnnotations;

namespace Database.Entity
{
   public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        public string FirstName { get; set; }

        [StringLength(15)]
        public string LastName { get; set; }
    }
}
