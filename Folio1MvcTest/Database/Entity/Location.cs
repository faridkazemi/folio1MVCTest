using System.ComponentModel.DataAnnotations;

namespace Database.Entity
{
   public class Location
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

    }
}
