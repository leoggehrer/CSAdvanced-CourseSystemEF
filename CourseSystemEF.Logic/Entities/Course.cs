using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSystemEF.Logic.Entities
{
    [Table("Courses")]
    [Index(nameof(Designation), IsUnique = true)]
    public class Course : EntityObject
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Designation { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Content { get; set; }

        // Navigation properties
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public CourseXStudent CourseXStudent { get; set; }
    }
}
