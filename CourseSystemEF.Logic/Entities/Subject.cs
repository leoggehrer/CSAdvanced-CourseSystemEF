using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSystemEF.Logic.Entities
{
    [Table("Subjects")]
    [Index(nameof(Designation), IsUnique = true)]
    public class Subject : EntityObject
    {
        [Required]
        [MaxLength(64)]
        public string Designation { get; set; }

        // Navigation properties
        public List<Course> Courses { get; set; }
    }
}
