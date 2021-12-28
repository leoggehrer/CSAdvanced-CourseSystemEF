using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSystemEF.Logic.Entities
{
    [Table("Teachers")]
    public class Teacher : Person
    {
        [MaxLength(128)]
        public string Title { get; set; }
    }
}
