using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSystemEF.Logic.Entities
{
    [Table("Students")]
    public class Student : Person
    {
        [Required]
        [MaxLength(12)]
        public string Number { get; set; }
        // Navigation properties
        public CourseXStudent CourseXStudent { get; set; }
    }
}
