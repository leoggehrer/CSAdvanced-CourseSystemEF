using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSystemEF.Logic.Entities
{
    [Table("CourseXStudents")]
    [Index(nameof(CourseId), IsUnique = false)]
    [Index(nameof(StudentId), IsUnique = false)]
    public class CourseXStudent : EntityObject
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
